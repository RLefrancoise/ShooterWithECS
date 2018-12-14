using System;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[Serializable]
public struct MovementData : IComponentData
{
    public Position PreviousPosition;
    public Rotation PreviousRotation;

    public int HasPreviousPosition;
    public int HasPreviousRotation;

    public float3 Velocity;
    public float3 AngularVelocity;
}

public class MovementDataComponent : ComponentDataWrapper<MovementData>
{
}

