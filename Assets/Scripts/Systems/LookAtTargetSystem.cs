using System;
using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityQuery;

namespace Systems
{
    public class LookAtTargetSystem : JobComponentSystem
    {
        [BurstCompile]
        private struct LookAtTargetJob : IJobForEach<Translation, Rotation, WorldToLocal, LookAtTarget>
        {
            /// <inheritdoc />
            public void Execute(ref Translation translation, ref Rotation rotation, [ReadOnly] ref WorldToLocal worldToLocal, [ReadOnly] ref LookAtTarget lookAtTarget)
            {
                float3 direction;
                
                if (lookAtTarget.KeepWorldUp)
                {
                    var targetPositionWithSameY = new float3(lookAtTarget.TargetWorldPosition.x, translation.Value.y, lookAtTarget.TargetWorldPosition.z);
                    direction = math.normalize(targetPositionWithSameY - translation.Value);
                }
                else
                {
                    direction = math.normalize(lookAtTarget.TargetWorldPosition - translation.Value);
                }
                
                rotation.Value = math.mul(quaternion.LookRotation(direction, math.up()).value, worldToLocal.Value);

                switch (lookAtTarget.LookAtAxis)
                {
                    case LookAtTarget.Axis.X:
                        rotation.Value = math.mul(rotation.Value, quaternion.Euler(0f, math.radians(-90f), 0f));
                        break;
                    case LookAtTarget.Axis.Y:
                        rotation.Value = math.mul(rotation.Value, quaternion.Euler(math.radians(90f), 0f, 0f));
                        break;
                    case LookAtTarget.Axis.Z:
                        break;
                    case LookAtTarget.Axis.MinusX:
                        rotation.Value = math.mul(rotation.Value, quaternion.Euler(0f, math.radians(90f), 0f));
                        break;
                    case LookAtTarget.Axis.MinusY:
                        rotation.Value = math.mul(rotation.Value, quaternion.Euler(math.radians(-90f), 0f, 0f));
                        break;
                    case LookAtTarget.Axis.MinusZ:
                        rotation.Value = math.mul(rotation.Value, quaternion.Euler(0f, math.radians(180f), 0f));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        /*protected override void OnUpdate()
        {
            Entities.ForEach((Transform transform, LookAtTargetComponent lookAtTarget) =>
            {
                var direction = Vector3.zero;

                if(lookAtTarget.KeepWorldUp)
                    direction = (lookAtTarget.Target.position.WithY(transform.position.y) - transform.position).normalized;
                else
                    direction = (lookAtTarget.Target.position - transform.position).normalized;

                transform.rotation = Quaternion.LookRotation(direction);

                switch (lookAtTarget.LookAtAxis)
                {
                    case LookAtTargetComponent.Axis.X:
                        transform.localRotation *= Quaternion.Euler(0f, -90f, 0f);
                        break;
                    case LookAtTargetComponent.Axis.Y:
                        transform.localRotation *= Quaternion.Euler(90f, 0f, 0f);
                        break;
                    case LookAtTargetComponent.Axis.Z:
                        break;
                    case LookAtTargetComponent.Axis.MinusX:
                        transform.localRotation *= Quaternion.Euler(0f, 90f, 0f);
                        break;
                    case LookAtTargetComponent.Axis.MinusY:
                        transform.localRotation *= Quaternion.Euler(-90f, 0f, 0f);
                        break;
                    case LookAtTargetComponent.Axis.MinusZ:
                        transform.localRotation *= Quaternion.Euler(0f, 180f, 0f);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }*/

        /// <inheritdoc />
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new LookAtTargetJob().Schedule(this, inputDeps);
        }
    }
}
