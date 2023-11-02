using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorNPCs : MonoBehaviour
{
    public GameObject[] tipos, pontosSurgimento;
    public static Queue<GameObject> fila1 = new Queue<GameObject>();
    public static Queue<GameObject> fila2 = new Queue<GameObject>();
    public static int numFila, falhas;

    void Update()
    {
        if (Tarefas.iniciandoNPC)
        {
            GerarNPC();
        }

        if (falhas > 3)
        {
            Pontuacao.resultado = "Derrota";
        }
    }

    void GerarNPC()
    {
        int rPonto = Random.Range(0, 2);
        int rSprite = Random.Range(0, 4);
        Instantiate(tipos[rSprite], new Vector2(pontosSurgimento[rPonto].transform.position.x, pontosSurgimento[rPonto].transform.position.y), Quaternion.identity);
        numFila = rPonto;
        Tarefas.iniciandoNPC = false;
    }
}
