using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class F1AreaEntrega : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "F1Ca")
        {
            if (gameObject.name.Contains("(T1)"))
            {
                if (col.gameObject.name.Contains("(T1)"))
                {
                    Pontuacao.pontos += 20;
                    Destroy(col.gameObject, 1);
                    F1GeradorCaixas.limiteT1--;
                }
                else
                {
                    Pontuacao.pontos -= 10;
                    Destroy(col.gameObject, 1);
                    F1GeradorCaixas.limiteT2--;
                }
            }
            else if (gameObject.name.Contains("(T2)"))
            {
                if (col.gameObject.name.Contains("(T2)"))
                {
                    Pontuacao.pontos += 20;
                    Destroy(col.gameObject, 1);
                    F1GeradorCaixas.caixasEntregues++;
                    F1GeradorCaixas.limiteT2--;
                }
                else
                {
                    Pontuacao.pontos -= 10;
                    Destroy(col.gameObject, 1);
                    F1GeradorCaixas.limiteT1--;
                }
            }
        }
    }
}
