using Godot;
using System;
using System.Collections.Generic;

public class Station : Area2D
{
    List<Node> bodiesInStation = new List<Node>();
    public int maxBodiesAtOnce = 1;

    private void _on_Station_body_entered(Node body){
        bodiesInStation.Add(body);
    }
    private void _on_Station_body_exited(Node body){
        bodiesInStation.Remove(body);
    }

    private void _on_DonutReleased(Donut donut){
        if (bodiesInStation.Contains(donut) && bodiesInStation.Count <= maxBodiesAtOnce ){
            this._DonutInStation(donut);
        }
    }
    protected virtual void _DonutInStation(Donut donut){
        return;
    }
}
