using UnityEngine;
using UnityEngine.SceneManagement;

public class SCENESecretary : Secretary
{
    // : Load
    public static void LoadDictator()
    {
        SceneManager.LoadScene((int)Enum.eScene.DICTATOR);
    }
    public void LoadScene(Enum.eScene eScene)
    {
        AsyncOperation sync = SceneManager.LoadSceneAsync((int)eScene);
        sync.completed += (ele) =>
        {
            if (ele.isDone)
                this.InitScene(eScene);
        };
    }

    // :: Init
    private void InitScene(Enum.eScene eScene)
    {
        switch(eScene)
        {
            case Enum.eScene.DICTATOR:
                break;
            case Enum.eScene.INTRO:
                this.InitRuler<Intro_Ruler>();
                break;
            case Enum.eScene.TITLE:
                this.InitRuler<Title_Ruler>();
                break;
            case Enum.eScene.PRO_LOGOS:
                this.InitRuler<ProLogos_Ruler>();
                break;
            case Enum.eScene.IN_KINDER:
                Debug.LogWarning(":: InKinder Ruler를 초기화 해야함");
                break;
        }
    }
    private void InitRuler<T>() where T : Ruler
    {
        T ruler = GameObject.FindObjectOfType<T>();
        ruler.Init(this.minister);
    }
}
