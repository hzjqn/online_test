using Godot;
using System;

public partial class MainScene : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GameManager.instance.SetGameSpace(this.GetNode("%GameSpace") as Node2D);
		GD.Print("MainScene ready");
	}
}
