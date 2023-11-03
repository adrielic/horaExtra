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
                if (col.gameObject.name.Contains("P(T1)"))
                {
                    Pontuacao.pontos += 10;
                }
                else if (col.gameObject.name.Contains("M(T1)"))
                {
                    Pontuacao.pontos += 15;
                }
                else if (col.gameObject.name.Contains("G(T1)"))
                {
                    Pontuacao.pontos += 20;
                }
            }
            else if (gameObject.name.Contains("(T2)"))
            {
                if (col.gameObject.name.Contains("P(T2)"))
                {
                    Pontuacao.pontos += 10;
                }
                else if (col.gameObject.name.Contains("M(T2)"))
                {
                    Pontuacao.pontos += 15;
                }
                else if (col.gameObject.name.Contains("G(T2)"))
                {
                    Pontuacao.pontos += 20;
                }
            }
        }
    }
}
