using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{
    [Export] private float moveSpeed = 5f;

    protected override void EnterState()
    {
        player.spriteNode.Play(GameConstants.ANIM_MOVE);
    }

    public override void _PhysicsProcess(double delta)
    {
        if(player.GetInputVector() == Vector2.Zero)
        {
            stateMachine.SwitchState<PlayerIdleState>();
            return;
        }

        Vector2 inputVector = player.GetInputVector();
        player.Velocity = new Vector3(inputVector.X, 0f, inputVector.Y);
        player.Velocity *= moveSpeed;
        player.MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        if(Input.IsActionJustPressed(GameConstants.INPUT_DASH))
            stateMachine.SwitchState<PlayerDashState>();
    }
}
