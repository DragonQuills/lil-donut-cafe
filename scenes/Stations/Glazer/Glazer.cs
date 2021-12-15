using Godot;
using System;
using System.Collections.Generic;

public class Glazer : Station
{
    // TODO: Put this in a user config file
    private string[] _glazeOptions = { "brown", "green", "pink", "tan", "white", "yellow" };
    private int selectedGlaze = 0;

    override protected void _DonutInStation(Donut donut)
    {
        donut.Position = this.Position;
    }

    private void _on_GlazeButton_pressed()
    {
        foreach(Node body in this.bodiesInStation){
            if (body is Donut){
                Donut donut = body as Donut;
                donut.SetGlaze(this._glazeOptions[this.selectedGlaze]);
            }
        }
    }

    private void _on_NextButton_pressed()
    {
        if(this.selectedGlaze >= this._glazeOptions.Length - 1){
            this.selectedGlaze = 0;
        }
        else{
            this.selectedGlaze += 1;
        }
    }

    private void _on_PrevButton_pressed()
    {
        if (this.selectedGlaze <= 0)
        {
            this.selectedGlaze = this._glazeOptions.Length - 1;
        }
        else
        {
            this.selectedGlaze -= 1;
        }
    }
}

