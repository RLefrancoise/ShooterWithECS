using Unity.Entities;

namespace Systems
{
    public class FollowTargetSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((FollowTargetComponent followTarget) =>
            {
                var position = followTarget.transform.position;

                if (!followTarget.FreezeX) position.x = followTarget.Target.position.x;
                if (!followTarget.FreezeY) position.y = followTarget.Target.position.y;
                if (!followTarget.FreezeZ) position.z = followTarget.Target.position.z;

                followTarget.transform.position = position + followTarget.Offset;
            });
        }
    }
}
