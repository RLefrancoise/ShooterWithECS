using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    [Serializable]
    public struct ThrusterComponent : IComponentData
    {
        public bool IsInitialized;

        public float OriginalStartSize;
        public float OriginalLifeTime;
        public float4 OriginalStartColor;

        public float4 MinColour;
        public float Power;
    }
}
