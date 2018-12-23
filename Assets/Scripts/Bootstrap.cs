using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    //Archetypes
    public static EntityArchetype BulletArchetype;

    //Level
    [SerializeField]
    private Bounds _levelLimits;
    public static Bounds LevelLimits;

    //Bullets
    [SerializeField]
    private BulletData _playerBulletData;
    [SerializeField]
    private BulletData _turretBulletData;

    public static BulletData PlayerBulletData;
    public static BulletData TurretBulletData;

    private void Awake()
    {
        LevelLimits = _levelLimits;

        BulletArchetype = World.Active.GetOrCreateManager<EntityManager>().CreateArchetype(
            ComponentType.Create<Bullet>(),
            ComponentType.Create<Position>(),
            ComponentType.Create<Rotation>(),
            ComponentType.Create<Scale>(),
            ComponentType.Create<MeshInstanceRenderer>(),
            ComponentType.Create<MoveForward>(),
            ComponentType.Create<MoveSpeed>());

        //Bullets
        PlayerBulletData = _playerBulletData;
        TurretBulletData = _turretBulletData;
    }
}