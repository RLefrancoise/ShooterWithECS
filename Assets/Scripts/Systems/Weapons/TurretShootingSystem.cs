using Unity.Entities;

namespace Systems
{
    /*public class TurretShootingSystem : WeaponShootingSystem<TurretShootingBarrier>
    {
        [Inject] private TurretShootingBarrier _barrier;

        protected override ComponentGroup Group { get; set; }
        protected override TurretShootingBarrier Barrier => _barrier;
        protected override bool CanShoot => true;
        protected override ComponentType WeaponKind => ComponentType.ReadOnly<TurretWeapon>();
    }

    public class TurretShootingBarrier : BarrierSystem { }*/
}
