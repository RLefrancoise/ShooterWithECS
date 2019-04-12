using Unity.Entities;
using UnityEngine;
using UnityQuery;

namespace Systems
{
    [UpdateBefore(typeof(MovementDataSystem))]
    [UpdateAfter(typeof(InputSystem))]
    public class PlayerMovementSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((InputComponent input, Transform transform, Ship ship) =>
            {
                var movementVector = new Vector3(input.Horizontal, 0f, input.Vertical);
                var movePosition = movementVector.normalized * ship.Speed * Time.deltaTime;

                transform.Translate(movePosition, Space.World);

                //Player too far from the left or right
                if (Mathf.Abs(transform.position.x) > Bootstrap.LevelLimits.extents.x)
                {
                    transform.position = transform.position.WithX(
                        Bootstrap.LevelLimits.extents.x * (transform.position.x >= 0f ? 1f : -1f));
                }

                transform.localRotation = Quaternion.Euler(
                    Vector3.Slerp(
                        Vector3.zero,
                        new Vector3(
                            0f,
                            0f,
                            -1f * ship.TiltAngle * movementVector.normalized.x),
                        Mathf.Abs(input.Horizontal)));
            });
        }
    }
}