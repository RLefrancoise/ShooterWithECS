using Components;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class ApplyShipThrusterPowerSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            /*Entities.ForEach((Ship ship, MovementDataComponent movementData) =>
            {
                var powerRatio = movementData.Velocity.z / ship.Speed;
                powerRatio *= Vector3.SignedAngle(ship.transform.forward, Vector3.forward, Vector3.up) >= 180f
                    ? -1f
                    : 1f;
                if (powerRatio > 1f) powerRatio = 1f;
                else if (powerRatio < -1f) powerRatio = -1f;

                foreach (var thruster in ship.ForwardThrusters)
                {
                    thruster.Power = powerRatio > 0f ? powerRatio : 0f;
                }

                foreach (var thruster in ship.BackThrusters)
                {
                    thruster.Power = powerRatio < 0f ? Mathf.Abs(powerRatio) : 0f;
                }
            });*/
        }
    }
}
