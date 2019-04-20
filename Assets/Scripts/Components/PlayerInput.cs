using System;
using Unity.Entities;

[Serializable]
public struct PlayerInput : IComponentData
{
	public float horizontal;
	public float vertical;
}
