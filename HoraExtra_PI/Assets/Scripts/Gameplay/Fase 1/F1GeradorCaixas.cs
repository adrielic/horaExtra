using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class F1GeradorCaixas : MonoBehaviour
{
    public static int limiteT1, limiteT2, caixasEntregues;
    public static bool caminhaoPresente = true;
    public GameObject[] caixas, pontosSurgimento, areasEntrega;

    private IEnumerator caminhao;

    void Start()
    {
        caminhao = Caminhao(30f);
        StartCoroutine(caminhao);
        limiteT1 = 0;
        limiteT2 = 0;
    }

    void Update()
    {
        if (Tarefas.iniciandoCaixas)
        {
            int rTipo = Random.Range(0, 2);
            StartCoroutine(InstanciarCaixas(rTipo));
            Tarefas.iniciandoCaixas = false;
        }
    }

    IEnumerator InstanciarCaixas(int tipo)
    {
        int rNum = Random.Range(0, 3);

        for (int i = 0; i < rNum; i++)
        {
            yield return new WaitForSeconds(1f);

            if (tipo == 0)
            {
                if (limiteT1 < 5)
                {
                    Debug.Log("Gerando T1");
                    GerarCaixaT1();
                }
                else
                {
                    if (limiteT2 < 5)
                    {
                        Debug.Log("T1 chegou ao limite, gerando T2");
                        GerarCaixaT2();
                    }
                }
            }
            else
            {
                if (limiteT2 < 5)
                {
                    Debug.Log("Gerando T2");
                    GerarCaixaT2();
                }
                else
                {
                    if (limiteT1 < 5)
                    {
                        Debug.Log("T2 chegou ao limite, gerando T1");
                        GerarCaixaT1();
                    }
                }
            }
        }
    }

    void GerarCaixaT1()
    {
        int rPrefab = Random.Range(0, 3);
        Instantiate(caixas[rPrefab], pontosSurgimento[0].transform.position, Quaternion.identity);
    }

    void GerarCaixaT2()
    {
        int rPrefab = Random.Range(3, 6);
        Instantiate(caixas[rPrefab], new Vector2(pontosSurgimento[1].transform.position.x + 2, pontosSurgimento[1].transform.position.y), Quaternion.identity);
    }

    IEnumerator Caminhao(float espera)
    {
        while (true)
        {
            yield return new WaitForSeconds(espera);

            if (caminhaoPresente)
            {
                if (caixasEntregues < 2)
                {
                    Pontuacao.pontos -= 50;
                }
                else if (caixasEntregues >= 2)
                {
                    Pontuacao.pontos += 50;
                }

                Debug.Log("Caminhão indo embora");
                areasEntrega[1].SetActive(false);
                caminhaoPresente = false;
            }
            else
            {
                Debug.Log("Caminhao chegou");
                areasEntrega[1].SetActive(true);
                caminhaoPresente = true;
            }
        }
    }
}
