using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class F1Caixas : MonoBehaviour
{
    void Start()
    {
        if (gameObject.name.Contains("(T1)"))
        {
            F1GeradorCaixas.limiteT1++;
            Debug.Log("limiteT1 = " + F1GeradorCaixas.limiteT1);
        }
        else
        {
            F1GeradorCaixas.limiteT2++;
            Debug.Log("limiteT2 = " + F1GeradorCaixas.limiteT2);
        }
    }
}
