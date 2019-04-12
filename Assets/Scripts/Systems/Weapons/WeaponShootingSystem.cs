using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

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
}