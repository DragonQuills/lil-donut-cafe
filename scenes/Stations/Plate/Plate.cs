using Godot;
using System;
using System.Collections.Generic;

public class Plate : Station{
    override protected void _DonutInStation(Donut donut)
    {
        donut.Position = this.Position;
    }
};
