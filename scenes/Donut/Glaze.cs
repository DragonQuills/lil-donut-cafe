using Godot;
using System;

public class Glaze : AnimatedSprite
{

    private AnimatedSprite _accent;

    public override void _Ready()
    {
        _accent = GetNode<AnimatedSprite>("Accent");
    }

    public void SetGlaze(string glazeType){
        this.Animation = glazeType;
        this.Visible = true;

        // Set accents based on glaze type to make the glaze look better
        string[] lightGlazes = {"pink", "green", "yellow"};
        string[] darkGlazes = {"brown", "tan", "white"};
        
        if(Array.Exists(lightGlazes, e => e == glazeType)){
            _accent.Animation = "light";
        }
        else if(Array.Exists(darkGlazes, e => e == glazeType)){
            _accent.Animation = "dark";
        }
        _accent.Visible = true;
    }
}
