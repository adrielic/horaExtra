using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorPausa : MonoBehaviour
{
    public GameObject objCC;
    public ChaveCenas cc;

    void Start()
    {
        
    }

    public void Continuar()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void RetornarMenu()
    {
        Time.timeScale = 1;
        cc.IniciarCena("Menu Principal");
    }
}
