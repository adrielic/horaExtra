using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3Caixas : MonoBehaviour
{
    public GameObject[] prefProduto;
    public int qntdProdutos;
    public bool criandoProdutos = false, interagindoCPlayer = false;

    private IEnumerator novosProdutos;

    void Start()
    {
        if (GerenciadorCenas.cenaAtual.name == "Fase 3")
        {
            novosProdutos = GerarProdutos(20f);
            criandoProdutos = true;
        }
        else
        {
            novosProdutos = GerarProdutos(30f);
        }

        StartCoroutine(novosProdutos);
        //Ativando o componente de interface e zerando o texto inicial.
        GerenciadorInterface.instancia.produtos.SetActive(true);
        GerenciadorInterface.instancia.txtProduto1.text = null;
        GerenciadorInterface.instancia.txtProduto2.text = null;
        GerenciadorInterface.instancia.txtProduto3.text = null;
        GerenciadorInterface.instancia.txtProduto4.text = null;
        GerenciadorInterface.instancia.txtProduto5.text = null;
    }

    void Update()
    {
        if (criandoProdutos)
        {
            int num = Random.Range(0, 3);
            qntdProdutos += num;
            qntdProdutos = Mathf.Clamp(qntdProdutos, 0, 10);
            GerenciadorInterface.instancia.txtNotificacao.text = "Há novos produtos para reposição.";
            Debug.Log("" + gameObject.name + " possui: " + qntdProdutos + " produtos");
            criandoProdutos = false;
        }

        if (interagindoCPlayer)
        {
            int prod = Random.Range(0, 3);
            Jogador.produto = Instantiate(prefProduto[prod]);
            qntdProdutos--;
            interagindoCPlayer = false;
        }

        ExibirQntd();
    }

    IEnumerator GerarProdutos(float espera)
    {
        while (true)
        {
            yield return new WaitForSeconds(espera);

            if (qntdProdutos < 10)
            {
                criandoProdutos = true;
            }
        }
    }

    void ExibirQntd()
    {
        Vector2 posCaixa = Camera.main.WorldToScreenPoint(transform.position);

        switch (gameObject.name) //Verificando o nome da caixa e exibindo corretamente a quantidade de produtos dela na tela em cima da caixa correta.
        {
            case "F3Caixa1":
                GerenciadorInterface.instancia.txtProduto1.rectTransform.position = posCaixa + new Vector2(0, 100);
                GerenciadorInterface.instancia.txtProduto1.text = "" + qntdProdutos;
                break;
            case "F3Caixa2":
                GerenciadorInterface.instancia.txtProduto2.rectTransform.position = posCaixa + new Vector2(0, 100);
                GerenciadorInterface.instancia.txtProduto2.text = "" + qntdProdutos;
                break;
            case "F3Caixa3":
                GerenciadorInterface.instancia.txtProduto3.rectTransform.position = posCaixa + new Vector2(0, 100);
                GerenciadorInterface.instancia.txtProduto3.text = "" + qntdProdutos;
                break;
            case "F3Caixa4":
                GerenciadorInterface.instancia.txtProduto4.rectTransform.position = posCaixa + new Vector2(0, 100);
                GerenciadorInterface.instancia.txtProduto4.text = "" + qntdProdutos;
                break;
            case "F3Caixa5":
                GerenciadorInterface.instancia.txtProduto5.rectTransform.position = posCaixa + new Vector2(0, 100);
                GerenciadorInterface.instancia.txtProduto5.text = "" + qntdProdutos;
                break;
        }
    }
}
