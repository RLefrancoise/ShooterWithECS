using System;
using Unity.Entities;

namespace Components
{
    [Serializable]
    public struct Ship : IComponentData
    {
        public float life;
        public float power;
        public float speed;
        public float tiltAngle;
    }
}