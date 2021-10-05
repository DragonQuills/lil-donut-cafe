using Godot;
using System;

public class Donut : KinematicBody2D {
	// Declare member variables here. Examples:
	private bool dragging = false;
	private int LEFT_MOUSE_BUTTON = 1;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		return;
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
	}
}
