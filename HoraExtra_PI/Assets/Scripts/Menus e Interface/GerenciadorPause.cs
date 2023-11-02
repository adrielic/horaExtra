using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPausa : MonoBehaviour
{
    public GameObject objCc;
    public ChaveCenas cc;

    void Awake()
    {
        //objCc.SetActive(true);
    }

    public void Continuar()
    {
        cc.IniciarCena(GerenciadorCenas.cenaAnterior);
        Debug.Log("Continuando " + GerenciadorCenas.cenaAnterior);
    }

    public void RetornarMenu()
    {
        cc.IniciarCena("Menu Principal");
        Debug.Log("Retornando ao menu");
    }
}
