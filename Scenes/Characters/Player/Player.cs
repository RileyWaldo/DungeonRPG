using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Reqired Nodes")]
    [Export]private AnimatedSprite3D spriteNode;
    [ExportGroup("Player Tunables")]
    [Export]private float moveSpeed = 5f;

    private Vector2 inputVector = Vector2.Zero;

    const string animationIdle = "Idle";
    const string animationMove = "Move";

    public override void _Ready()
    {
        spriteNode.Play(animationIdle);
    }
    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(inputVector.X, 0f, inputVector.Y);
        Velocity *= moveSpeed;
        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        inputVector = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");


        if(inputVector == Vector2.Zero)
            spriteNode.Play(animationIdle);
        else
        {
            if(!Mathf.IsZeroApprox(inputVector.X))
                spriteNode.FlipH = inputVector.X < 0;
            spriteNode.Play(animationMove);
        }
    }
}
