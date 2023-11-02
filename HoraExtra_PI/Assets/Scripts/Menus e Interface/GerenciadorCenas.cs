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
                    dialogos.Enqueue("Isso");
                    dialogos.Enqueue("É");
                    dialogos.Enqueue("Um");
                    dialogos.Enqueue("Teste");
                    proximaCena = "Cena 2";
                    break;
                case "Cena 2":
                    dialogos.Enqueue("2Isso");
                    dialogos.Enqueue("2É");
                    dialogos.Enqueue("2Um");
                    dialogos.Enqueue("2Teste");
                    proximaCena = "Fase 1";
                    break;
                case "Cena 3":
                    dialogos.Enqueue("3Isso");
                    dialogos.Enqueue("3É");
                    dialogos.Enqueue("3Um");
                    dialogos.Enqueue("3Teste");
                    proximaCena = "Fase 2";
                    break;
                case "Cena 4":
                    dialogos.Enqueue("4Isso");
                    dialogos.Enqueue("4É");
                    dialogos.Enqueue("4Um");
                    dialogos.Enqueue("4Teste");
                    proximaCena = "Cena 5";
                    break;
                case "Cena 5":
                    dialogos.Enqueue("5Isso");
                    dialogos.Enqueue("5É");
                    dialogos.Enqueue("5Um");
                    dialogos.Enqueue("5Teste");
                    proximaCena = "Fase 3";
                    break;
                case "Cena 6":
                    dialogos.Enqueue("6Isso");
                    dialogos.Enqueue("6É");
                    dialogos.Enqueue("6Um");
                    dialogos.Enqueue("6Teste");
                    proximaCena = "Cena 7";
                    break;
                case "Cena 7":
                    dialogos.Enqueue("7Isso");
                    dialogos.Enqueue("7É");
                    dialogos.Enqueue("7Um");
                    dialogos.Enqueue("7Teste");
                    proximaCena = "Cena 8";
                    break;
                case "Cena 8":
                    dialogos.Enqueue("8Isso");
                    dialogos.Enqueue("8É");
                    dialogos.Enqueue("8Um");
                    dialogos.Enqueue("8Teste");
                    proximaCena = "Fase 4";
                    break;
                case "Cena 9":
                    dialogos.Enqueue("9Isso");
                    dialogos.Enqueue("9É");
                    dialogos.Enqueue("9Um");
                    dialogos.Enqueue("9Teste");
                    proximaCena = "Cena 10";
                    break;
                case "Cena 10":
                    dialogos.Enqueue("10Isso");
                    dialogos.Enqueue("10É");
                    dialogos.Enqueue("10Um");
                    dialogos.Enqueue("10Teste");
                    proximaCena = "Menu Principal";
                    break;
            }
        }

        Debug.Log("cenaAnterior = " + cenaAnterior);
        Debug.Log("proximaCena = " + proximaCena);
    }

    void Update()
    {
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
