using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2ItemLimpeza : MonoBehaviour
{
    public GameObject jogador;
    public string local;
    public bool sendoSegurado;

   private void Start()
    {
        jogador = GameObject.Find("Marta");

        transform.position = new Vector3(jogador.transform.position.x, jogador.transform.position.y, this.transform.position.z);
    }

    void Update()
    {
         if (sendoSegurado)
        {
            transform.position = jogador.gameObject.transform.position;
        }
        else
        {
            transform.position = GameObject.Find(local).gameObject.transform.position;
        }
    }
}
