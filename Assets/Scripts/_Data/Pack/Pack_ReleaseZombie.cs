public class Pack_ReleaseZombie
{
    // : Constructor
    // >> Status
    public string zombieName;
    public int earningGold;
    public Enum.eCompleteStatus eCompleteStatus;
    public string completeDescription;
    public Pack_ReleaseZombie(string name, int gold, 
        Enum.eCompleteStatus eComplete, string description)
    {
        this.zombieName = name;
        this.earningGold = gold;
        this.eCompleteStatus = eComplete;
        this.completeDescription = description;
    }
}
