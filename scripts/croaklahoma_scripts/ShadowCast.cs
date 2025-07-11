using Godot;
using System;

public partial class ShadowCast : RayCast3D
{
	[Export]
	public Decal Shadow;

	[Export]
	public float MaxFadeDistance = 15.0f;

	private float initialAlpha;

	public override void _Ready()
	{
		initialAlpha = Shadow.Modulate.A;
	}

	public override void _PhysicsProcess(double delta)
	{
		Color modulate = Shadow.Modulate;

		if (IsColliding())
		{
			Vector3 collisionPoint = GetCollisionPoint();
			float distance = GlobalPosition.DistanceTo(collisionPoint);

			float t = Mathf.Clamp(distance / MaxFadeDistance, 0f, 1f);
			modulate.A = Mathf.Lerp(initialAlpha, 0f, t);

			Shadow.GlobalPosition = collisionPoint;
		}
		else
		{
			modulate.A = 0f;
		}

		Shadow.Modulate = modulate;
	}
}
