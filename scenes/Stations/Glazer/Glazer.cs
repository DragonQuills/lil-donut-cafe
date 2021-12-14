using Godot;
using System;
using System.Collections.Generic;

public class Glazer : Station
{
    override protected void _DonutInStation(Donut donut)
    {
        donut.Position = this.Position;
    }

    private void _on_Button_pressed()
    {
        foreach(Node body in this.bodiesInStation){
            if (body is Donut){
                Donut donut = body as Donut;
                donut.SetGlaze("pink");
            }
        }
    }
}

