using Components.Weapons;
using Unity.Entities;
using Unity.Jobs;
using UnityStandardAssets.CrossPlatformInput;

namespace Systems
{
    /// <summary>
    /// Player weapon is firing when fire button is pressed
    /// </summary>
    public class FirePlayerWeaponOnClickSystem : JobComponentSystem
    {
        private struct FirePlayerWeaponOnClickJob : IJobChunk
        {
            public bool IsFireButtonPressed;
            public ArchetypeChunkComponentType<Weapon> Weapons;
            
            public void Execute(ArchetypeChunk chunk, int chunkIndex, int firstEntityIndex)
            {
                var chunkWeapons = chunk.GetNativeArray(Weapons);

                for (var i = 0; i < chunk.Count; ++i)
                {
                    var weapon = chunkWeapons[i];
                    weapon.canFire = IsFireButtonPressed;
                    chunkWeapons[i] = weapon;
                }
            }
        }

        private EntityQuery _query;

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            _query = GetEntityQuery(ComponentType.ReadWrite<Weapon>(), ComponentType.ReadOnly<PlayerWeapon>());
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new FirePlayerWeaponOnClickJob
            {
                IsFireButtonPressed = CrossPlatformInputManager.GetButton("Fire1"),
                Weapons = GetArchetypeChunkComponentType<Weapon>()
            }.Schedule(_query, inputDeps);
        }
    }
}