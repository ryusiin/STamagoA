using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STAREMachine : MonoBehaviour
{
    private void Update()
    {
        this.transform.rotation = Camera.main.transform.rotation;
    }
}
