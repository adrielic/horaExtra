using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class F4Filas : MonoBehaviour
{
    public GameObject[] tipos, pontosSurgimento;
    public static Queue<GameObject> fila1 = new Queue<GameObject>();
    public static Queue<GameObject> fila2 = new Queue<GameObject>();
    public static int numFila, falhas;
    public TMP_Text falhasUI;

    void Start()
    {
        falhas = 0;
    }

    void Update()
    {
        if (Tarefas.iniciandoFilas)
        {
            GerarNPC();
            Tarefas.iniciandoFilas = false;
        }

        if (falhas > 3)
        {
            Pontuacao.resultado = "Derrota";
        }

        falhasUI.text = "" + falhas;
    }

    void GerarNPC()
    {
        int rPonto = Random.Range(0, 2);
        int rSprite = Random.Range(0, 4);
        Instantiate(tipos[rSprite], new Vector2(pontosSurgimento[rPonto].transform.position.x, pontosSurgimento[rPonto].transform.position.y), Quaternion.identity);
        numFila = rPonto;
    }
}
