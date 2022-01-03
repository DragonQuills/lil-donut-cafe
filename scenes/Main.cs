using Godot;
using System;

public class Main : Node
{
    private Station _frier;
    private Station _plate;

    private Station _doughBag;
    private PackedScene donutScene;

    private Godot.Collections.Array _stations;
    public override void _Ready()
    {
        _frier = GetNode<Station>("Frier");
        _plate = GetNode<Station>("Plate");
        _doughBag = GetNode<Station>("DoughBag");
        _doughBag.Connect("SpawnDonut", this, nameof(_on_SpawnDonut));
        _stations = GetTree().GetNodesInGroup("stations");

        donutScene = GD.Load<PackedScene>("res://scenes/Donut/Donut.tscn");
        _CreateDonut(new Vector2(100, 500), "chocolate_unbaked");
        _CreateDonut(new Vector2(0, 0), "vanilla_unbaked");
    }

    private Donut _CreateDonut(Vector2 spawnPosition, string baseType){
        Donut donut = (Donut)donutScene.Instance();
        AddChild(donut);
        donut.SetBase(baseType);
        donut.Position = spawnPosition;
        donut.Scale = new Vector2((float)0.5, (float)0.5);
        foreach (Node station in _stations){
            donut.Connect("DonutReleased", station, "_on_DonutReleased");
        }
        return donut;
    }

    private void _on_SpawnDonut(Vector2 pos, String donutType){
        Donut donut = _CreateDonut(pos, donutType + "_unbaked");
        donut.dragging = true;
        donut.mostRecentStation = _doughBag;
    }
}
