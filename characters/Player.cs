using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export]
	private int speed = 75;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(float delta)
	{
		var direction = new Vector2();
		direction.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		direction.y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");	
		
		//# If input is digital, normalize it for diagonal movement
		if (Mathf.Abs(direction.x) == 1 && Mathf.Abs(direction.y) == 1)
		{
			direction = direction.Normalized();
		}
		
		//# Apply movement
		var movement = speed * direction * delta;
		MoveAndCollide(movement);
	}

}
