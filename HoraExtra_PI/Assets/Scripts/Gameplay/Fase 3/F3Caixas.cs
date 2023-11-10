using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3Caixas : MonoBehaviour
{
    public GameObject prefProduto;

    private IEnumerator novasTarefas;

    public int numTarefas;
    public bool criandoProdutos = false, interagindoCPlayer = false;

    void Start()
    {
        novasTarefas = CriarNovasTarefas(15f);
        StartCoroutine(novasTarefas);
    }

    void Update()
    {
        if (criandoProdutos)
        {
            int num = (int)Random.Range(1, 3);
            numTarefas += num;
            criandoProdutos = false;
        }

        if (interagindoCPlayer)
        {
            Jogador.produto = Instantiate(prefProduto);
            numTarefas--;
            interagindoCPlayer = false;
        }
    }

    IEnumerator CriarNovasTarefas(float espera)
    {
        while (true)
        {
            yield return new WaitForSeconds(espera);
            criandoProdutos = true;
        }
    }
}
