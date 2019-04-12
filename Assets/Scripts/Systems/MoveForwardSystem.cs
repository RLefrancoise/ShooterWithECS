using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class MoveForwardSystem : ComponentSystem
    {
        /// <inheritdoc />
        protected override void OnUpdate()
        {
            Entities.ForEach((Transform transform, MoveForward moveForward, MoveSpeed moveSpeed) =>
                {
                    transform.position = transform.position + moveSpeed.Speed * transform.forward * Time.deltaTime;
                });
        }
    }
}