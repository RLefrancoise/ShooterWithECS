using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

namespace Systems.Enemy
{
    public class GoStraightEnemyBehaviourSystem : JobComponentSystem
    {
        [Inject] private GoStraightEnemyBehaviourBarrier _barrier;
        private ComponentGroup _componentGroup;

        private struct FlagGoStraightBehaviourJob : IJobParallelFor
        {
            [ReadOnly] public ComponentDataArray<GoStraightBehaviour> GoStraightBehaviours;
            public EntityArray Entities;
            public EntityCommandBuffer.Concurrent EntityCommandBuffer;

            public void Execute(int index)
            {
                EntityCommandBuffer.AddSharedComponent(index, Entities[index], new MoveForward());
                EntityCommandBuffer.AddComponent(index, Entities[index], new MoveSpeed {Speed = GoStraightBehaviours[index].Speed});
            }
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new FlagGoStraightBehaviourJob
            {
                Entities = _componentGroup.GetEntityArray(),
                GoStraightBehaviours = _componentGroup.GetComponentDataArray<GoStraightBehaviour>(),
                EntityCommandBuffer = _barrier.CreateCommandBuffer().ToConcurrent()
            }.Schedule(_componentGroup.CalculateLength(), 64, inputDeps);
        }

        protected override void OnCreateManager()
        {
            _componentGroup = GetComponentGroup(
                ComponentType.ReadOnly<GoStraightBehaviour>(),
                ComponentType.Subtractive<MoveForward>());
        }
    }

    public class GoStraightEnemyBehaviourBarrier : BarrierSystem
    {
    }
}
