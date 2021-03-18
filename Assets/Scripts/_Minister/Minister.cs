using System;
using UnityEngine;

public class Minister : MonoBehaviour
{
    // : Loader
    private Loader Loader;

    // : Secretary
    private TIMESecretary TIMESecretary;
    private INFOSecretary INFOSecretary;
    private STATUSSecretary STATUSSecretary;
    public DATASecretary DATASecretary;
    public POLICYSecretary POLICYSecretary;

    // : Constructor
    public void Init() {
        // :: Loader
        this.Loader = new Loader(this);

        // :: Secretary
        this.TIMESecretary = this.InitSecretary<TIMESecretary>();
        this.INFOSecretary = this.InitSecretary<INFOSecretary>();
        this.STATUSSecretary = this.InitSecretary<STATUSSecretary>();
        this.DATASecretary = this.InitSecretary<DATASecretary>();
        this.POLICYSecretary = this.InitSecretary<POLICYSecretary>();
        // >> Send
        this.SendSecretaries_ToPublicSecretaries();

        // :: Complete
        Clerk.Log(Enum.eLog.INIT, this.ToString());

        // :: Start
        this.POLICYSecretary.PolicyStart();
    }
    private T InitSecretary<T>() where T : Secretary
    {
        // :: Set
        T secretary = this.gameObject.AddComponent<T>();
        secretary.InitMinister(this);
        secretary.Init();

        // :: Return
        return secretary;
    }

    // : Load
    public void LoadScene(Enum.eScene eScene)
    {
        this.Loader.LoadScene(eScene);
    }

    // : Send
    private void SendSecretaries_ToPublicSecretaries()
    {
        // :: Packing
        PACKSecretaries pack = new PACKSecretaries();
        pack.TIMESecretary = this.TIMESecretary;
        pack.INFOSecretary = this.INFOSecretary;
        pack.STATUSSecretary = this.STATUSSecretary;
        pack.DATASecretary = this.DATASecretary;
        pack.POLICYSecretary = this.POLICYSecretary;

        // :: Send
        this.DATASecretary.InitSecretaries(pack);
        this.POLICYSecretary.InitSecretaries(pack);
    }
}
