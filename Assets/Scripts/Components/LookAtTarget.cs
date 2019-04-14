using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Components
{
    [Serializable]
    public struct LookAtTarget : IComponentData
    {
        public enum Axis
        {
            X, Y, Z, MinusX, MinusY, MinusZ
        }

        public Axis LookAtAxis;
        public bool KeepWorldUp;
        public float3 TargetWorldPosition;
    }
}
