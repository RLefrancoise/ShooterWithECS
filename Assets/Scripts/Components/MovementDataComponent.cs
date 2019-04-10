using UnityEngine;

public class MovementDataComponent : MonoBehaviour
{
    public Vector3 PreviousPosition;
    public Quaternion PreviousRotation;

    [HideInInspector]
    public bool HasPreviousPosition;
    [HideInInspector]
    public bool HasPreviousRotation;

    public Vector3 Velocity;
    public Vector3 AngularVelocity;
    public Quaternion RotationDelta;
}