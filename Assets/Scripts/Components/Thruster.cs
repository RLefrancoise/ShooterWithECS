using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    [Serializable]
    public struct Thruster : IComponentData
    {
        public bool isInitialized;

        public float originalStartSize;
        public float originalLifeTime;
        public float4 originalStartColor;

        public float4 minColour;
        public float power;
        public float maxPower;
    }
}
