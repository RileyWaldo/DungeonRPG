using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
    protected override void EnterState()
    {
        player.spriteNode.Play(GameConstants.ANIM_IDLE);
    }

    public override void _PhysicsProcess(double delta)
    {
        if(player.GetInputVector() != Vector2.Zero)
            stateMachine.SwitchState<PlayerMoveState>();
    }

    public override void _Input(InputEvent @event)
    {
        if(Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            stateMachine.SwitchState<PlayerDashState>();
        }
    }
}
