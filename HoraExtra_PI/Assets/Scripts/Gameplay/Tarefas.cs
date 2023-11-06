using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Tarefas : MonoBehaviour //Classe relacionada as Coroutines que iniciam as tarefas e as mantém sendo atualizadas.
{
    private Contador contador; //Recebe a instância da classe Contador.
    private IEnumerator f1_caixas; //Recebe a coroutine da tarefa da fase 1 (Depósito);
    private IEnumerator f2_sujeiras;
    private IEnumerator f3_produtos;
    private IEnumerator f4_filas; //Recebe a coroutine da tarefa principal da fase 4 (Operação de caixa).
    private IEnumerator f4_telefone; //Recebe a coroutine da tarefa secundária da fase 4 (Atender o telefone).

    public static bool iniciandoCaixas = false, iniciandoSujeira = false, iniciandoProdutos = false, iniciandoFilas = false, iniciandoTelefone = false; //Indicam se as determinadas tarefas foram iniciadas.
    public TMP_Text notificacaoUI; //Recebe o componente de texto onde são exibidas as notificações de tarefas.

    void Start()
    {
        contador = GetComponent<Contador>(); //Instanciando a classe Contador.
        //Atribua as coroutines às suas respectivas funções aqui.
        f1_caixas = IniciarF1Caixas(2f);
        f2_sujeiras = IniciarF2Sujeira(10f);
        f3_produtos = IniciarF3Produtos(0f);
        f4_filas = IniciarF4Filas(5f); //Atribuindo a coroutine fase4_tarefaA à função correspondente, determinando o intervalo de tempo entre cada ciclo.
        f4_telefone = IniciarF4Tel(5f); //Atribuindo a coroutine fase4_tarefaB à função correspondente, determinando o intervalo de tempo entre cada ciclo.

        if (GerenciadorCenas.cenaAtual.name == "Fase 1") //Verificando se a cena atual é a Fase 1.
        {
            contador.rNum = 0; //Atribuindo rNum para 0, uma vez que na primeira fase a hora extra nunca acontece.

            if (contador.contando) //Verificando se o contador foi iniciado, em seguida iniciando as coroutines relacionadas a cada tarefa.
            {
                StartCoroutine(f1_caixas);
            }

            Debug.Log(GerenciadorCenas.cenaAtual.name + ": Iniciando tarefas");
        }
        else if (GerenciadorCenas.cenaAtual.name == "Fase 2") //Verificando se a cena atual é a Fase 2.
        {
            contador.rNum = Random.Range(0, 4); //Rodando uma chance de 25% entre 0 e 3 de se iniciar uma hora extra nesta fase.

            if (contador.contando) //Verificando se o contador foi iniciado, em seguida iniciando as coroutines relacionadas a cada tarefa.
            {
                StartCoroutine(f1_caixas);
                StartCoroutine(f2_sujeiras);
            }

            Debug.Log(GerenciadorCenas.cenaAtual.name + ": Iniciando tarefas");
        }
        else if (GerenciadorCenas.cenaAtual.name == "Fase 3") //Verificando se a cena atual é a Fase 3.
        {
            contador.rNum = Random.Range(0, 4); //Rodando uma chance de 25% entre 0 e 3 de se iniciar uma hora extra nesta fase.

            if (contador.contando) //Verificando se o contador foi iniciado, em seguida iniciando as coroutines relacionadas a cada tarefa.
            {
                //Inicie as coroutines da fase aqui.
                StartCoroutine(f1_caixas);
                StartCoroutine(f2_sujeiras);
                StartCoroutine(f3_produtos);
            }

            Debug.Log(GerenciadorCenas.cenaAtual.name + ": Iniciando tarefas");
        }
        else if (GerenciadorCenas.cenaAtual.name == "Fase 4") //Verificando se a cena atual é a Fase 4.
        {
            contador.rNum = 3; //Atribuindo rNum para 3, uma vez que na quarta fase a hora extra é um evento garantido.

            if (contador.contando) //Verificando se o contador foi iniciado, em seguida iniciando as coroutines relacionadas a cada tarefa.
            {
                StartCoroutine(f1_caixas);
                StartCoroutine(f2_sujeiras);
                StartCoroutine(f3_produtos);
                StartCoroutine(f4_filas); //Iniciando a coroutine das filas do caixa.
                StartCoroutine(f4_telefone); //Iniciando a coroutine do telefone.
            }

            Debug.Log(GerenciadorCenas.cenaAtual.name + ": Iniciando tarefas");
        }

        notificacaoUI.text = null;
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
            notificacaoUI.text = "Há novas mercadorias aguardando o transporte."; //Exibindo a notificação de tarefa na tela.
        }
    }

    IEnumerator IniciarF2Sujeira(float espera) //Método relacionado à mecânica do telefone referente a fase 4, juntamente à lógica do intervalo de tempo entre cada ciclo da coroutine.
    {
        while (true)
        {
            yield return new WaitForSeconds(espera);
            iniciandoSujeira = true;
            notificacaoUI.text = "Os corredores precisam de limpeza.";
        }
    }

    IEnumerator IniciarF3Produtos(float espera)
    {
        while (true)
        {
            yield return new WaitForSeconds(espera);
            iniciandoProdutos = true;
        }
    }

    //Crie novas coroutines para as demais tarefas aqui.

    IEnumerator IniciarF4Filas(float espera) //Coroutine que inicia a tarefa do caixa na fase 4.
    {
        while (true)
        {
            yield return new WaitForSeconds(espera); //Aguardando o tempo de espera antes de rodar a coroutine.
            int r = Random.Range(0, 10); //Rodando uma chance aleatória para iniciar um NPC.

            if (r == 5) //Verificando se o valor foi atendido.
            {
                iniciandoFilas = true; //Indicando que um novo NPC deve ser gerado.
                notificacaoUI.text = "Há um novo cliente na fila."; //Exibindo a notificação de tarefa na tela.
            }
        }
    }

    IEnumerator IniciarF4Tel(float espera) //Coroutine relacionada à mecânica do telefone referente a fase 4.
    {
        while (true)
        {
            yield return new WaitForSeconds(espera); //Aguardando o tempo de espera antes de rodar a coroutine.
            int r = Random.Range(0, 10); //Rodando uma chance aleatória de 50% entre 0 e 1, para iniciar o telefone.

            if (r == 5) //Verificando se o valor foi atendido.
            {
                iniciandoTelefone = true; //Indicando se o telefone deve começar a tocar.
                notificacaoUI.text = "O telefone está tocando."; //Exibindo a notificação de tarefa na tela.
            }
        }
    }
}
