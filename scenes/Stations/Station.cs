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
    override public void _Ready(){
        this.Connect("body_entered", this, "_on_Station_body_entered");
        this.Connect("body_entered", this, "_on_Station_body_exited");
    }

    private void _on_DonutReleased(Donut donut){
        if (bodiesInStation.Contains(donut) && bodiesInStation.Count <= maxBodiesAtOnce ){
            donut.Position = this.Position;
            this._DonutInStation(donut);
        }
    }
    protected void _DonutInStation(Donut donut){
        return;
    }
}
