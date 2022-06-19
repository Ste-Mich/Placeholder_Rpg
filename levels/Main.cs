using Godot;
using System;

public class Main : Node2D
{
	public Node2D CombatArena { get; set; }
	public Node2D Island { get; set; }

	public override void _Ready()
	{
		CombatArena = GetNode<Node2D>("CombatArena");
		Island = GetNode<Node2D>("Island");
		CombatArena.PauseMode = PauseModeEnum.Stop;
		CombatArena.Visible = false;
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("switch"))
		{
			SwitchCombat();
		}
	}

	public void SwitchCombat()
    {
        if (Island.Visible)
		{
			FreezeOverworld(true);
			FreezeCombat(false);
		}
        else
		{
			FreezeOverworld(false);
			FreezeCombat(true);
		}
    }

	public void FreezeOverworld(bool freeze)
	{
		if (freeze)
		{
			Island.PauseMode = PauseModeEnum.Stop;
			Island.Visible = false;
		}
		else
		{
			Island.PauseMode = PauseModeEnum.Inherit;
			Island.Visible = true;
		}
	}

	public void FreezeCombat(bool freeze)
    {
        if (freeze)
		{
			CombatArena.PauseMode = PauseModeEnum.Stop;
			CombatArena.Visible = false;
		}
        else
        {
			CombatArena.PauseMode = PauseModeEnum.Inherit;
			CombatArena.Visible = true;
		}
    }
}
