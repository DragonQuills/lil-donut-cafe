using Godot;
using System;
using System.Collections.Generic;

public class Frier : Area2D
{
    List<Node> bodiesInFrier = new List<Node>();

    private void _on_Frier_body_entered(Node body){
        bodiesInFrier.Add(body);
    }
    private void _on_Frier_body_exited(Node body){
        bodiesInFrier.Remove(body);
    }

    async private void _on_DonutReleased(Donut donut){
        if (bodiesInFrier.Contains(donut)){
            donut.draggable = false;
            await ToSignal(GetTree().CreateTimer((float)1.0), "timeout");
            donut.Bake();
            donut.draggable = true;
        }
    }
}
