using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    [Serializable]
    public struct MovementData : IComponentData
    {
        public float3 PreviousPosition;
        public quaternion PreviousRotation;

        public bool HasPreviousPosition;
        public bool HasPreviousRotation;

        public float3 Velocity;
        public float3 AngularVelocity;
        public quaternion RotationDelta;
    }
}