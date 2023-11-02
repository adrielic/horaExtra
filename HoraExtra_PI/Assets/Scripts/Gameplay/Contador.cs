using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour //Classe relacionada ao Contador/Relógio que contabiliza o tempo de cada fase.
{
    [SerializeField] private float tempo, tempoTotal = 240f; //Recebem o Delta Time e o tempo máximo das fases, respectivamente.
    public int rNum; //Recebe um número aleatório que determina se a hora extra deve ser ativada.

    public bool contando = false, tempoExtra = false; //Indicam se o contador e hora extra foram iniciados, respectivamente.
    public TMP_Text contadorUI; //Recebe o componente de texto onde é exibido o contador na tela.

    void Awake()
    {
        IniciarContagem(); //Iniciando a contagem. Deve estar no Awake, uma vez que a classe é instanciada no método Start classe 'Tarefas'. Caso o contrário, as coroutines não são iniciadas corretamente.
    }

    void Update()
    {
        while (contando) //Rodando enquanto o contador está contando.
        {
            tempo += Time.deltaTime; //Atribuindo o valor atual do tempo e o somando à contagem do Delta Time.

            if (tempo >= tempoTotal) //Verificando se 'tempo' é maior ou igual ao tempo total de 240 segundos (4 minutos).
            {
                if (rNum == 3) //Verificando se chance de hora extra foi atingida.
                { 
                    tempoTotal += 60f; //Estendendo o tempo máximo da fase em 60 segundos (1 minuto).
                    tempoExtra = true; //Iniciando o período de hora extra.
                    rNum = 0; //Retornando o valor de rNum para 0, evitando que esta lógica rode em looping.
                    IniciarContagem(); //Reiniciando a contagem.
                    Debug.Log("tempoExtra = " + tempoExtra);
                }
                else //Verificando os outros valores e rodando a lógica que para o contador.
                {
                    tempo = tempoTotal; //Arredondando o tempo para o valor do tempo máximo.
                    PausarContagem(); //Pausando a contagem.
                    Debug.Log("contando = " + contando);

                    if (tempoExtra) //Verificando se a hora extra está ativa e a desativando em seguida.
                    {
                        tempoExtra = false;
                    }
                }
            }

            break;
        }

        ExibirContador(); //Rodando o método que exibe o contador na tela.
    }

    public void IniciarContagem() //Inicia a contagem, simplesmente determinando a váriavel 'contando' como true.
    {
        contando = true;
    }

    public void PausarContagem() //Pausa a contagem, simplesmente determinando a váriavel 'contando' como false.
    {
        contando = false;
    }

    public void ResetarContagem() //Reseta a contagem, determinado o valor de 'tempo' de volta à 0.
    {
        tempo = 0f; 
    }

    void ExibirContador() //Converte os valores do contador e os exibe corretamente na tela.
    {
        float minutos = Mathf.FloorToInt(tempo / 60); //Atribuindo o valor da variável tempo dividido por 60 convertido para int à minutos.
        float segundos = Mathf.FloorToInt(tempo % 60); //Atribuindo o resto do valor da variável tempo dividido por 60 convertido para int à segundos.
        string hora = string.Format("{0:00}:{1:00}", minutos, segundos); //Formatando os valores para o formato de string, de modo que a exibição seja no formato 00:00.
        contadorUI.text = hora; //Atribuindo o texto do contador ao valor do tempo convertido.
    }
}
