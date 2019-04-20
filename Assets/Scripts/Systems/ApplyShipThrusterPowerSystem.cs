using Components;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class ApplyShipThrusterPowerSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref Thruster thruster, ref MovementData movementData) =>
            {
                var powerRatio = movementData.velocity.z / thruster.maxPower;
                /*powerRatio *= Vector3.SignedAngle(ship.transform.forward, Vector3.forward, Vector3.up) >= 180f
                    ? -1f
                    : 1f;*/
                if (powerRatio > 1f) powerRatio = 1f;
                else if (powerRatio < -1f) powerRatio = -1f;

                thruster.power = powerRatio;

                /*for(var i = 0 ; i < ship.ForwardThrusters.Length ; ++i)
                {
                    ship.ForwardThrusters[i].Power = powerRatio > 0f ? powerRatio : 0f;
                }

                for(var i = 0 ; i < ship.BackThrusters.Length ; ++i)
                {
                    ship.BackThrusters[i].Power = powerRatio < 0f ? Mathf.Abs(powerRatio) : 0f;
                }*/
            });
        }
    }
}
