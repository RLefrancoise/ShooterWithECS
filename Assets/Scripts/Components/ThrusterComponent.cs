using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ThrusterComponent : MonoBehaviour
    {
        public float OriginalStartSize;
        public float OriginalLifeTime;
        public Color OriginalStartColor;
        public float Power;
    }
}
