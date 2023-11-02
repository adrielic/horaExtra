using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerenciadorMenu : MonoBehaviour //Classe que faz o gerenciamento do menu principal e seus elementos.
{
    public GameObject objCCM; //Recebe o game object Chave de Cenas.
    public ChaveCenasMenu ccm; //Recebe a instância da classe ChaveCenas.

    public void Jogar()
    {
        ccm.IniciarCena("Cena 1");
        Debug.Log("Iniciando o jogo");
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Fechando o jogo");
    }
}
