public class Enum
{
    public enum eScene
    {
        DICTATOR = 0,
        INTRO = 1,
        TITLE = 2,
        PRO_LOGOS = 3,
        IN_KINDER = 4,
        GOTCHA = 5
    }

    public enum eFade
    {
        IN = 0,
        OUT = 1 
    }

    public enum eZombie
    {
        EMMA = 1,
        JEONG = 2,
        ING_WEN = 3,
        END = 4
    }

    public enum eZombieStatus
    {
        WAIT,
        CURRENT,
        RELEASE_WAIT,
        RELEASE
    }
    public enum eCondition
    {
        NORMAL,
        CRAZY
    }
    public enum eCompleteStatus
    {
        SUCCESS = 1,
        FAIL = 0
    }
}
