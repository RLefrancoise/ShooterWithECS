using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

namespace Systems
{
    public abstract class SetWeaponKindSystem<TWeaponKind, TBarrier> : JobComponentSystem
        where TWeaponKind : struct, IComponentData
        where TBarrier : BarrierSystem
    {
        private ComponentGroup _group;
        protected abstract TBarrier Barrier { get; }

        /// <summary>
        /// Weapon kind
        /// </summary>
        protected abstract WeaponKind WeaponKind { get; }

        private struct SetWeaponKindJob : IJobParallelFor
        {
            [ReadOnly] public EntityArray Entities;
            [ReadOnly] public ComponentDataArray<Weapon> Weapons;
            public EntityCommandBuffer.Concurrent EntityCommandBuffer;
            public WeaponKind WeaponKind;

            public void Execute(int index)
            {
                if (Weapons[index].Kind != WeaponKind) return;
                EntityCommandBuffer.AddComponent(index, Entities[index], new TWeaponKind());
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new SetWeaponKindJob
            {
                Entities = _group.GetEntityArray(),
                Weapons = _group.GetComponentDataArray<Weapon>(),
                EntityCommandBuffer = Barrier.CreateCommandBuffer().ToConcurrent(),
                WeaponKind = WeaponKind
            }.Schedule(_group.CalculateLength(), 64, inputDeps);
        }

        protected override void OnCreateManager()
        {
            _group = GetComponentGroup(
                ComponentType.ReadOnly<Weapon>(),
                ComponentType.Subtractive<TWeaponKind>());
        }
    }
}
