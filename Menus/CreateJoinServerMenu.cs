using Godot;
using System;

public partial class CreateJoinServerMenu : Control
{
	Button JoinButton = null;
	Button CreateButton = null;
	MarginContainer ConnectingLabel = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MultiplayerConnectionManager.instance.ConnectionSucceeded += OnConnectionSucceeded;
		MultiplayerConnectionManager.instance.ConnectionFailed += OnConnectionFailed;
		MultiplayerConnectionManager.instance.ServerDisconnected += OnServerDisconnected;
		JoinButton = GetNode<Button>("%JoinButton");
		CreateButton = GetNode<Button>("%CreateButton");
		ConnectingLabel = GetNode<MarginContainer>("%ConnectingLabel");

		JoinButton.Pressed += OnJoinButtonPressed;
		CreateButton.Pressed += OnCreateButtonPressed;
	}

	private void OnJoinButtonPressed()
	{
		ConnectingLabel.Show();
		MultiplayerConnectionManager.instance.JoinServer();
	}

	private void OnCreateButtonPressed()
	{
		ConnectingLabel.Show();
		MultiplayerConnectionManager.instance.CreateServer();
	}

	private void OnConnectionSucceeded()
	{
		ConnectingLabel.Hide();
		Hide();
	}

	private void OnConnectionFailed()
	{
		ConnectingLabel.Hide();
		Show();
		GD.Print("Connection failed");
	}

	private void OnServerDisconnected()
	{
		ConnectingLabel.Hide();
		Show();
		GD.Print("Server disconnected");
	}
}
