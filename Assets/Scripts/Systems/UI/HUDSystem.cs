using Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

namespace Systems.UI
{
    /// <summary>
    /// Display player information (life, power, ...)
    /// </summary>
    public class HUDSystem : ComponentSystem
    {
        /// <summary>
        /// Job to compute player data (life, power, ...)
        /// </summary>
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
        
        /// <summary>
        /// Query to get player from entities
        /// </summary>
        private EntityQuery _query;
        
        /// <inheritdoc />
        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            _query = GetEntityQuery(
                ComponentType.ReadOnly<Ship>(), 
                ComponentType.ReadOnly<Health>(),
                ComponentType.ReadOnly<Power>(),
                ComponentType.ReadOnly<PlayerInput>());
        }

        /// <inheritdoc />
        protected override void OnUpdate()
        {
            var powers = new NativeArray<float>(_query.CalculateLength(), Allocator.Persistent);
            var healths = new NativeArray<float>(_query.CalculateLength(), Allocator.Persistent);
            
            var computePlayerData = new ComputePlayerData
            {
                Healths = healths,
                Powers = powers
            };

            var jobHandle = computePlayerData.Schedule(this);
            JobHandle.ScheduleBatchedJobs();
            
            jobHandle.Complete();

            if (jobHandle.IsCompleted)
            {
                Entities.ForEach((HUD hud) =>
                {
                    hud.playerHealthBar.fillAmount = healths[0];
                    hud.playerPowerBar.fillAmount = powers[0];
                });
            }
            
            powers.Dispose();
            healths.Dispose();
        }
    }
}