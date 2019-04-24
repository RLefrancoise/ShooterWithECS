using Components;
using Components.UI;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

namespace Systems.UI
{
    /// <summary>
    /// Set HUD player information (life, power, ...)
    /// </summary>
    public class SetHudDataSystem : JobComponentSystem
    {
        /// <summary>
        /// Job to compute player data (life, power, ...)
        /// </summary>
        [BurstCompile]
        private struct ComputePlayerData : IJobForEachWithEntity<Ship, Health, Power, PlayerInput>
        {
            [WriteOnly] public NativeArray<float> Healths;
            [WriteOnly] public NativeArray<float> Powers;
            
            /// <inheritdoc />
            public void Execute(Entity entity, int index, [ReadOnly] ref Ship ship, [ReadOnly] ref Health health, [ReadOnly] ref Power power, [ReadOnly] ref PlayerInput playerInput)
            {
                Healths[index] = health.value / ship.life;
                Powers[index] = power.value / ship.power;
            }
        }
        
        private NativeArray<float> _healths;
        private NativeArray<float> _powers;
        
        /// <inheritdoc />
        protected override void OnCreateManager()
        {
            base.OnCreateManager(); 
            _powers = new NativeArray<float>(1, Allocator.Persistent);
            _healths = new NativeArray<float>(1, Allocator.Persistent);
        }

        protected override void OnDestroyManager()
        {
            base.OnDestroyManager();
            _powers.Dispose();
            _healths.Dispose();
        }

        [BurstCompile]
        private struct SetHudDataJob : IJobForEach<HudData>
        {
            [ReadOnly] public float Health;
            [ReadOnly] public float Power;
            
            public void Execute([WriteOnly] ref HudData hudData)
            {
                hudData.health = Health;
                hudData.power = Power;
            }
        }
        
        /*
        /// <inheritdoc />
        protected override void OnUpdate()
        {
            var computePlayerData = new ComputePlayerData
            {
                Healths = _healths,
                Powers = _powers
            };

            var jobHandle = computePlayerData.Schedule(this);
            JobHandle.ScheduleBatchedJobs();
            jobHandle.Complete();

            if (jobHandle.IsCompleted)
            {
                Entities.ForEach((HUD hud) =>
                {
                    hud.playerHealthBar.fillAmount = _healths[0];
                    hud.playerPowerBar.fillAmount = _powers[0];
                });
            }
        }*/

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var computePlayerData = new ComputePlayerData
            {
                Healths = _healths,
                Powers = _powers
            };

            var computePlayerDataHandle = computePlayerData.Schedule(this, inputDeps);
            computePlayerDataHandle.Complete();
            
            var setHudDataJob = new SetHudDataJob
            {
                Health = _healths[0],
                Power = _powers[0]
            };
            return setHudDataJob.Schedule(this, computePlayerDataHandle);
        }
    }
}