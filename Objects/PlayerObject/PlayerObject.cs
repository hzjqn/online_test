using Godot;
using System;

public partial class PlayerObject : BaseEntity
{
	public PlayerControllerComponent PlayerController = null;

	public override void _EnterTree()
	{
		base._EnterTree();
		Synchronizer = GetNode<MultiplayerSynchronizer>("MultiplayerSynchronizer");
		Synchronizer.SetMultiplayerAuthority(int.Parse(Name));
	}

	public override void _Ready()
	{
		base._Ready();

		PlayerController = GetNode<PlayerControllerComponent>("PlayerControllerComponent");

		if (IsPlayer)
		{
			PlayerController.Enabled = true;
		}
	}
}
