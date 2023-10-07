using Godot;
using System;

public partial class MultiplayerConnectionManager : Node
{
	[Signal] public delegate void ConnectionSucceededEventHandler();
	[Signal] public delegate void ServerDisconnectedEventHandler();
	[Signal] public delegate void ConnectionFailedEventHandler();

	ENetMultiplayerPeer Peer = new ENetMultiplayerPeer();
	const int PORT = 4242;
	const string HOST = "localhost";
	const int MAX_CLIENTS = 32;

	public static MultiplayerConnectionManager instance { get; private set; }

	public override void _Ready()
	{
		instance = this;
		Multiplayer.PeerConnected += OnPeerConnected;
		Multiplayer.PeerDisconnected += OnPeerDisconnected;
		Multiplayer.ConnectedToServer += OnConnectionSucceeded;
		Multiplayer.ServerDisconnected += OnServerDisconnected;
		Multiplayer.ConnectionFailed += OnConnectionFailed;
	}

	[Rpc]
	public void SpawnPlayerObject()
	{
		if (GameManager.instance.GameSpace != null)
		{
			var playerObject = new PlayerObject();
			GameManager.instance.GameSpace.AddChild(playerObject);
		}
	}

	public void JoinServer()
	{
		GD.Print("Joining server");
		Error error = Peer.CreateClient(HOST, PORT);
		GD.Print(error);
		UpdateMultiplayerPeer();
	}

	void UpdateMultiplayerPeer()
	{
		GetTree().GetMultiplayer().MultiplayerPeer = Peer;
	}

	public void CreateServer()
	{
		GD.Print("Creating server");
		Error error = Peer.CreateServer(PORT, MAX_CLIENTS);
		GD.Print(error);
		UpdateMultiplayerPeer();
	}

	public void OnPeerConnected(long _PeerId)
	{
		if (Multiplayer.IsServer())
		{
			PackedScene playerObject = (PackedScene)ResourceLoader.Load("res://Objects/PlayerObject/PlayerObject.tscn");
			var playerObjectInstance = (PlayerObject)playerObject.Instantiate();
			playerObjectInstance.Name = _PeerId.ToString();
			GameManager.instance.GameSpace.AddChild(playerObjectInstance);
		}
	}

	public void OnPeerDisconnected(long _PeerId)
	{
		if (Multiplayer.IsServer())
		{
			var playerObject = (PlayerObject)GameManager.instance.GameSpace.GetNode(_PeerId.ToString());
			playerObject.QueueFree();
		}
	}

	public void OnConnectionSucceeded()
	{
		GD.Print("Connection succesful");
		EmitSignal(nameof(ConnectionSucceededEventHandler));
	}

	public void OnServerDisconnected()
	{
		GD.Print("Server disconnected");
		EmitSignal(nameof(ServerDisconnectedEventHandler));
	}

	public void OnConnectionFailed()
	{
		GD.Print("Connection failed");
		EmitSignal(nameof(ConnectionFailedEventHandler));
	}
}
