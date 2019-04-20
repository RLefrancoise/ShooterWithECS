using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Systems
{
    /// <summary>
    /// Input system to handle player input
    /// </summary>
    public class InputSystem : ComponentSystem
    {   
        protected override void OnUpdate()
        {
            var horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            var vertical = CrossPlatformInputManager.GetAxis("Vertical");

            Entities.ForEach((ref PlayerInput input) =>
            {
                input.horizontal = horizontal;
                input.vertical = vertical;
            });
        }
    }
}