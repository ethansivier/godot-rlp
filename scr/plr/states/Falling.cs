using Godot;
using System.Collections.Generic;

public partial class Falling : PlayerState
{

    public override void enter(string previous, Dictionary<object, object> data)
    {
        if (player.can_jump)
        {
            jump();
            player.can_jump = false;
        }
    }

    public void jump()
    {
        player.velocity.Y = -player.jump_power;
        player.jump_count += 1;
        player.can_jump = false;
    }

    public void headhit()
    {
        if (player.IsOnCeiling())
        {
            player.velocity.Y = player.gravity_max;
        }
    }
    
    public override void process(float delta)
    {
        player.velocity.Y -= player.gravity_inc * (float) delta;
        player.jump_check();
        headhit();

        Run.manage_run(delta, player);
        player.Velocity = player.velocity;

        player.MoveAndSlide();

        if (player.IsOnFloor())
        {
            GD.Print("change");
            _change_state(IDLE);
        }
        else if (Input.IsActionJustPressed("jump") && (player.jump_count < player.max_jump))
        {
            jump();
        }
    }
}