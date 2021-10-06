using Godot;
using System;

public class Donut : KinematicBody2D {
	// Declare member variables here. Examples:
	private bool dragging = false;
	private int LEFT_MOUSE_BUTTON = 1;

	private AnimatedSprite _base;
	private AnimatedSprite _glaze;
	private AnimatedSprite _stripes;
	private AnimatedSprite _sprinkles;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		_base = GetNode<AnimatedSprite>("Base");
		_glaze = GetNode<AnimatedSprite>("Glaze");
		_stripes = GetNode<AnimatedSprite>("Stripes");
		_sprinkles = GetNode<AnimatedSprite>("Sprinkles");
        this.setBase("vanilla");
        this.setStripes("white");
        this.setSprinkles("confetti");
	} 
	public void setBase(string baseType){
		_base.Animation = baseType;
        _base.Visible = true;
	}

	public void setGlaze(string glazeType){
		_glaze.Animation = glazeType;
        _glaze.Visible = true;
	}

	public void setStripes(string stripesType){
		_stripes.Animation = stripesType;
        _stripes.Visible = true;
	}
    
	public void setSprinkles(string sprinklesType){
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