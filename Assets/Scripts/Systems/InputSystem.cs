using Unity.Entities;
using UnityStandardAssets.CrossPlatformInput;

namespace Systems
{
    /// <summary>
    /// Input system to handle player input
    /// </summary>
    public class InputSystem : ComponentSystem
    {
        private struct Filter
        {
            public InputComponent InputComponent;
            public Ship Ship;
        }
        
        protected override void OnUpdate()
        {
            var horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            var vertical = CrossPlatformInputManager.GetAxis("Vertical");
            
            foreach (var entity in GetEntities<Filter>())
            {
                entity.InputComponent.Horizontal = horizontal;
                entity.InputComponent.Vertical = vertical;
                foreach (var thruster in entity.Ship.Thrusters)
                {
                    thruster.Power = vertical;
                }
            }
        }
    }
}