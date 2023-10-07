using Godot;
using System;

public partial class BaseEntity : Node2D
{
    public bool IsPlayer = false;
    public bool Vulnerable = false;
    public bool IsAlive = true;
    public bool SyncProperties = false;

    public MultiplayerSynchronizer Synchronizer = null;
    public BaseEntity OwnerEntity = null;

    [Export]
    public EntityStats Stats = new EntityStats();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void Move(Vector2 direction, float delta)
    {
        Position += delta * direction * Stats.MovementSpeed;
    }
}
