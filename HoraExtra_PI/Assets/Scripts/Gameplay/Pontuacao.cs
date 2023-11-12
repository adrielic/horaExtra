using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour //Classe que gerencia o sistema de pontuação, meta, armazena os seus valores e determina o resultado de cada fase jogada.
{
    private Contador contador; //Recebe a instância da classe Contador.
    private int novaMeta; //Recebe o valor da meta atual multiplicada por 2.

    public static int pontos, meta; //Recebem os valores de pontuação e meta de cada fase, respectivamente.
    public static string resultado; //Recebe o resultado da fase, determinando se o jogador venceu ou perdeu.

    void Start()
    {
        contador = GetComponent<Contador>(); //Instanciando a classe Contador.
        pontos = 0; //Iniciando a pontuação como 0.
        resultado = ""; //Iniciando o resultado como nulo.
        novaMeta = meta * 2; //Iniciando a nova meta como o dobro da meta atual.
        Debug.Log("Meta inicial: " + meta);
        Debug.Log("Pontuação inicial: " + pontos);
    }

    void Update()
    {
        GerenciadorInterface.instancia.txtPontuacao.text = pontos + "/" + meta; //Exibindo na tela o valor da pontuação e meta. 

        if (!contador.contando) //Verificando se o contador está parado.
        {
            if (pontos >= meta) //Verificando se a pontuação atingiu o valor da meta.
            {
                resultado = "Vitoria"; //Determinando o resultado como vitória.
            }
            else //Verificando se a meta não foi atingida.
            {
                resultado = "Derrota"; //Determinando o resultado derrota.
            }
        }

        if (contador.tempoExtra) //Verificando se a hora extra foi iniciada.
        {
            meta = novaMeta; //Atribuindo a meta atual à nova meta.
        }

        if (pontos < 0)
        {
            pontos = 0;
        }
    }
}
