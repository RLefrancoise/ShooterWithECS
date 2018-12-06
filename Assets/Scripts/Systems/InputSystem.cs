using Unity.Entities;
using UnityEngine;

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
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var leftMouseButtonDown = Input.GetMouseButtonDown(0);
            var leftMouseButtonUp = Input.GetMouseButtonUp(0);
            
            foreach (var entity in GetEntities<Filter>())
            {
                entity.InputComponent.Horizontal = horizontal;
                entity.InputComponent.Vertical = vertical;
                entity.InputComponent.LeftMouseButtonDown = leftMouseButtonDown;
                entity.InputComponent.LeftMouseButtonUp = leftMouseButtonUp;

                if (leftMouseButtonDown)
                {
                    var currentTime = Time.time;
                    
                    //If last fire time was more than time between fire
                    if (currentTime - entity.Ship.LastFireTime >= entity.Ship.TimeBetweenFire)
                    {
                        entity.Ship.Fire = true;
                        entity.Ship.LastFireTime = currentTime;
                    }
                }
                else
                {
                    entity.Ship.Fire = false;
                }
            }
        }
    }
}