using System;
using Unity.Entities;

namespace Components
{
    [Serializable]
    public struct Power : IComponentData
    {
        public float Value;
    }
}