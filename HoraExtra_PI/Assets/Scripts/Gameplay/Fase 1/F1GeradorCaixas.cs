using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class F1GeradorCaixas : MonoBehaviour
{
    public static int limiteT1, limiteT2, caixasEntregues;
    public static bool caminhaoPresente;
    public GameObject[] caixas, pontosSurgimento, areasEntrega;
    public GameObject caminhaoCenario;

    private IEnumerator caminhao;

    void Start()
    {
        limiteT1 = 0;
        limiteT2 = 0;
        caixasEntregues = 0;
        caminhao = Caminhao(29.8f); //O número é quebrado, para que a verificação de pontos do caminhão aconteça antes do timer principal da fase parar aos 4 min.
        StartCoroutine(caminhao);

        if (GerenciadorCenas.cenaAtual.name == "Fase 1")
        {
            StartCoroutine(GerarCaixaT2(2f));
            caminhaoPresente = true;
        }
        else
        {
            caminhaoCenario.GetComponent<Animator>().SetTrigger("Saindo");
            areasEntrega[1].SetActive(false);
            caminhaoPresente = false;
        }
    }

    void Update()
    {
        if (Tarefas.iniciandoCaixas)
        {
            StartCoroutine(GerarCaixaT1(1f, Random.Range(0, 2)));
            Tarefas.iniciandoCaixas = false;
        }
    }

    IEnumerator GerarCaixaT1(float espera, int tipo)
    {
        for (int i = 0; i < Random.Range(0, 3); i++)
        {
            yield return new WaitForSeconds(espera);

            if (tipo == 1)
            {
                if (limiteT1 < 3)
                {
                    Instantiate(caixas[Random.Range(0, 3)], pontosSurgimento[0].transform.position, Quaternion.identity);
                    GerenciadorInterface.instancia.txtNotificacao.text = "Há novas mercadorias aguardando o transporte.";
                    Debug.Log("Gerando T1");
                }
            }
        }
    }

    IEnumerator GerarCaixaT2(float espera)
    {
        for (int i = 0; i < Random.Range(2, 6); i++)
        {
            yield return new WaitForSeconds(espera);

            if (limiteT2 < 3)
            {
                Instantiate(caixas[Random.Range(3, 6)], new Vector2(pontosSurgimento[1].transform.position.x + 2, pontosSurgimento[1].transform.position.y), Quaternion.identity);
                Debug.Log("Gerando T2");
            }
        }
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
                    Pontuacao.pontos -= 50 - caixasEntregues * 20;
                    GerenciadorInterface.instancia.tarefa.GetComponent<Animator>().SetTrigger("-Dinheiro");
                }
                else if (caixasEntregues >= 2)
                {
                    Pontuacao.pontos += 25 * caixasEntregues;
                    GerenciadorInterface.instancia.tarefa.GetComponent<Animator>().SetTrigger("+Dinheiro");
                }

                areasEntrega[1].SetActive(false);
                caminhaoPresente = false;
                caminhaoCenario.GetComponent<Animator>().SetTrigger("Saindo");
                GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Dando Partida"), 0.5f);
                GerenciadorInterface.instancia.txtNotificacao.text = "O caminhão foi embora.";
                Debug.Log("Caminhão indo embora");
            }
            else
            {
                StartCoroutine(GerarCaixaT2(2f));
                areasEntrega[1].SetActive(true);
                caminhaoPresente = true;
                caixasEntregues = 0;
                caminhaoCenario.GetComponent<Animator>().SetTrigger("Chegando");
                GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Estacionando"), 0.2f);
                GerenciadorInterface.instancia.txtNotificacao.text = "O caminhão está aguardando para entrega.";
                Debug.Log("Caminhao chegou");
            }
        }
    }
}
