using System;
using Components;
using Components.Weapons;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Systems
{/*
    /// <summary>
    /// Weapon shooting system template
    /// </summary>
    public abstract class WeaponShootingSystem<TBarrier> : JobComponentSystem where TBarrier : BarrierSystem
    {
        /// <summary>
        /// Weapon shooting job
        /// </summary>
        private struct WeaponShootingJob : IJobParallelFor
        {
            [ReadOnly] public EntityArray EntityArray;
            [ReadOnly] public ComponentDataArray<Weapon> Weapons;
            public EntityCommandBuffer.Concurrent EntityCommandBuffer;
            public float CurrentTime;
            
            public void Execute(int index)
            {
                EntityCommandBuffer.AddComponent(index, EntityArray[index], new Firing
                {
                    FiredAt = CurrentTime
                });
            }
        }

        /// <summary>
        /// Group of component to use
        /// </summary>
        protected abstract ComponentGroup Group { get; set; }
        /// <summary>
        /// Barrier to use
        /// </summary>
        protected abstract TBarrier Barrier { get; }

        /// <summary>
        /// Can shoot ?
        /// </summary>
        protected abstract bool CanShoot { get; }

        /// <summary>
        /// Weapon kind
        /// </summary>
        protected abstract ComponentType WeaponKind { get; }

        protected override void OnCreateManager()
        {
            Group = GetComponentGroup(
                ComponentType.ReadOnly<Weapon>(),
                WeaponKind,
                ComponentType.Subtractive<Firing>());
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            if (CanShoot)
            {
                return new WeaponShootingJob
                {
                    EntityArray = Group.GetEntityArray(),
                    Weapons = Group.GetComponentDataArray<Weapon>(),
                    EntityCommandBuffer = Barrier.CreateCommandBuffer().ToConcurrent(),
                    CurrentTime = Time.time
                }.Schedule(Group.CalculateLength(), 64, inputDeps);
            }

            return base.OnUpdate(inputDeps);
        }
    }*/

    public class WeaponShootingSystem : ComponentSystem
    {
        
        /// <summary>
        /// Group of component to use
        /// </summary>
        private EntityQuery Group { get; set; }
        
        /// <inheritdoc />
        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            Group = GetEntityQuery(
                ComponentType.ReadOnly<Weapon>(), 
                ComponentType.ReadOnly<PlayerWeapon>(),
                ComponentType.Exclude<Firing>());
        }

        /// <inheritdoc />
        protected override void OnUpdate()
        {
            /*if (!CrossPlatformInputManager.GetButtonDown("Fire1")) return;
            
            var entities = Group.ToEntityArray(Allocator.TempJob);
            var weapons = Group.ToComponentArray<Weapon>();

            for (var i = 0; i < entities.Length; ++i)
            {
                var entity = entities[i];
                var weapon = weapons[i];
                
                EntityManager.AddComponent(entity, ComponentType.ReadWrite<Firing>());
                var firing = EntityManager.GetComponentObject<Firing>(entity);
                firing.firedAt = Time.time;
                firing.bulletPrefab = weapon.BulletPrefab;
            }
            
            entities.Dispose();*/
        }
    }
}