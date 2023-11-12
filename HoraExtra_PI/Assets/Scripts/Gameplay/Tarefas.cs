using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Tarefas : MonoBehaviour //Classe relacionada as Coroutines que iniciam as tarefas e as mantém sendo atualizadas.
{
    private Contador contador; //Recebe a instância da classe Contador.
    private IEnumerator f1_caixas; //Recebe a coroutine da tarefa da fase 1 (Depósito).
    private IEnumerator f2_sujeiras; //Recebe a coroutine da tarefa da fase 2 (Limpeza).

    //Devido à particularidade em sua mecânica, a fase 3 possui sua coroutine em uma classe própria pertencente às caixas de produtos.

    private IEnumerator f4_filas; //Recebe a coroutine da tarefa principal da fase 4 (Operação de caixa).
    private IEnumerator f4_telefone; //Recebe a coroutine da tarefa secundária da fase 4 (Atender o telefone).

    public static bool iniciandoCaixas = false, iniciandoSujeira = false, iniciandoFilas = false, iniciandoTelefone = false; //Indicam se as determinadas tarefas foram iniciadas.

    void Start()
    {
        contador = GetComponent<Contador>(); //Instanciando a classe Contador.

        switch (GerenciadorCenas.cenaAtual.name)
        {
            case "Fase 1": //Verificando se a cena atual é a Fase 1.
                f1_caixas = IniciarF1Caixas(4f);
                GerenciadorInterface.instancia.tutorial.GetComponent<Animator>().SetTrigger("Exibir");
                contador.rNum = 0; //Atribuindo rNum para 0, uma vez que na primeira fase a hora extra nunca acontece.

                if (contador.contando) //Verificando se o contador foi iniciado, em seguida iniciando as coroutines relacionadas a cada tarefa.
                {
                    StartCoroutine(f1_caixas);
                }

                Debug.Log(GerenciadorCenas.cenaAtual.name + ": Iniciando tarefas");
                break;
            case "Fase 2": //Verificando se a cena atual é a Fase 2.
                f1_caixas = IniciarF1Caixas(8f);
                f2_sujeiras = IniciarF2Sujeira(10f);
                contador.rNum = Random.Range(0, 4); //Rodando uma chance de 25% entre 0 e 3 de se iniciar uma hora extra nesta fase.

                if (contador.contando) //Verificando se o contador foi iniciado, em seguida iniciando as coroutines relacionadas a cada tarefa.
                {
                    StartCoroutine(f1_caixas);
                    StartCoroutine(f2_sujeiras);
                }

                Debug.Log(GerenciadorCenas.cenaAtual.name + ": Iniciando tarefas");
                break;
            case "Fase 3": //Verificando se a cena atual é a Fase 3.
                f1_caixas = IniciarF1Caixas(10f);
                f2_sujeiras = IniciarF2Sujeira(20f);
                contador.rNum = Random.Range(0, 4); //Rodando uma chance de 25% entre 0 e 3 de se iniciar uma hora extra nesta fase.

                if (contador.contando) //Verificando se o contador foi iniciado, em seguida iniciando as coroutines relacionadas a cada tarefa.
                {
                    //Inicie as coroutines da fase aqui.
                    StartCoroutine(f1_caixas);
                    StartCoroutine(f2_sujeiras);
                }

                Debug.Log(GerenciadorCenas.cenaAtual.name + ": Iniciando tarefas");
                break;
            case "Fase 4": //Verificando se a cena atual é a Fase 4.
                f1_caixas = IniciarF1Caixas(10f);
                f2_sujeiras = IniciarF2Sujeira(25f);
                f4_filas = IniciarF4Filas(5f);
                f4_telefone = IniciarF4Tel(30f);
                GerenciadorInterface.instancia.clientesPerdidos.SetActive(true);
                contador.rNum = 3; //Atribuindo rNum para 3, uma vez que na quarta fase a hora extra é um evento garantido.

                if (contador.contando) //Verificando se o contador foi iniciado, em seguida iniciando as coroutines relacionadas a cada tarefa.
                {
                    StartCoroutine(f1_caixas);
                    StartCoroutine(f2_sujeiras);
                    StartCoroutine(f4_filas); //Iniciando a coroutine das filas do caixa.
                    StartCoroutine(f4_telefone); //Iniciando a coroutine do telefone.
                }

                Debug.Log(GerenciadorCenas.cenaAtual.name + ": Iniciando tarefas");
                break;
        }
    }

    void Update()
    {
        if (!contador.contando) //Verificando se o contador foi pausado, em seguida também pausando as coroutines relacionadas a cada tarefa.
        {
            StopAllCoroutines();
        }
    }

    IEnumerator IniciarF1Caixas(float espera)
    {
        while (true)
        {
            yield return new WaitForSeconds(espera); //Aguardando o tempo de espera antes de rodar a coroutine.
            iniciandoCaixas = true;
        }
    }

    IEnumerator IniciarF2Sujeira(float espera) //Método relacionado à mecânica do telefone referente a fase 4, juntamente à lógica do intervalo de tempo entre cada ciclo da coroutine.
    {
        while (true)
        {
            yield return new WaitForSeconds(espera);
            iniciandoSujeira = true;
        }
    }

    //Crie novas coroutines para as demais tarefas aqui.

    IEnumerator IniciarF4Filas(float espera) //Coroutine que inicia a tarefa do caixa na fase 4.
    {
        while (true)
        {
            yield return new WaitForSeconds(espera); //Aguardando o tempo de espera antes de rodar a coroutine.
            int r = Random.Range(0, 5); //Rodando uma chance aleatória para iniciar um NPC.

            if (r == 4) //Verificando se o valor foi atendido.
            {
                iniciandoFilas = true; //Indicando que um novo NPC deve ser gerado.
            }
        }
    }

    IEnumerator IniciarF4Tel(float espera) //Coroutine relacionada à mecânica do telefone referente a fase 4.
    {
        while (true)
        {
            yield return new WaitForSeconds(espera); //Aguardando o tempo de espera antes de rodar a coroutine.
            iniciandoTelefone = true; //Indicando se o telefone deve começar a tocar.
        }
    }
}
