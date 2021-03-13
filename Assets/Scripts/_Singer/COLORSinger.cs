using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COLORSinger
{
    // : Singleton
    private static COLORSinger instance;
    public static COLORSinger Instance()
    {
        if (instance == null)
            instance = new COLORSinger();

        return instance;
    }

    // : Constructor
    public COLORSinger() { this.Init(); }

    // : Const
    const string RED = "#FF3232FF";
    const string YELLOW = "#FFE45EFF";
    const string GREEN = "#329932FF";

    // : Status
    private Color colorRED;
    private Color colorYELLOW;
    private Color colorGREEN;

    // : Init
    public void Init() {
        // :: Status
        this.InitColors();
    }
    private void InitColors()
    {
        { if (ColorUtility.TryParseHtmlString(RED, out Color newColor))
                this.colorRED = newColor;
        }
        { if (ColorUtility.TryParseHtmlString(YELLOW, out Color newColor))
                this.colorYELLOW = newColor;
        }
        { if (ColorUtility.TryParseHtmlString(GREEN, out Color newColor))
                this.colorGREEN = newColor;
        }
    }

    // : Get Color
    public Color GetColor(Enum.eColor eColor)
    {
        if (eColor == Enum.eColor.RED) return this.colorRED;
        else if (eColor == Enum.eColor.YELLOW) return this.colorYELLOW;
        else if (eColor == Enum.eColor.GREEN) return this.colorGREEN;

        return Color.black;
    }
}
