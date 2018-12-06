using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

namespace Systems
{
    /// <summary>
    /// Ship weapon system
    /// </summary>
    public class WeaponShootingSystem : JobComponentSystem
    {
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
        
        private struct Data
        {
            public readonly int Length;
            public EntityArray Entities;
            public ComponentDataArray<Weapon> Weapons;
            public SubtractiveComponent<Firing> Firings;
        }

        [Inject] private Data _data;
        [Inject] private WeaponShootingBarrier _barrier;
        
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            if (Input.GetButton("Fire1"))
            {
                return new WeaponShootingJob
                {
                    EntityArray = _data.Entities,
                    Weapons = _data.Weapons,
                    EntityCommandBuffer = _barrier.CreateCommandBuffer().ToConcurrent(),
                    CurrentTime = Time.time
                }.Schedule(_data.Length, 64, inputDeps);
            }

            return base.OnUpdate(inputDeps);
        }
    }
    
    public class WeaponShootingBarrier : BarrierSystem {}
}