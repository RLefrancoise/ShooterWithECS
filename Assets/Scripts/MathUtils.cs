using Unity.Mathematics;
using UnityEngine;

public static class MathUtils
{
    public static Quaternion ToStandardQuaternion(this quaternion quat)
    {
        return new Quaternion(quat.value.x, quat.value.y, quat.value.z, quat.value.w);
    }
}