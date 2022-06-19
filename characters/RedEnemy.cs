using Godot;
using Placeholder.characters;
using System;

public class RedEnemy : Area2D, ICharacter
{
    [Export]
    public int Attack { get; set; } = 5;
    [Export]
    public int MaxHealth { get; set; } = 50;
    public int Health { get; set; }

    public override void _Ready()
	{
        Health = MaxHealth;
	}

}
