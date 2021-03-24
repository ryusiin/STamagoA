public class Pack_ReleaseZombie
{
    // : Constructor
    // >> Status
    public string zombieName;
    public int earningGold;
    public Enum.eCompleteStatus eCompleteStatus;
    public Pack_ReleaseZombie(string name, int gold, Enum.eCompleteStatus eComplete)
    {
        this.zombieName = name;
        this.earningGold = gold;
        this.eCompleteStatus = eComplete;
    }
}
