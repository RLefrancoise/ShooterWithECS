using UnityEngine;

namespace Components
{
    public class LookAtTargetComponent : MonoBehaviour
    {
        public enum Axis
        {
            X, Y, Z, MinusX, MinusY, MinusZ
        }

        public Axis LookAtAxis;
        public bool KeepWorldUp;
        public Transform Target;
    }
}
