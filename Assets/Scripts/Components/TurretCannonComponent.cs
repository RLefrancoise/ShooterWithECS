using System;
using Unity.Entities;

[Serializable]
public struct TurretCannon : IComponentData
{
    public float FireSpeed;
    public float FireRate;
    public float BulletLifeTime;
}


public class TurretCannonComponent : ComponentDataWrapper<TurretCannon>
{
}

