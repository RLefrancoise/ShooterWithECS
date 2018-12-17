using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class ApplyShipThrusterPowerSystem : ComponentSystem
    {
        private struct Filter
        {
            public Ship Ship;
            public MovementDataComponent MovementData;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Filter>())
            {
                var powerRatio = entity.MovementData.Velocity.z / entity.Ship.Speed;
                if (powerRatio > 1f) powerRatio = 1f;
                else if (powerRatio < -1f) powerRatio = -1f;

                foreach (var thruster in entity.Ship.ForwardThrusters)
                {
                    thruster.Power = powerRatio > 0f ? powerRatio : 0f;
                }

                foreach (var thruster in entity.Ship.BackThrusters)
                {
                    thruster.Power = powerRatio < 0f ? Mathf.Abs(powerRatio) : 0f;
                }
            }
        }
    }
}
