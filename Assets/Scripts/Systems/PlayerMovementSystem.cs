using Unity.Entities;
using UnityEngine;
using UnityQuery;

namespace Systems
{
    [UpdateBefore(typeof(MovementDataSystem))]
    [UpdateAfter(typeof(InputSystem))]
    public class PlayerMovementSystem : ComponentSystem
    {
        private struct Filter
        {
            public InputComponent InputComponent;
            public Transform Transform;
            public Ship Ship;
        }
        
        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Filter>())
            {
                var movementVector = new Vector3(entity.InputComponent.Horizontal, 0f, entity.InputComponent.Vertical);
                var movePosition = movementVector.normalized * entity.Ship.Speed * Time.deltaTime;
                
                entity.Transform.Translate(movePosition, Space.World);

                //Player too far from the left or right
                if (Mathf.Abs(entity.Transform.position.x) > Bootstrap.LevelLimits.extents.x)
                {
                    entity.Transform.position = entity.Transform.position.WithX(
                        Bootstrap.LevelLimits.extents.x * (entity.Transform.position.x >= 0f ? 1f : -1f));
                }

                entity.Transform.localRotation = Quaternion.Euler(
                    Vector3.Slerp(
                        Vector3.zero, 
                        new Vector3(
                            0f,
                            0f,
                            -1f * entity.Ship.TiltAngle * movementVector.normalized.x),
                        Mathf.Abs(entity.InputComponent.Horizontal)));
            }
        }
    }
}