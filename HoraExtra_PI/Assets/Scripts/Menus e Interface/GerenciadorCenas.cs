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
            Cursor.visible = false;

            switch (cenaAtual.name) //Verificando qual fase está atualmente ativa, em seguida determinando o valor da meta de pontuação de cada fase e armazenando a cena seguinte.
            {
                case "Fase 1":
                    Pontuacao.meta = 400;
                    proximaCena = "Cena 3";
                    break;
                case "Fase 2":
                    Pontuacao.meta = 800;
                    proximaCena = "Cena 5";
                    break;
                case "Fase 3":
                    Pontuacao.meta = 1200;
                    proximaCena = "Cena 8";
                    break;
                case "Fase 4":
                    Pontuacao.meta = 1600;
                    proximaCena = "Cena 12";
                    break;
            }
        }
        else //Verificando o restante das cenas.
        {
            tipoCena = "Cutscene"; //Rotulando qualquer uma das demais cenas como do tipo Cutscene.
            Cursor.visible = false;

            switch (cenaAtual.name) //Verificando qual fase está atualmente ativa, em seguida inserindo as linhas de diálogo à fila e armazenando a cena seguinte.
            {
                case "Cena 1":
                    dialogos.Enqueue("Chefe: Você é a recém-contratada não é? Como é o seu nome mesmo?");
                    dialogos.Enqueue("Emily: Sou a Emily, senhor.");
                    dialogos.Enqueue("Chefe: O QUE VOCÊ PENSA QUE ESTÁ FAZENDO, EMILY?!");
                    dialogos.Enqueue("Emily: T-trabalhando senhor. Quer dizer, acabei de chegar.");
                    dialogos.Enqueue("Chefe: Você vai trabalhar no depósito hoje. Precisamos de gente para descarregar umas mercadorias que chegaram ontem. Você tem trabalho a fazer lá.");
                    dialogos.Enqueue("Emily: Mas senhor, eu nã-");
                    dialogos.Enqueue("Chefe: Sem ''mas'', você acabou de chegar e tá querendo decidir alguma coisa?");
                    dialogos.Enqueue("Chefe: Coloque isso na sua cabeça: EU digo o que você deve ou não fazer.");
                    dialogos.Enqueue("Emily: S-sim, senhor. Estou indo.");
                    proximaCena = "Cena 2";
                    break;
                case "Cena 2":
                    dialogos.Enqueue("David: Ah, você deve ser a novata, deu pra ouvir os gritos.");
                    dialogos.Enqueue("David: Se acostume, é como as coisas funcionam por aqui. Prazer, David.");
                    dialogos.Enqueue("David: Pelo visto vou ter que brincar de ser professor. Que saco.");
                    dialogos.Enqueue("David: Vamos lá. Tá vendo aquele caminhão azul? Ele traz as mercadorias que ficamos encarregados de preparar para que sejam dispostas no pátio. Elas devem ser empurradas até aqui.");
                    dialogos.Enqueue("David: Há também os produtos que vem daquela esteira, preparados serem entregues nas casas dos nossos clientes ao longo do dia, através daquele outro caminhão vermelho. Ele obviamente não fica aqui para sempre, então quando ele estiver, lembre-se de entregar pelo menos duas caixas, ou saímos no prejuízo.");
                    dialogos.Enqueue("Emily: Ok, acho que entendi. Empurrar as caixas marrons do caminhão azul até ao canto com as prateleiras. E empurrar as caixas cinzas até caminhão vermelho. Parece simples.");
                    dialogos.Enqueue("David: É simples. Até as suas costas começarem a reclamar. Hahaha.");
                    dialogos.Enqueue("David: Uma última coisa.");
                    dialogos.Enqueue("David: Você deve ter percebido que estamos em falta de pessoal por aqui. Isso é porque o nosso ''bom'' chefinho decidiu transferir alguns dos nossos para outra filial contra a vontade deles. Disse que ''não estavam dando duro o suficiente''.");
                    dialogos.Enqueue("David: *Suspiro*");
                    dialogos.Enqueue("David: Então, ao menos que queira acabar como eles, sugiro que dê o melhor de si.");
                    dialogos.Enqueue("Emily: Certo, obrigada. Ao trabalho, então.");
                    proximaCena = "Fase 1";
                    break;
                case "Cena 3":
                    dialogos.Enqueue("Emily: Droga, ele não mentiu, minha coluna tá começando a doer.");
                    dialogos.Enqueue("Emily: *Ai*");
                    dialogos.Enqueue("Emily: Bem que amanhã eu poderia finalmente operar o caixa, ficar sentada um pouco. Já foram três dias empurrando caixas, eu não aguento mais.");
                    proximaCena = "Cena 4";
                    break;
                case "Cena 4":
                    dialogos.Enqueue("David: Espero que esteja pronta para mais trabalho duro. Embora, pela sua cara, a dorzinha nas costas já começou a cobrar.");
                    dialogos.Enqueue("David: Bem, paciência.");
                    dialogos.Enqueue("David: Antes de você chegar, já me encarregaram de explicar o que você vai fazer hoje. Aposto que você vai ''adorar''. Hahaha.");
                    dialogos.Enqueue("David: Hoje você fica responsável pela limpeza.");
                    dialogos.Enqueue("David: A Marta geralmente faz isso, mas tá de atestado, e não tenha raiva da moça, foi um sacrifício pra coitada conseguir esses dias de ''folga''.");
                    dialogos.Enqueue("David: Além disso, o chefe disse que já era a hora de você ''prestar para mais de uma coisa nessa empresa''.");
                    dialogos.Enqueue("Emily: *Grr*");
                    dialogos.Enqueue("David: O quê? Não me olhe assim. Não fui eu que falei.");
                    dialogos.Enqueue("David: A propósito, vamos logo com isso, eu não vejo a hora de ir logo pra casa.");
                    dialogos.Enqueue("David: Como pode ver, os clientes e outros funcionários espalham todo tipo de sujeira por aqui.");
                    dialogos.Enqueue("David: Líquidos derramados, vidros quebrados, sujeira dos sapatos... sério, eu não sei como podem ser tão desastrados.");
                    dialogos.Enqueue("David: Lembre-se de usar os instrumentos de limpeza corretos para cada tipo de sujeira. A vassoura para cacos de vidro, o esfregão para marcas de sapato e o rodo para líquidos. Tente não deixar muita sujeira acumulada, pois isso irá te custar caro.");
                    dialogos.Enqueue("David: Ah, e sinto muito, mas ainda é preciso que você continue o trabalho no depósito enquanto isso. E torça para que o chefinho não mande fazer hora extra hoje, você não vai gostar nadinha disso.");
                    dialogos.Enqueue("Emily: O QUÊ?!");
                    dialogos.Enqueue("David: Boa sorte, colega.");
                    proximaCena = "Fase 2";
                    break;
                case "Cena 5":
                    dialogos.Enqueue("Emily: Eu não fazia ideia de que seria assim. Eu deveria estar trabalhando no caixa, poxa. Ao invés disso, quase duas semanas tendo que fazer funções de outros funcionários, por uma decisão do próprio chefe em transferir eles.");
                    dialogos.Enqueue("Emily: Será que todos os empregos são assim?");
                    dialogos.Enqueue("Emily: Hum, tá bom, suponho que eu deveria ser grata por ter um emprego, afinal de contas.");
                    dialogos.Enqueue("Emily: Ainda assim, meu corpo claramente não estava pronto pra isso. Nossa, que dor na coluna.");
                    dialogos.Enqueue("Emily: *Cof cof*");
                    dialogos.Enqueue("Emily: Ah, que ótimo a poeira está me prejudicando também.");
                    proximaCena = "Cena 6";
                    break;
                case "Cena 6":
                    dialogos.Enqueue("Chefe: Que bonito... isso é hora de chegar?");
                    dialogos.Enqueue("Emily: Desculpe senhor, eu atrasei dois minutos, não acordei muito bem hoje.");
                    dialogos.Enqueue("Chefe: Eu não me importo, minha filha. Você não foi contratada pra ficar falando da sua vida. E sim pra chegar NA HORA e fazer o seu trabalho.");
                    dialogos.Enqueue("Chefe: Hoje você vai repor as gôndolas. Chegaram muitas mercadorias ao longo da semana, e os demais de vocês, incompetentes, não estão dando conta de organizar elas corretamente.");
                    dialogos.Enqueue("Chefe: As caixas estão acumulando nos corredores e não há produtos o suficiente expostos para que os clientes gastem o dinheirinho cheiroso deles.");
                    dialogos.Enqueue("Chefe: E acho que não preciso te lembrar que: se os clientes não gastam dinheiro, VOCÊ NÃO GANHA DINHEIRO. Então mexe logo essa bunda e vai procurar o David que ele vai te explicar o que você deve fazer.");
                    proximaCena = "Cena 7";
                    break;
                case "Cena 7":
                    dialogos.Enqueue("Emily: Ufa, te encontrei. O chefe quer que eu trabalhe com a reposição hoje, e ele não tá nada satisfeito com a situação das gôndolas.");
                    dialogos.Enqueue("David: *Suspiro*");
                    dialogos.Enqueue("David: Me conta uma novidade.");
                    dialogos.Enqueue("David: Eu juro que eu deveria pedir um aumento, por estar fazendo a função de professor nessa desgraça de lugar.");
                    dialogos.Enqueue("Emily: Talvez você devesse, tenho certeza de que ele não vai resistir a este seu charme e entusiasmo.");
                    dialogos.Enqueue("David: Ora ora, tá se sentindo a engraçadona né? Bora ver se o seu senso de humor continua intacto até o fim do dia então.");
                    dialogos.Enqueue("David: Os produtos são divididos em quatro tipos, sendo frios, higiene, limpeza, comida e condimentos. Você deve retirá-los das suas respectivas caixas e os distribuir nas gôndolas corretas, conforme as cores.");
                    dialogos.Enqueue("David: Não preciso explicar o porquê de não ser ideal ter água sanitária no meio de um monte de alimentos, não é mesmo?");
                    dialogos.Enqueue("Emily: *revirando os olhos*");
                    dialogos.Enqueue("David: Pois bem, além disso, suas outras tarefas te esperam, nada que você já não tenha feito antes.");
                    dialogos.Enqueue("David: Se acostume, isso não parece que vai mudar tão cedo.");
                    dialogos.Enqueue("Emily: Como se eu tivesse escolha...");
                    dialogos.Enqueue("David: É aí que você se engana. Você sempre tem uma escolha. Bom, mãos à obra.");
                    proximaCena = "Fase 3";
                    break;
                case "Cena 8":
                    dialogos.Enqueue("Emily: ...se eu não tivesse tanta coisa pra pagar, tanta coisa para comprar, eu juro que não estaria mais passando por isso.");
                    dialogos.Enqueue("Emily: ''Vai morar sozinha Emily, vai ser legal, ser independente é legal''.");
                    dialogos.Enqueue("Emily: Do que adianta se eu só sirvo pra encher o bolso de um chefe desgraçado que não dá a mínima para os próprios funcionários, e que a essa altura nem se lembra mais pra que me contratou.");
                    dialogos.Enqueue("Emily: Espero que ao menos sobre algum dinheiro para me divertir. Não aguento mais essa rotina casa-purgatór- digo, trabalho, todos os dias.");
                    proximaCena = "Cena 9";
                    break;
                case "Cena 9":
                    dialogos.Enqueue("Chefe: Você vai operar os caixas hoje.");
                    dialogos.Enqueue("Emily: O quê? Sério? Como assim?");
                    dialogos.Enqueue("Chefe: Tá surda? Você vai operar os caixas. OS caixas.");
                    dialogos.Enqueue("Chefe: Há dois caixas que estão operáveis e não há ninguém no momento. Vai ver com a Marta que ela vai explicar o que você deve fazer.");
                    dialogos.Enqueue("Emily: Marta, por quê a Marta? Cadê o David?");
                    dialogos.Enqueue("Chefe: Já foi tarde.");
                    dialogos.Enqueue("Chefe: Por quinze anos eu tolerei aquele senso de humor ridículo, aquela cara de desmotivado. Pro bonitão decidir que logo hoje deveria me pedir um aumento. Hahaha. Muito engraçado.");
                    dialogos.Enqueue("Chefe: Quem sabe você ainda o encontra se preparando para ir embora.");
                    dialogos.Enqueue("Chefe: A propósito. O que você ainda tá fazendo aqui?");
                    dialogos.Enqueue("Chefe: AO TRABALHO, GAROTA!");
                    dialogos.Enqueue("Chefe: Se eu souber de clientes saindo insatisfeitos por não terem sido atendidos, VOCÊ VAI PRA RUA!");
                    dialogos.Enqueue("Chefe: E EU NÃO QUERO SABER DE VOCÊ PERDENDO TEMPO INDO AO BANHEIRO DE NOVO.");
                    proximaCena = "Cena 10";
                    break;
                case "Cena 10":
                    dialogos.Enqueue("Emily: David, o que aconteceu?");
                    dialogos.Enqueue("David: Fui mandado embora, infelizmente... ou felizmente... sei lá.");
                    dialogos.Enqueue("Emily: Mas logo você? Você tá há tanto tempo aqui. E agora?");
                    dialogos.Enqueue("David: Ora, exatamente. Hehe.");
                    dialogos.Enqueue("David: Percebi o quão pouco eu ganhava tendo trabalhado por tanto tempo nessa empresa, tendo feito tanta coisa por aqui. Parecia injusto.");
                    dialogos.Enqueue("David: Obviamente aquele demônio não levou numa boa, entendeu como uma afronta. Me chamou de preguiçoso, imprestável, blá blá blá...");
                    dialogos.Enqueue("David: E aqui estamos.");
                    dialogos.Enqueue("Emily: Mas por que você fez isso? Não precisava ter levado a sério.");
                    dialogos.Enqueue("Emily: E como você pode estar tão tranquilo?");
                    dialogos.Enqueue("David: Olha Emily, você ainda vai chegar nesse momento em que você vai estar cansada disso aqui e vai ter que tomar uma decisão. O resultado pode não ser o esperado, pode ser frustrante inicialmente, mas ao longo prazo, vai ter vindo para melhor.");
                    dialogos.Enqueue("Emily: Não entendi. Eu não quero perder esse emprego, eu preciso dele...");
                    dialogos.Enqueue("David: Eu também achei que precisava. Mas depois percebi que não vale a pena.");
                    dialogos.Enqueue("David: Você vai perceber isso também.");
                    dialogos.Enqueue("David: Comece pesquisando sobre seus direitos, você, eu, não deveríamos passar por isso.");
                    dialogos.Enqueue("David: Bom, não se preocupe comigo.");
                    dialogos.Enqueue("David: Boa sorte daqui pra frente.");
                    proximaCena = "Cena 11";
                    break;
                case "Cena 11":
                    dialogos.Enqueue("Marta: A mocinha já terminou de chorar?");
                    dialogos.Enqueue("Emily: Hum? Do que você tá falan-");
                    dialogos.Enqueue("Marta: Ah, tanto faz. Presta atenção, que eu só vou explicar uma vez.");
                    dialogos.Enqueue("Marta: Nós temos dois caixas operantes, por onde os clientes vão formar fila para terem suas compras passadas e irem embora.");
                    dialogos.Enqueue("Marta: Tudo que você deve fazer é passar as compras para que eles possam voltar felizes da vida para suas lindas casas.");
                    dialogos.Enqueue("Marta: Assim como eu, você, qualquer pessoa, os clientes não gostam de ficar esperando muito tempo na fila, e irão embora se não forem atendidos por muito tempo.");
                    dialogos.Enqueue("Marta: NÃO. DEIXE. ELES. SAÍREM.");
                    dialogos.Enqueue("Emily: Credo. Tá bom.");
                    dialogos.Enqueue("Marta: E mais uma coisa: nós frequentemente recebemos pedidos de delivery pelo telefone que tá ali na sala do chefe.");
                    dialogos.Enqueue("Marta: Veja bem, minhas pernas já não são mais as mesmas. Você, por acaso uma moça bonita, jovem, não se importaria em ir atender esse telefone sempre que ele tocar, não é? Hihihi.");
                    dialogos.Enqueue("Emily: Tá falando sério? Por que eu faria isso? Eu já tenho milhões de coisas pra fa-");
                    dialogos.Enqueue("Marta: Boa sorte, mocinha!");
                    dialogos.Enqueue("Emily: *Suspiro*");
                    dialogos.Enqueue("Emily: Por que eles fazem isso?");
                    proximaCena = "Fase 4";
                    break;
                case "Cena 12":
                    dialogos.Enqueue("Emily: Já deveria ter caído na conta há uma semana atrás, mas ele finalmente chegou. Meu suado dinheirinho.");
                    dialogos.Enqueue("Emily: O quê?! Isso é tudo? Foi para isso que eu me esforcei tanto?");
                    dialogos.Enqueue("Emily: E as horas extras? Eu não ganho nada por aquilo tudo?");
                    dialogos.Enqueue("Emily: David, o que você faria no meu lugar...?");
                    dialogos.Enqueue("Emily: Espera, David?!");
                    dialogos.Enqueue("Emily: Ele tinha falado alguma coisa sobre direitos. Será que eu realmente tenho como contestar isso?");
                    proximaCena = "Cena 13";
                    break;
                case "Cena 13":
                    dialogos.Enqueue("Emily: Eu sabia!");
                    dialogos.Enqueue("Emily: Nada daquilo era normal, não deveria ser normal.");
                    dialogos.Enqueue("Emily: Acúmulo de função, abuso moral... e porque não, hora extra não remunerada.");
                    dialogos.Enqueue("Emily: Tem tanta coisa errada que eu poderia escrever um livro... Espera, é isso! Eu deveria ter registrado tudo o que aconteceu. A empresa tem que pagar por isso.");
                    dialogos.Enqueue("Emily: Quem sabe se eu aguentar mais um mês. Coletar testemunhos de alguns colegas, registrar tudo...");
                    proximaCena = "Cena 14";
                    break;
                case "Cena 14":
                    dialogos.Enqueue("Chefe: Emily estou feliz em dizer que decidimos efetivar você aqui. Você realmente serve para alguma coisa, afinal. Hehehe.");
                    dialogos.Enqueue("Emily: Obrigada. Mas antes de tomar qualquer decisão, gostaria de discutir algumas questões.");
                    dialogos.Enqueue("Chefe: Do que você tá falando?");
                    dialogos.Enqueue("Emily: Eu andei lendo sobre meus direitos e descobri algo bem interessante...");
                    dialogos.Enqueue("Emily: O não pagamento de horas extras é ilegal. Ora ora.");
                    dialogos.Enqueue("Emily: Pois saiba que documentei todas as horas extras que trabalhei e exijo remuneração.");
                    dialogos.Enqueue("Chefe: Você não pode estar falando sério.");
                    dialogos.Enqueue("Emily: Seríssima.");
                    dialogos.Enqueue("Emily: Eu também registrei os abusos cometidos por você, não só comigo, mas com os demais funcionários.");
                    dialogos.Enqueue("Emily: Eu tô cansada de ser explorada. Estou disposta a brigar na justiça por isso.");
                    dialogos.Enqueue("Chefe: Ok, ok, tudo bem garota.");
                    dialogos.Enqueue("Chefe: Me deixe verificar tudo e tento resolver a sua situação... assim que você aceitar a minha proposta de efetivação...");
                    dialogos.Enqueue("Emily: Eu sabia! É por este motivo que não posso mais continuar aqui. Você não quer me ajudar.");
                    dialogos.Enqueue("Emily: Já tomei minha decisão.");
                    dialogos.Enqueue("Emily: Eu me demito.");
                    proximaCena = "Cena 15";
                    break;
                case "Cena 15":
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
        if (tipoCena == "Gameplay") //Verifica se uma cena de gameplay está ativa.
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!jogoPausado)
                {
                    GerenciadorInterface.instancia.pausa.SetActive(true);
                    GerenciadorInterface.instancia.pausa.GetComponent<Animator>().SetTrigger("On");
                    Cursor.visible = true;
                    jogoPausado = true;
                    Time.timeScale = 0;
                    Debug.Log("jogoPausado = " + jogoPausado);
                }
                else
                {
                    Time.timeScale = 1;
                    GerenciadorInterface.instancia.pausa.GetComponent<Animator>().SetTrigger("Off");
                    GerenciadorInterface.instancia.pausa.SetActive(false);
                    Cursor.visible = false;
                    jogoPausado = false;
                    Debug.Log("jogoPausado = " + jogoPausado);
                }
            }

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

            if (!jogoPausado)
            {
                if (dialogos.TryPeek(out string frase)) //Verificando se há uma string na fila antes de tentar dar Peek no texto.
                {
                    GerenciadorInterface.instancia.txtDialogos.text = frase; //Exibindo na tela o texto do topo da fila.
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

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.N))
        {
            cc.IniciarCena(proximaCena);
        }
    }
}
