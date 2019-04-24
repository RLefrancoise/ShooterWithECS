using System;
using System.Collections.Generic;
using System.Linq;
using Components.Weapons;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Systems
{
    /// <summary>
    /// Weapon shooting system base system
    /// </summary>
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public abstract class WeaponShootingSystem : JobComponentSystem
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
                if (!weapon.canFire) return;
                
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
        protected EntityQuery Group { get; set; }
        protected abstract ComponentType[] AdditionalComponentTypes { get; }
        
        protected override void OnCreateManager()
        {
            _entityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();

            var componentTypes = new List<ComponentType>()
            {
                ComponentType.ReadOnly<Weapon>(),
                ComponentType.Exclude<Firing>()
            };
            componentTypes.AddRange(AdditionalComponentTypes);
            
            Group = GetEntityQuery(componentTypes.ToArray());
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