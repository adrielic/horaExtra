using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPausa : MonoBehaviour
{
    private GameObject objCC; //Recebe o game object Chave de Cenas.
    private ChaveCenas cc; //Recebe a instância da classe ChaveCenas.

    void Start()
    {
        objCC = GameObject.Find("Chave de Cenas");
        cc = objCC.GetComponent<ChaveCenas>();
    }

    public void Continuar()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        GerenciadorCenas.jogoPausado = false;
        Debug.Log("Continuando " + GerenciadorCenas.cenaAnterior);
    }

    public void RetornarMenu()
    {
        Time.timeScale = 1;
        GerenciadorCenas.jogoPausado = false;
        cc.IniciarCena("Menu Principal");
        Debug.Log("Retornando ao menu");
    }
}
