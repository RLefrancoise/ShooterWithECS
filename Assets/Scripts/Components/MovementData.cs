using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    [Serializable]
    public struct MovementData : IComponentData
    {
        public float3 previousPosition;
        public quaternion previousRotation;

        public bool hasPreviousPosition;
        public bool hasPreviousRotation;

        public float3 velocity;
        public float3 angularVelocity;
        public quaternion rotationDelta;
        public float3 rotationDeltaEuler;
    }
}