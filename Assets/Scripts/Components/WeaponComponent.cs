using System;
using Unity.Entities;
using Unity.Rendering;

[Serializable]
public struct Weapon : IComponentData
{
    public float FireSpeed;
    public float FireRate;
    public float BulletLifeTime;
    //public MeshInstanceRenderer BulletRenderer;
}

public class WeaponComponent : ComponentDataWrapper<Weapon>
{
}