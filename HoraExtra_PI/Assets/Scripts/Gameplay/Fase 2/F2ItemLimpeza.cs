using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2ItemLimpeza : MonoBehaviour
{
    public GameObject jogador;
    public string local;
    public bool sendoSegurado;

    void Update()
    {
         if (sendoSegurado)
        {
            transform.position = new Vector2(jogador.transform.position.x, jogador.transform.position.y - 0.5f);
        }
        else
        {
            transform.position = GameObject.Find(local).gameObject.transform.position;
        }
    }
}
