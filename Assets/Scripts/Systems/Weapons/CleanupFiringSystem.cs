using Components.Weapons;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Systems
{
    /*public class CleanupFiringSystem : JobComponentSystem
    {
        private struct CleanupFiringJob : IJobParallelFor
        {
            [ReadOnly] public EntityArray Entities;
            [ReadOnly] public ComponentDataArray<Weapon> Weapons;
            public EntityCommandBuffer.Concurrent EntityCommandBuffer;
            public float CurrentTime;
            public ComponentDataArray<Firing> Firings;
            
            public void Execute(int index)
            {
                if (CurrentTime - Firings[index].FiredAt < Weapons[index].FireRate) return;
                EntityCommandBuffer.RemoveComponent<Firing>(index, Entities[index]);
            }
        }
        
        private struct Data
        {
            public readonly int Length;
            public EntityArray Entities;
            public ComponentDataArray<Weapon> Weapons;
            public ComponentDataArray<Firing> Firings;
        }

        [Inject] private Data _data;
        [Inject] private CleanupFiringBarrier _barrier;
        
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new CleanupFiringJob
            {
                Entities = _data.Entities,
                EntityCommandBuffer = _barrier.CreateCommandBuffer().ToConcurrent(),
                CurrentTime = Time.time,
                Weapons = _data.Weapons,
                Firings = _data.Firings
            }.Schedule(_data.Length, 64, inputDeps);
        }
    }

    public class CleanupFiringBarrier : BarrierSystem
    {
    }*/

    public class CleanupFiringSystem : ComponentSystem
    {
        /// <inheritdoc />
        protected override void OnUpdate()
        {
            /*var currentTime = Time.time;
            
            Entities.ForEach((Entity entity, Weapon weapon, Firing firing) =>
            {
                if (currentTime - firing.firedAt < weapon.FireRate) return;
                EntityManager.RemoveComponent<Firing>(entity);
            });*/
        }
    }
}