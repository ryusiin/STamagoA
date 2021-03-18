using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Secretary_Public : Secretary
{
    protected TIMESecretary TIMESecretary;
    protected INFOSecretary INFOSecretary;
    protected STATUSSecretary STATUSSecretary;
    protected DATASecretary DATASecretary;
    protected POLICYSecretary POLICYSecretary;
    public void InitSecretaries(PACKSecretaries pack) {
        this.TIMESecretary = pack.TIMESecretary;
        this.INFOSecretary = pack.INFOSecretary;
        this.STATUSSecretary = pack.STATUSSecretary;
        this.DATASecretary = pack.DATASecretary;
        this.POLICYSecretary = pack.POLICYSecretary;
    }
}
