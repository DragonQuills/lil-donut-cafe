using Godot;
using System;

public class Main : Node
{
    private Area2D _frier;
    private Area2D _plate;
    private PackedScene donutScene;

    private Godot.Collections.Array _stations;
    public override void _Ready()
    {
        _frier = GetNode<Area2D>("Frier");
        _plate = GetNode<Area2D>("Plate");
        _stations = GetTree().GetNodesInGroup("stations");

        donutScene = GD.Load<PackedScene>("res://scenes/Donut/Donut.tscn");
        _CreateDonut(new Vector2(100, 500), "chocolate_unbaked");
        _CreateDonut(new Vector2(0, 0), "vanilla_unbaked");
    }

    private void _CreateDonut(Vector2 spawnPosition, string baseType){
        Donut donut = (Donut)donutScene.Instance();
        AddChild(donut);
        donut.SetBase(baseType);
        donut.Position = spawnPosition;
        donut.Scale = new Vector2((float)0.5, (float)0.5);
        foreach (Node station in _stations){
            donut.Connect("DonutReleased", station, "_on_DonutReleased");
        }
    }

}
