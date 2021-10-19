using Godot;
using System;
using System.Collections.Generic;

public class Plate : Area2D
{
    List<Node> bodiesInPlate = new List<Node>();
    public int maxDonutsAtOnce = 1;

    private void _on_Plate_body_entered(Node body){
        bodiesInPlate.Add(body);
    }
    private void _on_Plate_body_exited(Node body){
        bodiesInPlate.Remove(body);
    }

    private void _on_DonutReleased(Donut donut){
        if (bodiesInPlate.Contains(donut) && bodiesInPlate.Count <= maxDonutsAtOnce ){
            donut.Position = this.Position;
        }
    }
}
