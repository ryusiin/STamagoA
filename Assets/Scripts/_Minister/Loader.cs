using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Loader
{
    // : Minister
    private Minister Minister;

    // : Constructor
    public Loader(Minister Minister) {
        // : Use
        this.Minister = Minister;
    }

    // : Load
    public void LoadScene(Enum.eScene eScene)
    {
        // :: Clean
        DOTween.KillAll();

        // :: Do
        int sceneID = (int)eScene;
        AsyncOperation sync = SceneManager.LoadSceneAsync(sceneID);
        sync.completed += scene =>
        {
            if (scene.isDone)
                switch (eScene)
                {
                    case Enum.eScene.INTRO:
                        this.InitScene<Intro_Ruler>();
                        break;
                    case Enum.eScene.TITLE:
                        this.InitScene<Title_Ruler>();
                        break;
                    case Enum.eScene.IN_KINDER:
                        this.InitScene<InKinder_Ruler>();
                        break;
                }
        };
    }
    public static void LoadDictator()
    {
        SceneManager.LoadScene((int)Enum.eScene.DICTATOR);
    }

    // : Init
    private void InitScene<T>() where T : Ruler
    {
        var Ruler = GameObject.FindObjectOfType<T>();
        Ruler.InitMinister(Minister);
        Ruler.Init();
    }
}
