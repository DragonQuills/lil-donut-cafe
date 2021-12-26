using Godot;
using System;

public class DoughBag : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
    public void _on_Donut_input_event(object viewport, object @event, int shape_idx)
    {
        if (@event is InputEventScreenTouch eventScreenTouch)
        {
            
            // if (draggable && eventScreenTouch.Pressed && eventScreenTouch.Index == 0)
            // {
            //     _touchPosition = eventScreenTouch.Position;
            //     _dragging = true;
            // }
            // else
            // {
            //     _dragging = false;
            //     if (inStation)
            //     {
            //         EmitSignal(nameof(DonutReleased), this);
            //     }
            //     else
            //     {
            //         this.ReturnToPreviousStation();
            //     }

            // }
        }
    }
}
