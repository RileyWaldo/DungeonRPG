using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Reqired Nodes")]
    [Export] public AnimatedSprite3D AnimatedSpriteNode {get; private set;}
    [ExportGroup("Player Tunables")]

    private Vector2 inputVector = Vector2.Zero;

    public override void _Input(InputEvent @event)
    {
        inputVector = Input.GetVector(
            GameConstants.MOVE_LEFT, 
            GameConstants.MOVE_RIGHT, 
            GameConstants.MOVE_UP, 
            GameConstants.MOVE_DOWN);


        if(inputVector != Vector2.Zero)
        {
            if(!Mathf.IsZeroApprox(inputVector.X))
                AnimatedSpriteNode.FlipH = inputVector.X < 0;
        }
    }

    public Vector2 GetInputVector()
    {
        return inputVector;
    }
}
