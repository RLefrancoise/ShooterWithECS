using System;
using Components;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float Life;
    public float Power;
    public float Speed;
    public float TiltAngle;
    public ThrusterComponent[] ForwardThrusters;
    public ThrusterComponent[] BackThrusters;
}