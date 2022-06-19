using Godot;
using Godot.Collections;
using Placeholder.characters;
using System;

public class Player : Area2D, ICharacter
{
	[Export]
	private int Speed = 3;
	[Export]
	private int TileSize = 64;
	private Dictionary Inputs = new Dictionary();
	[Export]
	public int Attack { get; set; } = 10;
	[Export]
	public int MaxHealth { get; set; } = 150;
	public int Health { get; set; }

	//onready
	private RayCast2D Ray;
	private Tween Tween;
	private ProgressBar ProgressBar;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Inputs.Add("right", Vector2.Right);
		Inputs.Add("left", Vector2.Left);
		Inputs.Add("up", Vector2.Up);
		Inputs.Add("down", Vector2.Down);
		Position = Position.Snapped(Vector2.One * TileSize);
		Position += Vector2.One * TileSize / 2;
		Ray = GetNode<RayCast2D>("RayCast2D");
		Tween = GetNode<Tween>("Tween");
		ProgressBar = GetNode<ProgressBar>("ProgressBar");
		Health = MaxHealth;
		ProgressBar.MaxValue = MaxHealth;
		ProgressBar.Value = Health;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (Tween.IsActive())
		{
			return;
		}
		foreach(string dir in Inputs.Keys)
		{
			if (@event.IsActionPressed(dir))
			{
				Move(dir);
			}
		}
	}

	public void Move(string dir)
	{
		Ray.CastTo = (Vector2)Inputs[dir] * TileSize;
		Ray.ForceRaycastUpdate();
		if (!Ray.IsColliding())
		{
			//Position += (Vector2)Inputs[dir] * TileSize;
			MoveTween((Vector2)Inputs[dir]);
		}
	}

	public void MoveTween(Vector2 dir)
	{
		Tween.InterpolateProperty(
			this, 
			"position", 
			Position, 
			Position + dir * TileSize, 
			(float)1.0 / Speed, 
			Tween.TransitionType.Sine, 
			Tween.EaseType.InOut
			);
		Tween.Start();
		TakeDamage(5);
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;
		UpdateHealthBar();
	}
	
	public void UpdateHealthBar()
	{
		ProgressBar.MaxValue = MaxHealth;
		ProgressBar.Value = Health;
	}


	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}
