using Godot;
using System;

public class Donut : KinematicBody2D {
	// Declare member variables here. Examples:
	private bool dragging = false;
	private int LEFT_MOUSE_BUTTON = 1;
    Random random;

	private AnimatedSprite _base;
	private AnimatedSprite _glaze;
    
	private AnimatedSprite _stripes;

	private AnimatedSprite _sprinkles;

    // Options used to randomly generate a donut a customer wants
    private string[] _baseOptions = { "vanilla", "chocolate" };
    private string[] _glazeOptions = { "brown", "green", "pink", "tan", "white", "yellow" };
    private string[] _stripeOptions = {"brown", "white"};
    private string[] _sprinkleOptions = {"brown", "confetti", "gold", "purple", "white"};
    // Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		_base = GetNode<AnimatedSprite>("Base");
		_glaze = GetNode<AnimatedSprite>("Glaze");
		_stripes = GetNode<AnimatedSprite>("Stripes");
		_sprinkles = GetNode<AnimatedSprite>("Sprinkles");

        random = new Random();
        CreateRandomDonut(sprinkles: true, stripes: true);
		GD.Print("Loaded!");
	}

    public void CreateRandomDonut(bool sprinkles = false, bool stripes = false){
        int randomBaseIndex = random.Next(0, _baseOptions.Length);
        this.SetBase(_baseOptions[randomBaseIndex]);

        int randomGlazeIndex = random.Next(0, _glazeOptions.Length);
        this.SetGlaze(_glazeOptions[randomGlazeIndex]);

        if(sprinkles){
            int randomSprinkleIndex = random.Next(0, _sprinkleOptions.Length);
            this.SetSprinkles(_sprinkleOptions[randomSprinkleIndex]);
        }
        if(stripes){
            int randomStripeIndex = random.Next(0, _stripeOptions.Length);
            this.SetStripes(_stripeOptions[randomStripeIndex]);
        }
    }
	public void SetBase(string baseType){
		_base.Animation = baseType;
        _base.Visible = true;
	}

	public void SetGlaze(string glazeType){
		_glaze.Call("SetGlaze", glazeType);
	}

	public void SetStripes(string stripesType){
		_stripes.Animation = stripesType;
        _stripes.Visible = true;
	}
    
	public void SetSprinkles(string sprinklesType){
		_sprinkles.Animation = sprinklesType;
        _sprinkles.Visible = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta) {
		if (dragging){
			Vector2 mousePosition = GetViewport().GetMousePosition();
			this.Position = mousePosition;
		}
	}

	public void _on_Donut_input_event(object viewport, object @event, int shape_idx) {
		if(@event is InputEventMouseButton eventMouseButton){
			if(eventMouseButton.ButtonIndex == LEFT_MOUSE_BUTTON){
				dragging = !dragging;
			}
		}
		if(@event is InputEventScreenDrag eventScreenDrag){
			// if(eventScreenTouch.Pressed && eventScreenTouch.Index == 0)
			this.Position = eventScreenDrag.Position;
		}

	}
}