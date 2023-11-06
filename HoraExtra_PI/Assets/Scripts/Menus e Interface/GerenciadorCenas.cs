using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GerenciadorCenas : MonoBehaviour //Classe que gerencia as cenas do jogo e governa a progressão do jogo.
{
    private Queue<string> dialogos = new Queue<string>(); //Fila que recebe as linhas de diálogos que são exibidas em cada cutscene.
    private string tipoCena; //Recebe o tipo da cena atual, funcionando como um rótulo para cada fase.
    private string proximaCena; //Armazena o nome da próxima cena a ser carregada.

    public static string cenaAnterior; //Armazena o nome da cena atual, que é utilizada para que o jogo retorne a ela quando necessário.
    public static Scene cenaAtual; //Armazena a cena atual.
    public GameObject objPausa; //Recebe o game object do painel de pausa.
    public GameObject objCC; //Recebe o game object Chave de Cenas.
    public ChaveCenas cc; //Recebe a instância da classe ChaveCenas.
    public TMP_Text dialogosUI; //Recebe o componente de texto onde são exibidos os diálogos na tela.

    void Awake()
    {
        objCC.SetActive(true); //Ativando o game object Chave de Cenas.
        cenaAtual = SceneManager.GetActiveScene(); //Armazenando a cena atualmente ativa.
        cenaAnterior = cenaAtual.name; //Armazenando o nome da cena atualmente ativa.
        Debug.Log("cenaAtual = " + cenaAtual.name);

        if (cenaAtual.name == "Fase 1" || cenaAtual.name == "Fase 2" || cenaAtual.name == "Fase 3" || cenaAtual.name == "Fase 4") //Verificando se a cena atual é alguma das fases do jogo.
        {
            tipoCena = "Gameplay"; //Rotulando qualquer uma das cenas acima como do tipo Gameplay.

            switch (cenaAtual.name) //Verificando qual fase está atualmente ativa, em seguida determinando o valor da meta de pontuação de cada fase e armazenando a cena seguinte.
            {
                case "Fase 1":
                    Pontuacao.meta = 500;
                    proximaCena = "Cena 3";
                    break;
                case "Fase 2":
                    Pontuacao.meta = 1000;
                    proximaCena = "Cena 4";
                    break;
                case "Fase 3":
                    Pontuacao.meta = 1500;
                    proximaCena = "Cena 6";
                    break;
                case "Fase 4":
                    Pontuacao.meta = 2000;
                    proximaCena = "Cena 9";
                    break;
            }
        }
        else //Verificando o restante das cenas.
        {
            tipoCena = "Cutscene"; //Rotulando qualquer uma das demais cenas como do tipo Cutscene.

            switch (cenaAtual.name) //Verificando qual fase está atualmente ativa, em seguida inserindo as linhas de diálogo à fila e armazenando a cena seguinte.
            {
                case "Cena 1":
                    dialogos.Enqueue("Bem vindo ao Hora Extra.");
                    dialogos.Enqueue("Este é apenas um protótipo e bastante coisa vai mudar.");
                    dialogos.Enqueue("O jogo se passa em um supermercado e você deve realizar tarefas referentes à atividades de um funcionário de supermercado (duh).");
                    dialogos.Enqueue("Você deve alcançar a pontuação mínima para avançar em cada fase. Conforme avança, a meta cresce, e as tarefas da fase anterior passam a se acumular junto à da fase atual. Você um tempo de 2~4 minutos para alcançar a meta. Boa sorte.");
                    proximaCena = "Cena 2";
                    break;
                case "Cena 2":
                    dialogos.Enqueue("Na fase a seguir você está restrito ao depósito e deve empurrar as caixas para os locais corretos.");
                    dialogos.Enqueue("Empurre as caixas marrons para o local vermelho na tela, e as caixas cinzas para o local verde.");
                    dialogos.Enqueue("Tente não demorar demais, pois você tem um tempo para entregar ao local certo antes que os caminhões de estoque e delivery saiam.");
                    dialogos.Enqueue("");
                    proximaCena = "Fase 1";
                    break;
                case "Cena 3":
                    dialogos.Enqueue("Isso (3)");
                    dialogos.Enqueue("É (3)");
                    dialogos.Enqueue("Um (3)");
                    dialogos.Enqueue("Teste (3)");
                    proximaCena = "Fase 2";
                    break;
                case "Cena 4":
                    dialogos.Enqueue("Isso (4)");
                    dialogos.Enqueue("É (4)");
                    dialogos.Enqueue("Um (4)");
                    dialogos.Enqueue("Teste (4)");
                    proximaCena = "Cena 5";
                    break;
                case "Cena 5":
                    dialogos.Enqueue("Isso (5)");
                    dialogos.Enqueue("É (5)");
                    dialogos.Enqueue("Um (5)");
                    dialogos.Enqueue("Teste (5)");
                    proximaCena = "Fase 3";
                    break;
                case "Cena 6":
                    dialogos.Enqueue("Isso (6)");
                    dialogos.Enqueue("É (6)");
                    dialogos.Enqueue("Um (6)");
                    dialogos.Enqueue("Teste (6)");
                    proximaCena = "Cena 7";
                    break;
                case "Cena 7":
                    dialogos.Enqueue("Isso (7)");
                    dialogos.Enqueue("É (7)");
                    dialogos.Enqueue("Um (7)");
                    dialogos.Enqueue("Teste (7)");
                    proximaCena = "Cena 8";
                    break;
                case "Cena 8":
                    dialogos.Enqueue("Isso (8)");
                    dialogos.Enqueue("É (8)");
                    dialogos.Enqueue("Um (8)");
                    dialogos.Enqueue("Teste (8)");
                    proximaCena = "Fase 4";
                    break;
                case "Cena 9":
                    dialogos.Enqueue("Isso (9)");
                    dialogos.Enqueue("É (9)");
                    dialogos.Enqueue("Um (9)");
                    dialogos.Enqueue("Teste (9)");
                    proximaCena = "Cena 10";
                    break;
                case "Cena 10":
                    dialogos.Enqueue("Isso (10)");
                    dialogos.Enqueue("É (10)");
                    dialogos.Enqueue("Um (10)");
                    dialogos.Enqueue("Teste (10)");
                    proximaCena = "Menu Principal";
                    break;
            }
        }

        Debug.Log("cenaAnterior = " + cenaAnterior);
        Debug.Log("proximaCena = " + proximaCena);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            objPausa.SetActive(true);
        }

        while (tipoCena == "Gameplay") //Rodando enquanto uma cena de gameplay está ativa.
        {
            if (Pontuacao.resultado == "Vitoria") //Verificando se o resultado da fase foi de vitória, congelando o tempo em seguida.
            {
                cc.IniciarCena(proximaCena); //Carregando a próxima cena.
            }
            else if (Pontuacao.resultado == "Derrota") //Verificando se o resultado da fase foi de derrota.
            {
                cc.IniciarCena("Game Over"); //Carregando a cena de game over.
            }

            break;
        }

        while (tipoCena == "Cutscene") //Rodando enquanto uma cena de cutscene está ativa.
        {
            if (dialogos.TryPeek(out string texto)) //Verificando se há uma string na fila antes de tentar dar Peek no texto.
            {
                dialogosUI.text = texto; //Exibindo na tela o texto do topo da fila.
            }

            if (Input.GetKeyDown(KeyCode.Space)) //Verificando se a tecla Espaço foi pressionada, removendo o texto no topo da fila em seguida.
            {
                if (dialogos.Count != 0) //Verificando se a fila possui linhas de diálogo.
                {
                    dialogos.Dequeue(); //Removendo o texto no topo da fila.
                }
                else //Verificando se a fila não possui mais linhas de diálogo.
                {
                    cc.IniciarCena(proximaCena); //Carregando a próxima cena.
                }
            }

            break;
        }
    }
}
