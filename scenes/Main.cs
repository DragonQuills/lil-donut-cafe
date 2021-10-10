using Godot;
using System;

public class Main : Node
{
    private Area2D _frier;
    public override void _Ready()
    {
        _frier = GetNode<Area2D>("Frier");

        var donutScene = GD.Load<PackedScene>("res://scenes/Donut/Donut.tscn");
        var donut = donutScene.Instance();
        AddChild(donut);
        donut.Call("SetBase", "chocolate_unbaked");
        donut.Connect("DonutReleased", _frier, "on_DonutReleased");
    }
}
