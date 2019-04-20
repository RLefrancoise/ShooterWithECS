using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct FollowTarget : IComponentData
    {
        public float3 targetPosition;
        public quaternion targetRotation;
        
        public bool freezeX;
        public bool freezeY;
        public bool freezeZ;

        public float3 offset;
    }
}