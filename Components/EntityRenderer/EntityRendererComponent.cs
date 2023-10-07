using Godot;
using System;

[Tool]
public partial class EntityRendererComponent : Node2D
{
    [Export] Color color = new Color(1, 0, 0);
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        QueueRedraw();
    }

    public override void _Draw()
    {
        base._Draw();
        DrawCircle(new Vector2(0, 0), 10, color);
    }
}