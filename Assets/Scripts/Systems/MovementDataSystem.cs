using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    [UpdateAfter(typeof(CopyTransformFromGameObjectSystem))]
    public class MovementDataSystem : JobComponentSystem
    {
        [BurstCompile]
        private struct MovementDataJob : IJobProcessComponentData<Position, Rotation, MovementData>
        {
            public float DeltaTime;

            public void Execute([ReadOnly] ref Position position, [ReadOnly] ref Rotation rotation, ref MovementData movementData)
            {
                //Speed
                if (movementData.HasPreviousPosition == 0)
                {
                    movementData.PreviousPosition = position;
                    movementData.HasPreviousPosition = 1;
                }
                else
                {
                    var speed = position.Value - movementData.PreviousPosition.Value;
                    movementData.Velocity = speed / DeltaTime;
                    movementData.PreviousPosition = position;
                }

                //Angular speed
                if (movementData.HasPreviousRotation == 0)
                {
                    movementData.PreviousRotation = rotation;
                    movementData.HasPreviousRotation = 1;
                }
                else
                {
                    var angularSpeed = rotation.Value.ToStandardQuaternion().eulerAngles - movementData.PreviousRotation.Value.ToStandardQuaternion().eulerAngles;
                    movementData.AngularVelocity = new float3(angularSpeed) / DeltaTime;
                    movementData.PreviousRotation = rotation;
                }
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new MovementDataJob
            {
                DeltaTime = Time.deltaTime
            }.Schedule(this, inputDeps);
        }
    }
}
