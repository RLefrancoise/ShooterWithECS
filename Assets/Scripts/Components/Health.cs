using System;
using Unity.Entities;

namespace Components
{
    [Serializable]
    public struct Health : IComponentData
    {
        public float Value;
    }
}