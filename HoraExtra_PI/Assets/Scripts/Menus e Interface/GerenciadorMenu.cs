using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerenciadorMenu : MonoBehaviour //Classe que faz o gerenciamento do menu principal e seus elementos.
{
    public GameObject objCCM; //Recebe o game object Chave de Cenas.
    public ChaveCenasMenu ccm; //Recebe a instância da classe ChaveCenas.
    public GameObject[] botoes;
    public GameObject imgCreditos, telaCreditos;

    void Start()
    {
        Cursor.visible = true;
    }

    public void Jogar()
    {
        ccm.IniciarCena("Cena 1");
        Debug.Log("Iniciando o jogo");
    }

    public void AbrirCreditos()
    {
        telaCreditos.SetActive(true);
        imgCreditos.GetComponent<Animator>().SetTrigger("Abrir");

        for (int i = 0; i < botoes.Length; i++)
        {
            botoes[i].SetActive(false);
        }
    }

    public void FecharCreditos()
    {
        telaCreditos.SetActive(false);
        imgCreditos.GetComponent<Animator>().SetTrigger("Fechar");

        for (int i = 0; i < botoes.Length; i++)
        {
            botoes[i].SetActive(true);
        }
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Fechando o jogo");
    }
}
