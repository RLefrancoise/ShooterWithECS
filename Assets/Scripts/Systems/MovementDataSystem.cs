using Components;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    public class MovementDataSystem : JobComponentSystem
    {
        private struct MovementDataJob : IJobForEach<Translation, Rotation, MovementData/*, LocalToWorld*/>
        {
            public float DeltaTime;
            
            /// <inheritdoc />
            public void Execute([ReadOnly] ref Translation translation, [ReadOnly] ref Rotation rotation, ref MovementData movementData/*, [ReadOnly] ref LocalToWorld localToWorld*/)
            {
                var worldPosition = translation.Value;
                
                //Speed
                if (!movementData.hasPreviousPosition)
                {
                    movementData.previousPosition = worldPosition;
                    movementData.hasPreviousPosition = true;
                }
                else
                {
                    movementData.velocity = (worldPosition - movementData.previousPosition) / DeltaTime;
                    movementData.previousPosition = worldPosition;
                }
                
                //Angular speed
                /*if (!movementData.HasPreviousRotation)
                {
                    movementData.PreviousRotation = rotation.Value;
                    movementData.HasPreviousRotation = true;
                }
                else
                {
                    movementData.RotationDelta = math.mul(rotation.Value, math.inverse(movementData.PreviousRotation));
                    
                    Quaternion q = math.normalizesafe(movementData.RotationDelta);
                    movementData.RotationDeltaEuler = q.eulerAngles;
                    
                    q.ToAngleAxis(out var angle, out var axis);
                    movementData.AngularVelocity = axis * angle * (1.0f / DeltaTime);

                    movementData.PreviousRotation = rotation.Value;
                }*/
                
            }
        }
        
        /*protected override void OnUpdate()
        {
            float dt = Time.deltaTime;

            Entities.ForEach((Transform transform, MovementDataComponent movementData) =>
            {
                var position = transform.position;
                var rotation = transform.rotation;

                //Speed
                if (!movementData.HasPreviousPosition)
                {
                    movementData.PreviousPosition = position;
                    movementData.HasPreviousPosition = true;
                }
                else
                {
                    var speed = position - movementData.PreviousPosition;
                    movementData.Velocity = speed / dt;
                    movementData.PreviousPosition = position;
                }

                //Angular speed
                if (!movementData.HasPreviousRotation)
                {
                    movementData.PreviousRotation = rotation;
                    movementData.HasPreviousRotation = true;
                }
                else
                {
                    movementData.RotationDelta = rotation * Quaternion.Inverse(movementData.PreviousRotation);
                    movementData.RotationDelta.ToAngleAxis(out var angle, out var axis);
                    movementData.AngularVelocity = axis * angle * (1.0f / Time.deltaTime);

                    movementData.PreviousRotation = rotation;
                }
            });
        }*/

        /// <inheritdoc />
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new MovementDataJob
            {
                DeltaTime = Time.deltaTime
            }.Schedule(this, inputDeps);
        }
    }
}
