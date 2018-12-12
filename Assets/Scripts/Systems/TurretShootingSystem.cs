using Unity.Entities;

namespace Systems
{
    public class TurretShootingSystem : WeaponShootingSystem<TurretShootingBarrier, TurretCannon>
    {
        [Inject] private TurretShootingBarrier _barrier;

        protected override ComponentGroup Group { get; set; }
        protected override TurretShootingBarrier Barrier => _barrier;
        protected override bool CanShoot => true;
    }

    public class TurretShootingBarrier : BarrierSystem { }
}
