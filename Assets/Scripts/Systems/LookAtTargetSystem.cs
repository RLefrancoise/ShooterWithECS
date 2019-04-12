using System;
using Components;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityQuery;

namespace Systems
{
    public class LookAtTargetSystem : ComponentSystem
    {
        protected override void OnUpdate()
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
        }
    }
}
