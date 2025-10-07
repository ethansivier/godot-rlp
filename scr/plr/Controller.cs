using Godot;
using System;
/*
UNUSUED, CONVERTING INTO A STATE MANAGER FOR MORE CONTROL
*/
public partial class Controller : CharacterBody2D
{
    float accel = 3000;
    float decel = 2000;
    int max_velo = 1000; // mathing seems to make it so that the max is actually this divided by two? maybe fix but also its probably ok

    float gravity_max = 1000;
    float gravity_inc = -10000;
    float jump_power = 2000;

    private float abs(float num)
    {
        float absnum = Math.Abs(num);
        return absnum;
    }

    private float get_move_velo(double delta)
    {
        Vector2 velocity = Velocity; // Velocity is immutate and has to be set as a variable to return
        Vector2 new_velo = velocity;

        float x = Input.GetAxis("left", "right");
        float accel_speed = x * accel;
        float wish_speed = (max_velo * x) - velocity.X;
        float accel_inc = decel;



        if (abs(x) > 0 && (abs(wish_speed) > abs(velocity.X)))
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


    private float get_jump()
    {
        if (IsOnFloor() && Input.IsActionJustPressed("jump"))
        {
            return jump_power;
        }
        return 0;
    }

    public override void _Process(double delta)
    {
        Vector2 velocity = Velocity; // Velocity is immutate and has to be set as a variable to return
        float move_velo = get_move_velo(delta);
        float jump_power = get_jump();
        float used_accel = decel; // acceleration / deceleratoin that will be used for this update

        velocity.X = move_velo;
        
        if (jump_power > 0)
        {
            velocity.Y = -jump_power;
        }
        else if (!IsOnFloor() && velocity.Y < gravity_max)
        {
            velocity.Y -= gravity_inc * (float) delta;
        }

        //GD.Print(target_velo.Y, " ",target_velo.X);
        //velocity.X = velocity.MoveToward(target_velo, used_accel * (float)delta).X;
        Velocity = velocity;

        MoveAndSlide();
    }
}
