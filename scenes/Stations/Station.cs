using Godot;
using System;
using System.Collections.Generic;

public class Station : Area2D
{
    List<Node> bodiesInStation = new List<Node>();
    public int maxBodiesAtOnce = 1;

    public bool IsFull(){
        return bodiesInStation.Count >= maxBodiesAtOnce;
    }
    private void _on_Station_body_entered(Node body){
        bodiesInStation.Add(body);
        if (body is Donut && !this.IsFull()){
            Donut donut = body as Donut;
            donut.SetIsInStation(true);
        }
    }
    private void _on_Station_body_exited(Node body){
        bodiesInStation.Remove(body);
        if (body is Donut)
        {
            Donut donut = body as Donut;
            donut.SetIsInStation(false);
        }
    }

    private void _on_DonutReleased(Donut donut){
        if (bodiesInStation.Contains(donut) && bodiesInStation.Count <= maxBodiesAtOnce ){
            this._DonutInStation(donut);
            donut.mostRecentStation = this;
        }
    }
    protected virtual void _DonutInStation(Donut donut){
        return;
    }
}
