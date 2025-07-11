using Godot;

public partial class Player : CharacterBody3D
{
	public const float Speed = 15f;

	private const float RotationSpeed = 10f;
	private const float FullHopVelocity = 25.0f;
	private const float ShortHopVelocity = FullHopVelocity / 2f;
	private const float Gravity = 35.0f;
	private const float ShortHopMaxTime = 0.15f;
	private const float AirControlFactor = 0.6f;

	private float jumpTimer = 0.0f;
	private bool isJumping = false;

	private Camera3D camera;
	private Node3D model;
	private ShapeCast3D detector;
	private Label interactLabel;

	private Node3D holdPoint;
	private RigidBody3D heldItem = null;
	private Vector3 heldObjWorldScale;

	public override void _Ready()
	{
		camera = GetNode<Camera3D>("%Camera");
		model = GetNode<Node3D>("FwogSkin");
		detector = GetNode<ShapeCast3D>("InteractDetector");
		interactLabel = GetNode<Label>("CanvasLayer/BoxContainer/Label");
		holdPoint = GetNode<Node3D>("HoldPoint");
	}

	public override void _PhysicsProcess(double delta)
	{
		HandleMovement((float) delta);

		if (!GameState.IsTalking)
		{
			HandleInteract();
		}
	}

	private void HandleInteract()
	{
		if (heldItem != null)
		{
			HandleDrop();
		}
		else if (detector.IsColliding())
		{
			// Grab the closest item
			var item = detector.CollisionResult[0].As<Godot.Collections.Dictionary>();

			Node collider = item["collider"].As<Node>();
			if (collider != null)
			{
				if (collider.IsInGroup("Talkable"))
				{
					HandleTalkable(collider);
				}
				else if (collider.IsInGroup("Pickable"))
				{
					if (heldItem == null)
					{
						HandlePickable(collider as RigidBody3D);
					}
				}
			}
		}
		else
		{
			interactLabel.Visible = false;
		}
	}

	private void HandleMovement(float delta) {
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y -= Gravity * delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = FullHopVelocity;
			isJumping = true;
			jumpTimer = 0.0f;
		}

		if (isJumping && jumpTimer < ShortHopMaxTime)
		{
			jumpTimer += delta;

			if (Input.IsActionJustReleased("ui_accept") && jumpTimer <= ShortHopMaxTime)
			{
				velocity.Y = ShortHopVelocity;
			}
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if (inputDir != Vector2.Zero)
		{
			Vector3 camForward = camera.GlobalTransform.Basis.Z;
			Vector3 camRight = camera.GlobalTransform.Basis.X;

			// Flatten to ignore camera pitch
			camForward.Y = 0;
			camRight.Y = 0;

			camForward = camForward.Normalized();
			camRight = camRight.Normalized();

			Vector3 moveDir = (camForward * inputDir.Y + camRight * inputDir.X).Normalized();

			float rotation = Mathf.Atan2(moveDir.X, moveDir.Z);

			if (IsOnFloor())
			{
				velocity.X = moveDir.X * Speed;
				velocity.Z = moveDir.Z * Speed;

				model.Rotation = new Vector3(0, Mathf.LerpAngle(model.Rotation.Y, rotation, RotationSpeed * delta), 0);
			}
			else
			{
				Vector3 targetVelocity = moveDir * Speed;
				velocity.X = Mathf.MoveToward(velocity.X, targetVelocity.X, Speed * AirControlFactor * delta);
				velocity.Z = Mathf.MoveToward(velocity.Z, targetVelocity.Z, Speed * AirControlFactor * delta);

				model.Rotation = new Vector3(0, Mathf.LerpAngle(model.Rotation.Y, rotation, RotationSpeed * AirControlFactor * delta), 0);
			}

			FaceForward(detector);
			FaceForward(holdPoint, true);
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private void HandlePickable(RigidBody3D collider3D) {
		if (Input.IsActionJustPressed("interact"))
		{
			heldItem = collider3D;

			heldObjWorldScale = collider3D.Scale;

			collider3D.GetParent().RemoveChild(collider3D);
			holdPoint.AddChild(collider3D);
			detector.AddException(collider3D);

			collider3D.SetDeferred("freeze", true);
			if (collider3D != null)
			{
				collider3D.Position = Vector3.Zero;
				collider3D.Rotation = Vector3.Zero;
				collider3D.Scale = heldObjWorldScale / Scale;
			}
		}
		else
		{
			interactLabel.Visible = true;
			interactLabel.Text = "Pickup [E]";
		}
	}

	private void HandleDrop()
	{
		if (Input.IsActionJustPressed("interact"))
		{
			holdPoint.RemoveChild(heldItem);
			GetParent().AddChild(heldItem);

			heldItem.GlobalTransform = holdPoint.GlobalTransform;
			heldItem.Scale = heldObjWorldScale;

			heldItem.SetDeferred("freeze", false);
			detector.RemoveException(heldItem);
			heldItem = null;
		}
		else
		{
			interactLabel.Visible = true;
			interactLabel.Text = "Drop [E]";
		}
	}

	private void HandleTalkable(Node collider)
	{
		if (Input.IsActionJustPressed("interact"))
		{
			if (GameState.IsTalking == false)
			{
				// Handle talk
				interactLabel.Visible = false;
				collider.Call("Interact");
			}
		}
		else
		{
			interactLabel.Visible = true;
			interactLabel.Text = "Talk [E]";
		}
	}

	private void FaceForward(Node3D node, bool keepX = false)
	{
		Vector3 scale = node.Scale;

		float xRotation = keepX ? node.Rotation.X : 0.0f;

		Basis baseRotation = Basis.FromEuler(new Vector3(xRotation, model.Rotation.Y, 0));

		node.Basis = baseRotation;
		node.Scale = scale;
	}
}
