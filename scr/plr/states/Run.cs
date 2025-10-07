
using Godot;

public partial class Run : PlayerState
{
    public override void process(float delta)
    {
        float move_velo = player.get_move_velo(delta);
        
        Vector2 target_velo = Vector2.Zero;
        target_velo.X = move_velo;
        target_velo.Y = player.velocity.Y;

        player.velocity.X = player.velocity.MoveToward(target_velo, player.accel * (float)delta).X;

        player.Velocity = player.velocity;
        player.MoveAndSlide();

        GD.Print("RUN");
        if (!player.is_moving())
        {
            _change_state(IDLE);
        }
    }
}