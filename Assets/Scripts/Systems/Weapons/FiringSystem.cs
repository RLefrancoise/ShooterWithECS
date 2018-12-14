using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    public class FiringSystem : JobComponentSystem
    {        
        private struct FiringJob : IJobParallelFor
        {
            public EntityCommandBuffer.Concurrent EntityCommandBuffer;
            [ReadOnly] public ComponentDataArray<Weapon> Weapons;
            [ReadOnly] public ComponentDataArray<Position> Positions;
            [ReadOnly] public ComponentDataArray<Rotation> Rotations;

            public void Execute(int index)
            {
                //Create bullet from archetype
                EntityCommandBuffer.CreateEntity(index/*, Bootstrap.BulletArchetype*/);

                //Set renderer of bullet
                switch (Weapons[index].Kind)
                {
                    case WeaponKind.Player:
                        EntityCommandBuffer.AddSharedComponent(index, Bootstrap.BulletRenderer);
                        break;
                    case WeaponKind.Turret:
                        EntityCommandBuffer.AddSharedComponent(index, Bootstrap.TurretBulletRenderer);
                        break;
                }
                
                //Set bullet
                EntityCommandBuffer.AddComponent(index, new Bullet {LifeTime = Weapons[index].BulletLifeTime});
                //Set position
                EntityCommandBuffer.AddComponent(index, Positions[index]);
                //Set rotation
                EntityCommandBuffer.AddComponent(index, Rotations[index]);
                //Set scale
                EntityCommandBuffer.AddComponent(index, new Scale {Value = new float3(0.1f)});
                //Set move forward
                EntityCommandBuffer.AddSharedComponent(index, new MoveForward());
                //Set move speed
                EntityCommandBuffer.AddComponent(index, new MoveSpeed {Speed = Weapons[index].FireSpeed});
            }
        }

        private ComponentGroup _componentGroup;
        [Inject] private FiringBarrier _barrier;
        
        protected override void OnCreateManager()
        {
            _componentGroup = GetComponentGroup(
                ComponentType.ReadOnly<Weapon>(),
                ComponentType.ReadOnly<Firing>(),
                ComponentType.ReadOnly<Position>(),
                ComponentType.ReadOnly<Rotation>());
            
            _componentGroup.SetFilterChanged(ComponentType.Create<Firing>());
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new FiringJob
            {
                EntityCommandBuffer = _barrier.CreateCommandBuffer().ToConcurrent(),
                Weapons = _componentGroup.GetComponentDataArray<Weapon>(),
                Positions = _componentGroup.GetComponentDataArray<Position>(),
                Rotations = _componentGroup.GetComponentDataArray<Rotation>()
            }.Schedule(_componentGroup.CalculateLength(), 64, inputDeps);
        }
    }

    public class FiringBarrier : BarrierSystem
    {
    }
}