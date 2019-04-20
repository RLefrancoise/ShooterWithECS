using Components;
using Components.Weapons;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;

namespace Systems
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class FiringSystem : JobComponentSystem
    {        
        private struct FiringJob : IJobForEach<Firing, Rotation, Weapon, LocalToWorld>
        {
            [ReadOnly] public EntityCommandBuffer EntityCommandBuffer;

            /// <inheritdoc />
            public void Execute([ReadOnly] ref Firing firing, [ReadOnly] ref Rotation rotation, [ReadOnly] ref Weapon weapon, [ReadOnly] ref LocalToWorld localToWorld)
            {
                var bullet = EntityCommandBuffer.Instantiate(weapon.bulletPrefab);
                
                //Set bullet
                EntityCommandBuffer.SetComponent(bullet, new Bullet {lifeTime = weapon.bulletLifeTime});
                //Set position
                EntityCommandBuffer.SetComponent(bullet, new Translation{Value = localToWorld.Position});
                //Set rotation
                EntityCommandBuffer.SetComponent(bullet, new Rotation{Value = rotation.Value});
                //Set move forward
                EntityCommandBuffer.SetSharedComponent(bullet, new MoveForward());
                //Set move speed
                EntityCommandBuffer.SetComponent(bullet, new MoveSpeed {value = weapon.fireSpeed});
            }
        }

        private BeginInitializationEntityCommandBufferSystem _entityCommandBufferSystem;
        
        private EntityQuery _componentGroup;
        
        protected override void OnCreateManager()
        {
            _entityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
            
            _componentGroup = GetEntityQuery(
                ComponentType.ReadOnly<Weapon>(),
                ComponentType.ReadOnly<Firing>(),
                ComponentType.ReadOnly<LocalToWorld>(),
                ComponentType.ReadOnly<Rotation>());
            
            _componentGroup.SetFilterChanged(ComponentType.ReadOnly<Firing>());
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var job = new FiringJob
            {
                EntityCommandBuffer = _entityCommandBufferSystem.CreateCommandBuffer()
            }.Schedule(_componentGroup, inputDeps);
            
            _entityCommandBufferSystem.AddJobHandleForProducer(job);
            return job;
        }
    }
}