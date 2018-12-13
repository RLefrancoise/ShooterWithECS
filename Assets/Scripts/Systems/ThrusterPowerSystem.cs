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
                mainmodule.startLifetime = Mathf.Lerp(0.0f, thruster.OriginalLifeTime, thruster.Power);
                mainmodule.startSize = Mathf.Lerp(thruster.OriginalStartSize * 0.3f, thruster.OriginalStartSize, thruster.Power);
            }
        }
    }
}
