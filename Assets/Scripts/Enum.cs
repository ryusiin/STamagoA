public class Enum
{
    public enum eAnimation
    {
        IDLE,
        EAT,
        CRAZY
    }
    public enum eButton
    {
        FOOD,
        TRAINING,
        CLEAN,
        FACTORY
    }
    public enum eCompleteStatus
    {
        SUCCESS = 1,
        FAIL = 0
    }
    public enum eCondition
    {
        NORMAL,
        CRAZY
    }
    public enum eFade
    {
        IN = 0,
        OUT = 1
    }
    public enum eFood
    {
        RAW_MEAT = 1,
        CHEESE = 2,
        DONUT = 3
    }
    public enum eScene
    {
        DICTATOR = 0,
        INTRO = 1,
        TITLE = 2,
        PRO_LOGOS = 3,
        IN_KINDER = 4,
        GOTCHA = 5
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
}
