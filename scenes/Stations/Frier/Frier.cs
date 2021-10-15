using Godot;
using System;
using System.Collections.Generic;

public class Frier : Area2D
{
    List<Node> bodiesInFrier = new List<Node>();
    public int maxDonutsAtOnce = 1;

    private void _on_Frier_body_entered(Node body){
        bodiesInFrier.Add(body);
    }
    private void _on_Frier_body_exited(Node body){
        bodiesInFrier.Remove(body);
    }

    async private void _on_DonutReleased(Donut donut){
        if (bodiesInFrier.Contains(donut) && bodiesInFrier.Count <= maxDonutsAtOnce ){
            donut.draggable = false;
            donut.Position = this.Position;
            await ToSignal(GetTree().CreateTimer((float)2.0), "timeout");
            donut.Bake();
            donut.draggable = true;
        }
    }
}
