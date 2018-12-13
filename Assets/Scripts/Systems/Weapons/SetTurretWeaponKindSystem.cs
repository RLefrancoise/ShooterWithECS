using Unity.Entities;

namespace Systems
{
    public class SetTurretWeaponKindSystem : SetWeaponKindSystem<TurretWeapon, SetTurretWeaponKindBarrier>
    {
        [Inject] private SetTurretWeaponKindBarrier _barrier;

        protected override SetTurretWeaponKindBarrier Barrier => _barrier;
        protected override WeaponKind WeaponKind => WeaponKind.Turret;
    }

    public class SetTurretWeaponKindBarrier : BarrierSystem
    {
    }
}
