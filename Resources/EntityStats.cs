using Godot;

[GlobalClass]
public partial class EntityStats : Resource
{
    [ExportGroup("Base Stats")]
    [Export] public string Name { get; set; } = "Entity";
    [Export] public int MaxHealth { get; set; } = 100;
    [Export] public int MovementSpeed { get; set; } = 100;
}