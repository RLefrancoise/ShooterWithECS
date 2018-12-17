using UnityEngine;

public class MovementDataComponent : MonoBehaviour
{
    public Vector3 PreviousPosition;
    public Quaternion PreviousRotation;

    public bool HasPreviousPosition;
    public bool HasPreviousRotation;

    public Vector3 Velocity;
    public Vector3 AngularVelocity;
}