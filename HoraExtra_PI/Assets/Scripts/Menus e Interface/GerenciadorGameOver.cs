using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorGameOver : MonoBehaviour //Classe que gerencia a cena de Game Over.
{
    public GameObject objCCM; //Recebe o game object Chave de Cenas.
    public ChaveCenasMenu ccm; //Recebe a instância da classe ChaveCenas.

    public void TentarNovamente()
    {
        ccm.IniciarCena(GerenciadorCenas.cenaAnterior);
        Debug.Log("Repetindo " + GerenciadorCenas.cenaAnterior);
    }

    public void RetornarMenu()
    {
        ccm.IniciarCena("Menu Principal");
        Debug.Log("Retornando ao menu");
    }
}
