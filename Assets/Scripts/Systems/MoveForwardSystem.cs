using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    [UpdateAfter(typeof(CopyTransformFromGameObjectSystem))]
    public class MoveForwardSystem : JobComponentSystem
    {
        [BurstCompile]
        private struct MoveForwardJob : IJobParallelFor
        {
            public float DeltaTime;
            public ComponentDataArray<Position> Positions;
            [ReadOnly] public ComponentDataArray<Rotation> Rotations;
            [ReadOnly] public ComponentDataArray<MoveSpeed> MoveSpeeds;

            public void Execute(int index)
            {
                Positions[index] = new Position
                {
                    Value = Positions[index].Value + (MoveSpeeds[index].Speed * math.forward(Rotations[index].Value) * DeltaTime)
                };
            }
        }

        private ComponentGroup _componentGroup;
        
        protected override void OnCreateManager()
        {
            _componentGroup = GetComponentGroup(
                ComponentType.ReadOnly<Rotation>(),
                ComponentType.ReadOnly<MoveForward>(),
                ComponentType.ReadOnly<MoveSpeed>(),
                ComponentType.Create<Position>());
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            return new MoveForwardJob
            {
                DeltaTime = Time.deltaTime,
                Positions = _componentGroup.GetComponentDataArray<Position>(),
                Rotations = _componentGroup.GetComponentDataArray<Rotation>(),
                MoveSpeeds = _componentGroup.GetComponentDataArray<MoveSpeed>()
            }.Schedule(_componentGroup.CalculateLength(), 64, inputDeps);
        }
    }
}