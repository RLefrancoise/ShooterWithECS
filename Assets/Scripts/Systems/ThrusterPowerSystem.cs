using Components;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class ThrusterPowerSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ThrusterComponent thruster) =>
            {
                var mainModule = thruster.GetComponent<ParticleSystem>().main;

                if (!thruster.IsInitialized)
                {
                    thruster.OriginalLifeTime = mainModule.startLifetime.constant;
                    thruster.OriginalStartSize = mainModule.startSize.constant;
                    thruster.OriginalStartColor = mainModule.startColor.color;
                    thruster.IsInitialized = true;
                }

                mainModule.startLifetime = Mathf.Lerp(0.0f, thruster.OriginalLifeTime, thruster.Power);
                mainModule.startSize = Mathf.Lerp(thruster.OriginalStartSize * 0.3f, thruster.OriginalStartSize,
                    thruster.Power);
                mainModule.startColor = Color.Lerp(thruster.MinColour, thruster.OriginalStartColor, thruster.Power);
            });
        }
    }
}
