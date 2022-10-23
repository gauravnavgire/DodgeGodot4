using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed = 400;

	public Vector2 ScreenSize;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;

		if(Input.IsActionPressed("move_right"))
		{
			velocity.x += 1;
		}

		if(Input.IsActionPressed("move_left"))
		{
			velocity.x -= 1;
		}

		if(Input.IsActionPressed("move_up"))
		{
			velocity.y += 1;
		}

		if(Input.IsActionPressed("move_down"))
		{
			velocity.y -= 1;
		}

		var animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if(velocity.Length() > 0 )
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite.Play();
		}
		else
		{
			animatedSprite.Stop();
		}

		Position += velocity * delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.x,0,ScreenSize.x),
			y: Mathf.Clamp(Position.y,0,ScreenSize.y)
		);

	}
}
