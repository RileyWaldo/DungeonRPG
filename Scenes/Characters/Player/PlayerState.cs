using Godot;

public partial class PlayerState : Node
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
            case 5001:
                EnterState();
                SetPhysicsProcess(true);
                SetProcessInput(true);
                break;

            case 5002:
                SetPhysicsProcess(false);
                SetProcessInput(false);
                break;
        } 
    }

    protected virtual void EnterState(){}

    protected virtual void ExitState(){}
}
