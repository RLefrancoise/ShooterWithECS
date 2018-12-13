using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    public static EntityArchetype BulletArchetype;
        
    public static MeshInstanceRenderer BulletRenderer;
    public static MeshInstanceRenderer TurretBulletRenderer;

    [SerializeField]
    private MeshInstanceRenderer _bulletRenderer;
    private MeshInstanceRenderer _turretBulletRenderer;

    private void Awake()
    {
        BulletRenderer = _bulletRenderer;
        TurretBulletRenderer = _turretBulletRenderer;

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