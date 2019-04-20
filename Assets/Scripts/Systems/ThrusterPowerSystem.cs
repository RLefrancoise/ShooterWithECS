using Components;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class ThrusterPowerSystem : ComponentSystem
    {   
        protected override void OnUpdate()
        {
            Entities.ForEach((ref Thruster thruster, ParticleSystem particleSystem) =>
            {
                var mainModule = particleSystem.main;

                if (!thruster.isInitialized)
                {
                    thruster.originalLifeTime = mainModule.startLifetime.constant;
                    thruster.originalStartSize = mainModule.startSize.constant;
                    thruster.originalStartColor = mainModule.startColor.color.ToFloat4();
                    thruster.isInitialized = true;
                }

                mainModule.startLifetime = Mathf.Lerp(0.0f, thruster.originalLifeTime, thruster.power);
                mainModule.startSize = Mathf.Lerp(thruster.originalStartSize * 0.3f, thruster.originalStartSize,
                    thruster.power);
                mainModule.startColor = Color.Lerp(ColorUtils.FromFloat4(thruster.minColour), ColorUtils.FromFloat4(thruster.originalStartColor), thruster.power);
            });
        }
    }
}
