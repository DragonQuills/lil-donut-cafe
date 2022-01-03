using Godot;
using System;

public class Donut : KinematicBody2D {
	public bool draggable = true;
	public bool dragging = false;
	private Vector2 _touchPosition;

    [Signal]
    public delegate void DonutReleased(KinematicBody2D self);
	Random _random;
	private AnimatedSprite _base;
	private AnimatedSprite _glaze;
	
	private AnimatedSprite _stripes;

	private AnimatedSprite _sprinkles;

	public Station mostRecentStation = null;
	public Boolean inStation = false;

    // Options used to randomly generate a donut a customer wants
    // TODO: Put this stuff in a user config file

    private string[] _baseOptions = { "vanilla", "chocolate" };
	private string[] _glazeOptions = { "brown", "green", "pink", "tan", "white", "yellow" };
	private string[] _stripeOptions = {"brown", "white"};
	private string[] _sprinkleOptions = {"brown", "confetti", "gold", "purple", "white"};

	public override void _Ready() {
		_base = GetNode<AnimatedSprite>("Base");
		_glaze = GetNode<AnimatedSprite>("Glaze");
		_stripes = GetNode<AnimatedSprite>("Stripes");
		_sprinkles = GetNode<AnimatedSprite>("Sprinkles");

		_random = new Random();
	}

	public void CreateRandomDonut(bool sprinkles = false, bool stripes = false){
		int randomBaseIndex = _random.Next(0, _baseOptions.Length);
		this.SetBase(_baseOptions[randomBaseIndex]);

		int randomGlazeIndex = _random.Next(0, _glazeOptions.Length);
		this.SetGlaze(_glazeOptions[randomGlazeIndex]);

		if(sprinkles){
			int randomSprinkleIndex = _random.Next(0, _sprinkleOptions.Length);
			this.SetSprinkles(_sprinkleOptions[randomSprinkleIndex]);
		}
		if(stripes){
			int randomStripeIndex = _random.Next(0, _stripeOptions.Length);
			this.SetStripes(_stripeOptions[randomStripeIndex]);
		}
	}

	public void Bake(){
		string currAnimation = _base.Animation;
		int indexOfUnderscore = currAnimation.IndexOf("_");
		if(indexOfUnderscore != -1){
			string newAnimation = currAnimation.Remove(indexOfUnderscore, currAnimation.Length - indexOfUnderscore);
			_base.Animation = newAnimation;
		}
	}

	public void ReturnToPreviousStation(){
		if(mostRecentStation != null){
			this.Position = mostRecentStation.Position;
		}
        EmitSignal(nameof(DonutReleased), this);
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

	public void SetIsInStation(bool isInStation){
		inStation = isInStation;
	}

	public override void _Process(float delta) {
		if (dragging){
			this.Position = _touchPosition;
		}
	}

	public void _on_Donut_input_event(object viewport, object @event, int shape_idx) {
		if(@event is InputEventScreenTouch eventScreenTouch){
			if(draggable && eventScreenTouch.Pressed && eventScreenTouch.Index == 0){
				_touchPosition = eventScreenTouch.Position;
				dragging = true;
			}
			else{
				dragging = false;
				if(inStation){
					EmitSignal(nameof(DonutReleased), this);
				}
				else{
					this.ReturnToPreviousStation();
				}

			}
		}
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventScreenDrag eventScreenDrag)
			if(dragging){
                _touchPosition = eventScreenDrag.Position;
			}
		if(@event is InputEventScreenTouch eventScreenTouch){
			if(!eventScreenTouch.Pressed){
				dragging = false;
			}
		}
	}
}