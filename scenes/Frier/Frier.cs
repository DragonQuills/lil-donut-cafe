using Godot;
using System;

public class Frier : Area2D
{
    Node bodyInFrier = null;

    private void _on_Frier_body_entered(Node body){
        bodyInFrier = body;
        GD.Print("Frier entered");
    }
    private void _on_Frier_body_exited(Node body){
        bodyInFrier = null;
        GD.Print("Frier exited");
    }

    public void on_DonutReleased(KinematicBody2D donut){
        GD.Print("connection successful");
        if (donut == bodyInFrier){
            GD.Print("There's a donut in here!");
        }

    }
}
