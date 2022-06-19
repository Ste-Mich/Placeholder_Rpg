using Godot;
using System;

public class combat : Node2D
{
	public Player MainPlayer { get; set; }
	public Player EnemyPlayer { get; set; }
	public bool turn = true;
	public override void _Ready()
	{
		MainPlayer = GetNode<Position2D>("PositionPlayer").GetNode<Player>("Player1");
		EnemyPlayer = GetNode<Position2D>("PositionEnemy").GetNode<Player>("Player2");
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("turn"))
		{
			if (turn)
			{
				EnemyPlayer.TakeDamage(MainPlayer.Attack);
			}
			else
			{
				MainPlayer.TakeDamage(EnemyPlayer.Attack);
			}
			turn = !turn;
		}
	}

	private void _on_AttackButton_pressed()
	{
		if (turn)
		{
			EnemyPlayer.TakeDamage(MainPlayer.Attack);
		}
		else
		{
			MainPlayer.TakeDamage(EnemyPlayer.Attack);
		}
		turn = !turn;
	}

	private void _on_SkipButton_pressed()
	{
		turn = !turn;
	}
}
