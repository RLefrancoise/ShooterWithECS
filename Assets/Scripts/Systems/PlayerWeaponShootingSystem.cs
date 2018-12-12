using Unity.Entities;
using UnityEngine;

namespace Systems
{
    public class PlayerWeaponShootingSystem : WeaponShootingSystem<PlayerWeaponShootingBarrier, Weapon>
    {
        [Inject] private PlayerWeaponShootingBarrier _barrier;

        protected override ComponentGroup Group { get; set; }
        protected override PlayerWeaponShootingBarrier Barrier => _barrier;
        protected override bool CanShoot => Input.GetButton("Fire1");
    }

    public class PlayerWeaponShootingBarrier : BarrierSystem { }
}
