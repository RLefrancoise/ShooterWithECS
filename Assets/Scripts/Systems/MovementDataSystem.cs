using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    [UpdateAfter(typeof(CopyInitialTransformFromGameObject))]
    public class MovementDataSystem : ComponentSystem
    {
        private struct Filter
        {
            public Transform Transform;
            public MovementDataComponent MovementData;
        }

        protected override void OnUpdate()
        {
            float dt = Time.deltaTime;

            foreach (var entity in GetEntities<Filter>())
            {
                var movementData = entity.MovementData;
                var position = entity.Transform.position;
                var rotation = entity.Transform.rotation;

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
            }
        }
    }
}
