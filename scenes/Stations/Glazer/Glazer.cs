using Godot;
using System;
using System.Collections.Generic;

public class Glazer : Station
{
    // TODO: Put this in a user config file
    private string[] _glazeOptions = { "brown", "green", "pink", "tan", "white", "yellow" };
    private int selectedGlaze = 0;
    private Dictionary<string, Color> glazeToColor= new Dictionary<string, Color>{
            {"pink", new Color("FF99CC")},
            {"yellow", new Color("FFCC00")},
            {"green", new Color("66CC99")},
            {"tan", new Color("DBB17D")},
            {"brown", new Color("5F4F38")},
            {"white", new Color("EEEEEE")},

        };
    private Button _glazeButton;

    // TODO: Set the color of the glaze button based on the glaze type that the donut will be glazed
    public override void _Ready()
    {  
        _glazeButton = GetNode<Button>("GlazeButton");
        this._SetButtonColor(this._glazeOptions[this.selectedGlaze]);
    }

    private void _SetButtonColor(string color){
        StyleBoxFlat s = new StyleBoxFlat();
        s.BgColor = glazeToColor[color];

        _glazeButton.AddStyleboxOverride("normal", s);
        _glazeButton.AddStyleboxOverride("pressed", s);
        _glazeButton.AddStyleboxOverride("hover", s);
    }

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
        this._SetButtonColor(this._glazeOptions[this.selectedGlaze]);
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
        this._SetButtonColor(this._glazeOptions[this.selectedGlaze]);
    }
}

