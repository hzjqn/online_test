using Godot;
using System;
[Tool]
public partial class PlayerControllerComponent : Node2D
{
	BaseEntity OwnerEntity = null;
	Vector2? MovementDirection = null;
	Vector2? MovementPosition = null;

	[Export]
	public bool Enabled = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BaseEntity parent = GetParent<BaseEntity>();

		if (parent == null)
		{
			GD.Print(GetParent());
			GD.PrintErr("PlayerControllerComponent must be a child of BaseEntity");
			return;
		}
		OwnerEntity = parent;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Engine.IsEditorHint()) return;
		if (OwnerEntity == null) return;

		Vector2 input = new Vector2(0, 0);

		if (Input.IsActionPressed("ui_right"))
		{
			input.X += 1;
		}
		if (Input.IsActionPressed("ui_left"))
		{
			input.X -= 1;
		}
		if (Input.IsActionPressed("ui_down"))
		{
			input.Y += 1;
		}
		if (Input.IsActionPressed("ui_up"))
		{
			input.Y -= 1;
		}

		if (input.Length() > 0)
		{
			input = input.Normalized();
			SetMovementDirection(input);
			OwnerEntity.Move(input, (float)delta);
		}
	}

	public virtual void SetMovementDirection(Vector2 direction)
	{
		MovementDirection = direction;
	}

	public virtual void SetMovementPosition(Vector2 position)
	{
		MovementPosition = position;
	}
}
