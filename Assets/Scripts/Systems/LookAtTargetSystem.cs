using System;
using Components;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityQuery;

namespace Systems
{
    [UpdateAfter(typeof(CopyTransformFromGameObjectSystem))]
    public class LookAtTargetSystem : ComponentSystem
    {
        private struct Filter
        {
            public Transform Transform;
            public LookAtTargetComponent LookAtTarget;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Filter>())
            {
                Vector3 direction = Vector3.zero;

                if(entity.LookAtTarget.KeepWorldUp)
                    direction = (entity.LookAtTarget.Target.position.WithY(entity.Transform.position.y) - entity.Transform.position).normalized;
                else
                    direction = (entity.LookAtTarget.Target.position - entity.Transform.position).normalized;

                entity.Transform.rotation = Quaternion.LookRotation(direction);

                switch (entity.LookAtTarget.LookAtAxis)
                {
                    case LookAtTargetComponent.Axis.X:
                        entity.Transform.localRotation *= Quaternion.Euler(0f, -90f, 0f);
                        break;
                    case LookAtTargetComponent.Axis.Y:
                        entity.Transform.localRotation *= Quaternion.Euler(90f, 0f, 0f);
                        break;
                    case LookAtTargetComponent.Axis.Z:
                        break;
                    case LookAtTargetComponent.Axis.MinusX:
                        entity.Transform.localRotation *= Quaternion.Euler(0f, 90f, 0f);
                        break;
                    case LookAtTargetComponent.Axis.MinusY:
                        entity.Transform.localRotation *= Quaternion.Euler(-90f, 0f, 0f);
                        break;
                    case LookAtTargetComponent.Axis.MinusZ:
                        entity.Transform.localRotation *= Quaternion.Euler(0f, 180f, 0f);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
