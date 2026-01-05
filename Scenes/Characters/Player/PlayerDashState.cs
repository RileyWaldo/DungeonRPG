using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimerNode;
    [Export] private float dashSpeed = 10f;

    protected override void EnterState()
    {
        player.spriteNode.Play(GameConstants.ANIM_DASH);
        Vector2 direction = player.GetInputVector();
        player.Velocity = new(direction.X, 0f, direction.Y);

        if(player.Velocity == Vector3.Zero)
        {
            player.Velocity = player.spriteNode.FlipH ? Vector3.Left : Vector3.Right;
        }

        player.Velocity *= dashSpeed;
        dashTimerNode.Start();
    }

    protected override void ExitState()
    {
        player.Velocity = Vector3.Zero;
    }

    public override void _Ready()
    {
        base._Ready();
        dashTimerNode.Timeout += DashTimerEnd;
    }

    public override void _PhysicsProcess(double delta)
    {
        player.MoveAndSlide();
    }

    private void DashTimerEnd()
    {
        stateMachine.SwitchState<PlayerIdleState>();
    }
}
