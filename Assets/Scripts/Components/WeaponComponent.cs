using System;
using Unity.Entities;

[Serializable]
public struct Weapon : IComponentData
{
    public float FireSpeed;
    public float FireRate;
    public float BulletLifeTime;
}

public class WeaponComponent : ComponentDataWrapper<Weapon>
{
}