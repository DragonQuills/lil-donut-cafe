using Godot;
using System;

public class DoughBag : Station
{
    [Signal]
    public delegate void SpawnDonut(Vector2 pos, String donutType);

    public AnimatedSprite sprite;

    public override void _Ready()
    {
        sprite = GetNode<AnimatedSprite>("AnimatedSprite");
    }

    // Overwriting the Station code because we don't want the donut to snap to this.
    private void _on_Station_body_entered(Node body){return;}
    private void _on_Station_body_exited(Node body){return;}
    
    public void _on_DoughBag_input_event(object viewport, object @event, int shape_idx)
    {
        if (@event is InputEventScreenTouch eventScreenTouch && eventScreenTouch.Pressed)
        {
            EmitSignal(nameof(SpawnDonut), eventScreenTouch.Position, sprite.Animation);
        }
    }
}
