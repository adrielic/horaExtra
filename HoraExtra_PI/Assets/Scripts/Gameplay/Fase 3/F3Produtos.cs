using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3Produtos : MonoBehaviour
{
    public int tipo;
    private GameObject jogador;

    void Start()
    {
        jogador = GameObject.Find("Marta");

        transform.position = new Vector3(jogador.transform.position.x, jogador.transform.position.y, this.transform.position.z);
    }

    void Update()
    {
        transform.position = new Vector3(jogador.transform.position.x, jogador.transform.position.y, this.transform.position.z);
    }
}
