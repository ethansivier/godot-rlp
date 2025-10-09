
using Godot;

public partial class Run : PlayerState
{
    public static void manage_run(float delta, Player player)
    {
        float move_velo = player.get_move_velo(delta);
        
        Vector2 target_velo = Vector2.Zero;
        target_velo.X = move_velo;
        target_velo.Y = player.velocity.Y;

        player.velocity.X = player.velocity.MoveToward(target_velo, player.accel * (float)delta).X;
    }
    public override void process(float delta)
    {
        manage_run(delta, player);
        Falling.jump_check(player);

        player.Velocity = player.velocity;
        player.MoveAndSlide();
        if (player.is_jumping() || !player.IsOnFloor())
        {
            _change_state(FALLING);
        }
        else if (!player.is_moving())
        {
            _change_state(IDLE);
        }
    }
}