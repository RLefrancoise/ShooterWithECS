using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    [UpdateBefore(typeof(MovementDataSystem))]
    [UpdateAfter(typeof(InputSystem))]
    public class PlayerMovementSystem : JobComponentSystem
    {
        [BurstCompile]
        private struct PlayerMovementJob : IJobForEach<Translation, Rotation, Ship, PlayerInput>
        {
            public float DeltaTime;
            
            /// <inheritdoc />
            public void Execute(ref Translation translation, ref Rotation rotation, [ReadOnly] ref Ship ship, [ReadOnly] ref PlayerInput playerInput)
            {
                var movementVector = new float3(playerInput.Horizontal, 0f, playerInput.Vertical);
                var movementDirection = math.normalizesafe(movementVector, float3.zero);
                var movePosition = movementDirection * ship.Speed * DeltaTime;

                translation.Value += movePosition;
            }
        }
        
        /// <inheritdoc />
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new PlayerMovementJob
            {
                DeltaTime = Time.deltaTime
            }.Schedule(this, inputDeps);
        }
    }
}