using Godot;
using System;

public partial class GameManager : Node
{
	public Node2D GameSpace = null;

	public static GameManager instance { get; private set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		instance = this;
		GD.Print("GameManager ready");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetGameSpace(Node2D gameSpace)
	{
		GameSpace = gameSpace;
	}
}
