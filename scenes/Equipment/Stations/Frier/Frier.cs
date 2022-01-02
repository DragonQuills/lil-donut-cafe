using Godot;
using System;
using System.Collections.Generic;

public class Frier : Station
{
    async override protected void _DonutInStation(Donut donut){
        donut.draggable = false;
        donut.Position = this.Position;
        await ToSignal(GetTree().CreateTimer((float)2.0), "timeout");
        donut.Bake();
        donut.draggable = true;
    }
}
