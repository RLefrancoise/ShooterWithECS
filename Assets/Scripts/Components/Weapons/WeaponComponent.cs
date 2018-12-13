using System;
using Unity.Entities;

public enum WeaponKind
{
    Player,
    Turret
}

[Serializable]
public struct Weapon : IComponentData
{
    public float FireSpeed;
    public float FireRate;
    public float BulletLifeTime;
    public WeaponKind Kind;
}

public class WeaponComponent : ComponentDataWrapper<Weapon>
{
}