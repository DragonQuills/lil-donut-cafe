using Godot;
using System;

public class Main : Node
{
    private Area2D _frier;
    private PackedScene donutScene;
    public override void _Ready()
    {
        _frier = GetNode<Area2D>("Frier");
        donutScene = GD.Load<PackedScene>("res://scenes/Donut/Donut.tscn");
        _CreateDonut(new Vector2(100, 500), "chocolate_unbaked");
        _CreateDonut(new Vector2(0, 0), "vanilla_unbaked");
    }

    private void _CreateDonut(Vector2 spawnPosition, string baseType){
        Donut donut = (Donut)donutScene.Instance();
        AddChild(donut);
        donut.SetBase(baseType);
        donut.Position = spawnPosition;
        donut.Connect("DonutReleased", _frier, "_on_DonutReleased");
    }
}
