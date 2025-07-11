using Godot;
using System;

public partial class CameraPivot : Node3D
{
	public float Sensitivity = 0.2f;
	public float MinPitch = -30f;
	public float MaxPitch = 60f;

	private Node3D pivot;
	private Camera3D camera;
	private float pitch = 0f;

	private float DefaultCameraDistance;
	private float CollisionPadding = 0.5f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		pivot = GetNode<Node3D>("%CameraPivot");
		camera = GetNode<Camera3D>("%Camera");

		DefaultCameraDistance = (camera.GlobalTransform.Origin - pivot.GlobalTransform.Origin).Length();

		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseMotion && Input.MouseMode == Input.MouseModeEnum.Captured)
		{
        	pivot.RotateY(-Mathf.DegToRad(mouseMotion.Relative.X * Sensitivity));

			pitch -= mouseMotion.Relative.Y * Sensitivity;
			pitch = Mathf.Clamp(pitch, MinPitch, MaxPitch);
			pivot.RotationDegrees = new Vector3(pitch, pivot.RotationDegrees.Y, pivot.RotationDegrees.Z);
		}

		if (Input.IsActionJustPressed("ui_cancel")) // "ui_cancel" is bound to Escape by default
		{
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}

		if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed && mouseButton.ButtonIndex == MouseButton.Left)
		{
			Input.MouseMode = Input.MouseModeEnum.Captured;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector3 pivotOrigin = pivot.GlobalTransform.Origin;
		Vector3 orbitDirection = -pivot.GlobalTransform.Basis.Z.Normalized(); // camera is behind pivot
		Vector3 desiredCameraPos = pivotOrigin + orbitDirection * DefaultCameraDistance;

		var spaceState = GetWorld3D().DirectSpaceState;
		var result = spaceState.IntersectRay(new PhysicsRayQueryParameters3D
		{
			From = pivotOrigin,
			To = desiredCameraPos,
			CollisionMask = 1,
			CollideWithBodies = true,
			CollideWithAreas = false
		});

		Vector3 finalCameraPos = desiredCameraPos;

		if (result.Count > 0)
		{
			Vector3 hitPos = (Vector3)result["position"];
			finalCameraPos = hitPos + (pivotOrigin - hitPos).Normalized() * CollisionPadding;
		}

		camera.GlobalTransform = new Transform3D(
			camera.GlobalTransform.Basis, // keep rotation as-is
			finalCameraPos
		);
	}
}
