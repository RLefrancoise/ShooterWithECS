using System;
using Unity.Entities;

public enum WeaponKind
{
    Player,
    Turret,
    EnemyShip
}

[Serializable]
public struct Weapon : IComponentData
{
    public float FireSpeed;
    public float FireRate;
    public float BulletLifeTime;
    public float Range;
    public WeaponKind Kind;
}

public class WeaponComponent : ComponentDataWrapper<Weapon>
{
}