using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GerenciadorCenas : MonoBehaviour //Classe que gerencia as cenas do jogo e governa a progressão do jogo.
{
    private Queue<string> dialogos = new Queue<string>(); //Fila que recebe as linhas de diálogos que são exibidas em cada cutscene.
    private string tipoCena; //Recebe o tipo da cena atual, funcionando como um rótulo para cada fase.
    private string proximaCena; //Armazena o nome da próxima cena a ser carregada.

    public static bool jogoPausado = false;
    public static string cenaAnterior; //Armazena o nome da cena atual, que é utilizada para que o jogo retorne a ela quando necessário.
    public static Scene cenaAtual; //Armazena a cena atual.
    public GameObject objCC; //Recebe o game object Chave de Cenas.
    public ChaveCenas cc; //Recebe a instância da classe ChaveCenas.

    void OnEnable()
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
                    dialogos.Enqueue("O jogo se passa em um supermercado e você deve realizar tarefas referentes às atividades de um funcionário de supermercado (duh).");
                    dialogos.Enqueue("Você deve alcançar a pontuação mínima para avançar em cada fase. Conforme avança, a meta cresce, e as tarefas da fase anterior passam a se acumular junto à da fase atual. Você um tempo de 4 minutos para alcançar a meta.");
                    proximaCena = "Cena 2";
                    break;
                case "Cena 2":
                    dialogos.Enqueue("Na fase a seguir você está restrito ao depósito e deve empurrar as caixas para os locais corretos.");
                    dialogos.Enqueue("Empurre as caixas marrons para o círculo azul na tela, e as caixas cinzas para o círculo verde.");
                    dialogos.Enqueue("Empurrar caixas para o local errado te fará perder pontos, além de destruir a caixa. Tome cuidado.");
                    dialogos.Enqueue("Após certo tempo, o círculo verde aparece e desaparece periodicamente (simulando a saída/chegada do caminhão de delivery), e se você não tiver entregue pelo menos duas caixas nele, perderá pontos. Caso tenha feito, ganhará pontos referente à quantidade de caixas entregues, quando ele sair.");
                    dialogos.Enqueue("Boa sorte.");
                    proximaCena = "Fase 1";
                    break;
                case "Cena 3":
                    dialogos.Enqueue("Parabéns.");
                    dialogos.Enqueue("De agora em diante há uma nova mecânica chamada 'Hora Extra'. Com isso, as duas próximas fases, terão uma chance de ter a Hora Extra ativada.");
                    dialogos.Enqueue("Durante o período de Hora Extra, a meta para avançar de fase é dobrada, junto com o acréscimo de 1 minuto no tempo da fase. A Hora Extra é aleatória, então nem sempre as coisas podem sair como o esperado.");
                    dialogos.Enqueue("Na fase a seguir você pode sair do depósito, agora você também é responsável pela limpeza. Lembre-se, as tarefas no depósito ainda estarão disponíveis, e possuem as mesmas regras.");
                    dialogos.Enqueue("Na sala abaixo do depósito na tela, se encontram os equipamentos de limpeza em diferentes cores. As sujeiras surgirão no corredor do supermercado, e você deve estar segurando o equipamento cujo a cor é referente à sujeira. Para limpá-la basta andar por cima dela.");
                    dialogos.Enqueue("Evite deixar os corredores sujos por muito tempo, pois com mais de 5 sujeiras, você começará a perder pontos. Além disso, você não conseguirá interagir com outros objetos ou equipamentos enquanto estiver segurando um item, como o equipamento de limpeza. Guarde-o no seu local de origem antes.");
                    dialogos.Enqueue("Começando.");
                    proximaCena = "Fase 2";
                    break;
                case "Cena 4":
                    dialogos.Enqueue("Muito bem.");
                    dialogos.Enqueue("De agora em diante as coisas começam a complicar, uma nova tarefa lhe aguarda.");
                    proximaCena = "Cena 5";
                    break;
                case "Cena 5":
                    dialogos.Enqueue("Na próxima fase, além das tarefas anteriores, você deve organizar as prateleiras.");
                    dialogos.Enqueue("Haverão caixas de várias cores espalhadas pelos corredores. Em cada uma delas você pode pegar um produto para colocar nas prateleiras (os retângulos grandes) de mesma cor.");
                    dialogos.Enqueue("Preste atenção. Colocar produtos nas prateleiras erradas lhe fará perder pontos.");
                    dialogos.Enqueue("Mais produtos surgirão nas caixas com o tempo, e lembre-se de sempre estar checando as caixas e realizando a reposição. Isso dá bastante ponto.");
                    proximaCena = "Fase 3";
                    break;
                case "Cena 6":
                    dialogos.Enqueue("Certo.");
                    dialogos.Enqueue("A próxima é a quarta e última fase, nela a Hora Extra é garantida e sempre acontece (por motivos de história).");
                    dialogos.Enqueue("Ela pode ser bem difícil, pois muitos pontos serão necessários para avançar.");
                    proximaCena = "Cena 7";
                    break;
                case "Cena 7":
                    dialogos.Enqueue("Nesta fase, você tem duas tarefas principais.");
                    dialogos.Enqueue("A primeira e mais importante é a operação do caixa.");
                    dialogos.Enqueue("Você deve interagir com os retângulos cinzas bem na parte de baixo do cenário sempre que houver um cliente aguardando na fila (um objeto em forma de capsula parado próximo ao caixa).");
                    dialogos.Enqueue("Apresse-se sempre que houver clientes na fila, pois eles não aguardarão para sempre e irão embora. Se mais de 3 clientes irem embora, é Game Over.");
                    proximaCena = "Cena 8";
                    break;
                case "Cena 8":
                    dialogos.Enqueue("A segunda tarefa é o telefone de onde vem os pedidos de delivery.");
                    dialogos.Enqueue("Ele é representado pelo quadrado vermelho na parede da sala ao lado dos caixas.");
                    dialogos.Enqueue("O telefone tocará de tempos em tempos, e você deve atendê-lo antes que pare de tocar. Não atendê-lo fará você perder muitos pontos.");
                    dialogos.Enqueue("Por enquanto pode ser um pouco difícil de saber quando ele estiver tocando, pretendemos colocar som na versão final, para que facilite perceber quando ele estiver tocando.");
                    dialogos.Enqueue("Boa sorte.");
                    proximaCena = "Fase 4";
                    break;
                case "Cena 9":
                    dialogos.Enqueue("Essas foram as 4 fases do jogo.");
                    dialogos.Enqueue("Como dito antes, coisas possívelmente vão mudar, e essa versão serve principalmente para testar o balanceamento do jogo e colher feedback.");
                    proximaCena = "Cena 10";
                    break;
                case "Cena 10":
                    dialogos.Enqueue("Obrigado por jogar.");
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
            if (!jogoPausado)
            {
                GerenciadorInterface.instancia.pausa.SetActive(true);
                Cursor.visible = true;
                jogoPausado = true;
                Time.timeScale = 0;
                Debug.Log("jogoPausado = " + jogoPausado);
            }
            else
            {
                Time.timeScale = 1;
                GerenciadorInterface.instancia.pausa.SetActive(false);
                Cursor.visible = false;
                jogoPausado = false;
                Debug.Log("jogoPausado = " + jogoPausado);
            }
        }

        if (tipoCena == "Gameplay") //Verifica se uma cena de gameplay está ativa.
        {
            Cursor.visible = false;

            if (Pontuacao.resultado == "Vitoria") //Verificando se o resultado da fase foi de vitória, congelando o tempo em seguida.
            {
                cc.IniciarCena(proximaCena); //Carregando a próxima cena.
                Debug.Log(Pontuacao.resultado);
            }
            else if (Pontuacao.resultado == "Derrota") //Verificando se o resultado da fase foi de derrota.
            {
                cc.IniciarCena("Game Over"); //Carregando a cena de game over.
                Cursor.visible = true;
                Debug.Log(Pontuacao.resultado);
            }
        }
        else if (tipoCena == "Cutscene") //Verifica se uma cena de cutscene está ativa.
        {
            Cursor.visible = false;

            if (!jogoPausado)
            {
                if (dialogos.TryPeek(out string texto)) //Verificando se há uma string na fila antes de tentar dar Peek no texto.
                {
                    GerenciadorInterface.instancia.txtDialogos.text = texto; //Exibindo na tela o texto do topo da fila.
                }

                if (Input.GetKeyDown(KeyCode.Space)) //Verificando se a tecla Espaço foi pressionada, removendo o texto no topo da fila em seguida.
                {
                    if (dialogos.Count != 0) //Verificando se a fila possui linhas de diálogo.
                    {
                        dialogos.Dequeue(); //Removendo o texto no topo da fila.
                        GerenciadorInterface.instancia.passarDialogo.GetComponent<Animator>().SetTrigger("Exibir");
                    }
                }

                if (dialogos.Count == 0) //Verificando se a fila não possui mais linhas de diálogo.
                {
                    cc.IniciarCena(proximaCena); //Carregando a próxima cena.
                }
            }
        }
    }
}
