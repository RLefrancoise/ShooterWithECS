using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    /// <summary>
    /// handle ship tilting
    /// </summary>
    [UpdateAfter(typeof(MovementDataSystem))]
    public class ShipTiltingSystem : JobComponentSystem
    {
        [BurstCompile]
        private struct ShipTiltingJob : IJobForEach<Rotation, MovementData, Ship>
        {
            /// <inheritdoc />
            public void Execute(ref Rotation rotation, [ReadOnly] ref MovementData movementData, [ReadOnly] ref Ship ship)
            {                
                var speedRatio = movementData.Velocity.x / ship.Speed;
                speedRatio = math.clamp(speedRatio, -1f, 1f);
                
                var tiltAngle = math.radians(-1f * ship.TiltAngle * speedRatio);
                rotation.Value = quaternion.Euler(new float3(0f, 0f, tiltAngle));
            }
        }
        
        /// <inheritdoc />
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new ShipTiltingJob().Schedule(this, inputDeps);
        }
    }
}