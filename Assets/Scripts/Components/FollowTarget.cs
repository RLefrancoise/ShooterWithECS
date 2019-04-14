using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct FollowTarget : IComponentData
    {
        public float3 TargetPosition;
        public quaternion TargetRotation;
        
        public bool FreezeX;
        public bool FreezeY;
        public bool FreezeZ;

        public float3 Offset;
    }
}