using Godot;
using System;
using System.Threading;
using System.Threading.Tasks;

public partial class Player : CharacterBody2D
{
    public float accel = 3000;
    public float decel = 2000;
    public int max_velo = 1000; // mathing seems to make it so that the max is actually this divided by two? maybe fix but also its probably ok

    public float gravity_max = 1000;
    public float gravity_inc = -10000;
    public float jump_power = 2000;

    public bool can_jump = false;
    public int jump_count = 0;
    public int max_jump = 1;

    public Vector2 velocity = Vector2.Zero;

    // test comment
    public float get_move_velo(double delta)
    {
        Vector2 velocity = Velocity; // Velocity is immutate and has to be set as a variable to return
        Vector2 new_velo = velocity;

        float x = Input.GetAxis("left", "right");
        float accel_speed = x * accel;
        float wish_speed = (max_velo * x) - velocity.X;
        float accel_inc = decel;

        if (Math.Abs(x) > 0 && (Math.Abs(wish_speed) > Math.Abs(velocity.X)))
        {
            new_velo.X = wish_speed;
            accel_inc = accel;
        }
        else
        {
            new_velo.X = 0;
        }
        velocity = velocity.MoveToward(new_velo, accel_inc * (float)delta);

        return velocity.X;
    }

    public bool is_moving()
    {
        if (Input.GetAxis("left", "right") == 0)
        {
            return false;
        }
        return true;
    }

    public bool is_jumping()
    {
        return Input.IsActionJustPressed("jump");
    }

    public async void jump_check()
    {
        if (is_jumping() && !can_jump)
        {
            can_jump = true;
            await Task.Delay(600);
            if (can_jump == true)
            {
                GD.Print("flip");
                can_jump = false;
            }
        }
    }
}