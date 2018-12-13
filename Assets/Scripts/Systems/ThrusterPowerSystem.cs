using Components;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class ThrusterPowerSystem : ComponentSystem
    {
        private struct Filter
        {
            public ThrusterComponent Thruster;
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Filter>())
            {
                var thruster = entity.Thruster;
                ParticleSystem.MainModule mainmodule = thruster.GetComponent<ParticleSystem>().main;

                if (!thruster.IsInitialized)
                {
                    thruster.OriginalLifeTime = mainmodule.startLifetime.constant;
                    thruster.OriginalStartSize = mainmodule.startSize.constant;
                    thruster.OriginalStartColor = mainmodule.startColor.color;
                    thruster.IsInitialized = true;
                }

                mainmodule.startLifetime = Mathf.Lerp(0.0f, thruster.OriginalLifeTime, thruster.Power);
                mainmodule.startSize = Mathf.Lerp(thruster.OriginalStartSize * 0.3f, thruster.OriginalStartSize, thruster.Power);
                mainmodule.startColor = Color.Lerp(thruster.MinColour, thruster.OriginalStartColor, thruster.Power);
            }
        }
    }
}
