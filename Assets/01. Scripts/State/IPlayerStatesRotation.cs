public interface IPlayerStatesRotation
{
    public void EnterState(PlayerRotation player);

    public void UpdatePerState();

    public void ExitState();
}
