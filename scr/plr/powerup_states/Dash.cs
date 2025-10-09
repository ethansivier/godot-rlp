using System.Collections.Generic;
using Godot; 
using System.Threading.Tasks;

public partial class Dash : PlayerState
{
    
    public bool cd = false;
    public float speed = 3000;

    public new int priority = 5;

    public async override void enter(string previous, Dictionary<object, object> data)
    {
        
        player.velocity.X = player.move_dir != 0 ? speed * player.move_dir : speed;
        //await Task.Delay(1000);
        _change_state(IDLE);
    }

    public override void process(float delta)
    {
        //player.velocity.Y = 0;
    }
}