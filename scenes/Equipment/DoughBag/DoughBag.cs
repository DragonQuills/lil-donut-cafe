using Godot;
using System;

public class DoughBag : Station
{
    public void _on_DoughBag_input_event(object viewport, object @event, int shape_idx)
    {
        if (@event is InputEventScreenTouch eventScreenTouch && eventScreenTouch.Pressed)
        {
            GD.Print("Bag clicked");
        }
    }
}
