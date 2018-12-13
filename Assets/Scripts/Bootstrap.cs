using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public static EntityArchetype BulletArchetype;
        
    public static MeshInstanceRenderer BulletRenderer;
    public static MeshInstanceRenderer TurretBulletRenderer;

    public static Bounds LevelLimits;

    [SerializeField]
    private MeshInstanceRenderer _bulletRenderer;
    [SerializeField]
    private MeshInstanceRenderer _turretBulletRenderer;

    [SerializeField]
    private Bounds _levelLimits;

    private void Awake()
    {
        BulletRenderer = _bulletRenderer;
        TurretBulletRenderer = _turretBulletRenderer;
        LevelLimits = _levelLimits;

        BulletArchetype = World.Active.GetOrCreateManager<EntityManager>().CreateArchetype(
            ComponentType.Create<Bullet>(),
            ComponentType.Create<Position>(),
            ComponentType.Create<Rotation>(),
            ComponentType.Create<Scale>(),
            ComponentType.Create<MeshInstanceRenderer>(),
            ComponentType.Create<MoveForward>(),
            ComponentType.Create<MoveSpeed>());
    }
}