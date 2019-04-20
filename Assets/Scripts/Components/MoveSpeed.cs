using System;
using Unity.Entities;

namespace Components
{
    [Serializable]
    public struct MoveSpeed : IComponentData
    {
        public float value;
    }
}