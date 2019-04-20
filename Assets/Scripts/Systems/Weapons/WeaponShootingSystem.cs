using Components.Weapons;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Systems
{
    /// <summary>
    /// Weapon shooting system template
    /// </summary>
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public class WeaponShootingSystem : JobComponentSystem
    {
        /// <summary>
        /// Weapon shooting job
        /// </summary>
        private struct WeaponShootingJob : IJobForEachWithEntity<Weapon>
        {
            [ReadOnly] public EntityCommandBuffer EntityCommandBuffer;
            public float CurrentTime;

            /// <inheritdoc />
            public void Execute(Entity entity, int index, [ReadOnly] ref Weapon weapon)
            {
                EntityCommandBuffer.AddComponent(entity, new Firing
                {
                    bulletPrefab = weapon.bulletPrefab,
                    firedAt = CurrentTime
                });
            }
        }

        private BeginInitializationEntityCommandBufferSystem _entityCommandBufferSystem;
        
        /// <summary>
        /// Group of component to use
        /// </summary>
        private EntityQuery Group { get; set; }
        
        protected override void OnCreateManager()
        {
            _entityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
            
            Group = GetEntityQuery(
                ComponentType.ReadOnly<Weapon>(),
                ComponentType.Exclude<Firing>());
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {            
            var job = new WeaponShootingJob
            {
                EntityCommandBuffer = _entityCommandBufferSystem.CreateCommandBuffer(),
                CurrentTime = Time.time
            }.Schedule(Group, inputDeps);

            _entityCommandBufferSystem.AddJobHandleForProducer(job);
            
            return job;
        }
    }
}