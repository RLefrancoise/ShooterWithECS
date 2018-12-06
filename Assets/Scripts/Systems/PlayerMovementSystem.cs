using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Systems
{
    public class PlayerMovementSystem : ComponentSystem
    {
        private struct Filter
        {
            public InputComponent InputComponent;
            public Rigidbody Rigidbody;
            public Transform Transform;
            public Ship Ship;
        }
        
        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Filter>())
            {
                var movementVector = new Vector3(entity.InputComponent.Horizontal, 0f, entity.InputComponent.Vertical);
                var movePosition = entity.Rigidbody.position + movementVector.normalized * entity.Ship.Speed * Time.deltaTime;
                
                entity.Rigidbody.MovePosition(movePosition);

                entity.Transform.localRotation = Quaternion.Euler(
                    Vector3.Slerp(
                        Vector3.zero, 
                        new Vector3(
                            0f,
                            0f,
                            -10f * movementVector.normalized.x),
                        Mathf.Abs(entity.InputComponent.Horizontal)));
            }
        }
    }
}