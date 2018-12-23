using System;
using Unity.Entities;

[Serializable]
public struct GoStraightBehaviour : IComponentData
{
    public float Speed;
}

public class GoStraightBehaviourComponent : ComponentDataWrapper<GoStraightBehaviour>
{
}