using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1GeradorCaixas : MonoBehaviour
{
    private Vector2 posCaixas1, posCaixas2;
    private float posC1X, posC1Y, posC2X, posC2Y;

    public static int limite;
    public GameObject[] caixas;

    void Start()
    {
        limite = 0;
    }
    
    void Update()
    {
        if (Tarefas.iniciandoCaixasT1)
        {
            if (limite < 5)
            {
                InstanciarCaixas();
                Tarefas.iniciandoCaixasT1 = false;
            }
        }

        if (Tarefas.iniciandoCaixasT2)
        {
            if (limite < 5)
            {
                InstanciarCaixas();
                Tarefas.iniciandoCaixasT2 = false;
            }
        }
    }

    void InstanciarCaixas()
    {
        posC1X = Random.Range(-3f, 0.5f);
        posC1Y = Random.Range(-1.8f, -3f);
        posC2X = Random.Range(3f, 7f);
        posC2Y = Random.Range(-3f, 0.5f);
        posCaixas1 = new Vector2(posC1X, posC1Y);
        posCaixas2 = new Vector2(posC2X, posC2Y);

        int rPrefab = Random.Range(0, 6);

        if (rPrefab == 0 || rPrefab == 1 || rPrefab == 2)
        {
            Instantiate(caixas[rPrefab], posCaixas1, Quaternion.identity);
        }
        else
        {
            Instantiate(caixas[rPrefab], posCaixas2, Quaternion.identity);
        }

        limite++;
    }
}
