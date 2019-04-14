using Unity.Entities;

namespace Components
{
    public struct Ship : IComponentData
    {
        public float Life;
        public float Power;
        public float Speed;
        public float TiltAngle;
        /*public ThrusterComponent[] ForwardThrusters;
        public ThrusterComponent[] BackThrusters;*/
    }
}