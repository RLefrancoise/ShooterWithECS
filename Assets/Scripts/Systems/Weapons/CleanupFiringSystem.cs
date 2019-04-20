using Components.Weapons;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Systems
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class CleanupFiringSystem : JobComponentSystem
    {
        private struct CleanupFiringJob : IJobForEachWithEntity<Firing, Weapon>
        {
            [ReadOnly] public EntityCommandBuffer EntityCommandBuffer;
            public float CurrentTime;

            /// <inheritdoc />
            public void Execute(Entity entity, int index, [ReadOnly] ref Firing firing, [ReadOnly] ref Weapon weapon)
            {
                if (CurrentTime - firing.firedAt < weapon.fireRate) return;
                EntityCommandBuffer.RemoveComponent<Firing>(entity);
            }
        }
        
        private BeginInitializationEntityCommandBufferSystem _entityCommandBufferSystem;
        
        protected override void OnCreateManager()
        {
            _entityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
        }
        
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var job = new CleanupFiringJob
            {
                EntityCommandBuffer = _entityCommandBufferSystem.CreateCommandBuffer(),
                CurrentTime = Time.time
            }.Schedule(this, inputDeps);
            
            _entityCommandBufferSystem.AddJobHandleForProducer(job);
            return job;
        }
    }
}