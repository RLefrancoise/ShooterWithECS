using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ThrusterComponent : MonoBehaviour
    {
        [HideInInspector]
        public bool IsInitialized;

        public float OriginalStartSize;
        public float OriginalLifeTime;
        public Color OriginalStartColor;

        public Color MinColour;
        public float Power;
    }
}
