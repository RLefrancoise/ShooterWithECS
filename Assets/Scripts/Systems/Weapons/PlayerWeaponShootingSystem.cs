using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class PlayerWeaponShootingSystem : WeaponShootingSystem<PlayerWeaponShootingBarrier>
    {
        [Inject] private PlayerWeaponShootingBarrier _barrier;

        protected override ComponentGroup Group { get; set; }
        protected override PlayerWeaponShootingBarrier Barrier => _barrier;
        protected override bool CanShoot => Input.GetButton("Fire1");
        protected override ComponentType WeaponKind => ComponentType.ReadOnly<PlayerWeapon>();
    }

    public class PlayerWeaponShootingBarrier : BarrierSystem { }
}
