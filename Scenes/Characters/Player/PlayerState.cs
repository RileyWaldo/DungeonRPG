using Godot;

public abstract partial class PlayerState : Node
{
    protected Player player;
    protected StateMachine stateMachine;

    public override void _Ready()
    {
        SetPhysicsProcess(false);
        SetProcessInput(false);
        player = GetOwner<Player>();
        stateMachine = GetParent<StateMachine>();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        switch(what)
        {
            case GameConstants.NOTIFICATION_ENTER_STATE:
                EnterState();
                SetPhysicsProcess(true);
                SetProcessInput(true);
                break;

            case GameConstants.NOTIFICATION_EXIT_STATE:
                SetPhysicsProcess(false);
                SetProcessInput(false);
                break;
        } 
    }

    protected virtual void EnterState(){}

    protected virtual void ExitState(){}
}
