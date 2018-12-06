using System;
using Unity.Entities;

[Serializable]
public struct Bullet : IComponentData
{
    public float LifeTime;
}

public class BulletComponent : ComponentDataWrapper<Bullet>
{
}