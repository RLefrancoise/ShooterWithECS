using Components.Weapons;
using Unity.Entities;

namespace Systems
{
    /// <inheritdoc />
    /// <summary>
    /// Player weapon shooting system.
    /// </summary>
    public class PlayerWeaponShootingSystem : WeaponShootingSystem
    {
        protected override ComponentType[] AdditionalComponentTypes { get; } = { ComponentType.ReadOnly<PlayerWeapon>() };
    }
}
