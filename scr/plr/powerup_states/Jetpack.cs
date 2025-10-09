using System.Collections.Generic;
using Godot; 

public partial class Jetpack : PlayerState
{
	public List<string> enter_states = new List<string> { "Falling" };
	public int priority = 4;

	public static float max_power = 50;
	public float power_left = max_power;

	public override void process(float delta)
	{
		if (Input.IsActionPressed("jump") && power_left > 0)
		{
			player.velocity.Y += 100;
			power_left -= 1 * delta;
		}
	}
}
