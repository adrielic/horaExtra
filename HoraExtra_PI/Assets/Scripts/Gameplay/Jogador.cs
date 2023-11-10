using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class Jogador : MonoBehaviour //Classe relacionada ao jogador e suas mecânicas, como movimentação, interação, etc.
{
    //Gerais.
    [SerializeField]
    private float vel = 5f, energia, taxaConsumo = 10f; //Variáveis de velocidade, total de energia (stamina) e consumo de energia ao correr. Serializadas para melhor checagem dos valores em tempo de execução.
    private bool movendo = false, descansando = false, correndo = false; //Variáveis utilizadas para verificar a movimentação do jogador.
    private Rigidbody2D jogRB; //Variável que recebe o componente Rigidbody2D, utilizado no sistema de movimentação de personagem.
    private Animator anim;
    private SpriteRenderer sprRend;

    private Vector2 dir; //Recebe os valores de direção para qual o jogador pode se mover.
    public static string objetoProximo; //Variável utilizada para verificação do objeto no qual o jogador está colidindo no momento, servindo de base para o sistema de interação. Precisa ser pública e estática, para que possa ser chamada nas classes onde a verificação acontece.
    public Image barraEnergia;
    public TMP_Text energiaUI;

    //Interação Fase2.
    public bool segurandoItemLimpeza = false;
    public GameObject ItemLimpeza; //Precisa ser isolado, pois é uma verificação mais específica

    //Interação Fase 3.
    private bool segurandoProd = false;
    private GameObject objInteragivel;
    public static GameObject produto;

    void Start()
    {
        jogRB = GetComponent<Rigidbody2D>(); //Adicionando o componente Rigidbody2D à variável.
        anim = GetComponent<Animator>();
        sprRend = GetComponent<SpriteRenderer>();

        energia = 100f; //Atribuindo o valor de energia máxima ao executar o jogo. É importante isso estar no Start. Do contrário, o jogador começa com 0 de energia e ela começa a ser regenerada aos poucos.
    }

    void Update()
    {
        Movimentacao(); //Executando o método de movimentação.

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.C))
        {
            Interacao();
        }

        energiaUI.text = Mathf.FloorToInt(energia) + "/100";
        barraEnergia.fillAmount = energia / 100;
    }

    void Movimentacao() //Método de movimentação de personagem, incluindo a lógica para corrida, consumo e regeneração de energia.
    {
        float dirX = Input.GetAxisRaw("Horizontal"); //Input de movimentação horizontal.
        float dirY = Input.GetAxisRaw("Vertical"); //Input de movimentação vertical.

        dir = new Vector2(dirX, dirY); //Vetor contendo as duas direções do qual o jogador pode se mover.
        jogRB.velocity = dir * vel; //Lógica de movimentação por velocity. O valor das variáveis de direção (0, 1 e -1) é multiplicado pela velocidade.

        if ((jogRB.velocity.x != 0) || (jogRB.velocity.y != 0)) //Verificando as direções em que o jogador está se movimentando e mudando o valor das variáveis que determinam se está parado ou se movimentando.
        {
            movendo = true;
            descansando = false;
            anim.SetBool("Correndo", true);
        }
        else
        {
            movendo = false;
            descansando = true;
            anim.SetBool("Correndo", false);
        }        

        if (dirX > 0)
            sprRend.flipX = false;
        else if (dirX < 0)
            sprRend.flipX = true;


        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.X)) && energia > 0) //Verifica se o jogador está pressionando a tecla 'Espaço' e se a energia está acima de 0, executando a lógica de corrida em seguida.
        {
            correndo = true; //Determina que o jogador está correndo.
            vel = 10f; //Recebe o dobro da velocidade de movimentação.
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.X) || energia <= 0) //Verifica se o jogador soltou a tecla 'Espaço' ou se a energia chegou à zero.
        {
            correndo = false; //Determina que o jogador parou de correr.
            vel = 5f; //A velocidade volta para seu valor padrão.
        }

        if (correndo && movendo) //Verifica se o jogador está no estado de corrida e se movendo, para que a energia não seja consumida sem que o jogador saia do lugar.
        {
            energia -= taxaConsumo * Time.deltaTime; //O valor da taxa de consumo (10) é subtraído da energia total por segundo enquanto o jogador estiver correndo.
        }
        else //Caso o contrário, executa a lógica de regeneração de energia.
        {
            if (energia < 100) //Verifica se a energia está abaixo de 100.
            {
                energia += taxaConsumo / 2 * Time.deltaTime; //Adiciona o valor da taxa de consumo (10) dividido por 2 ao total de energia, por segundo. (5/s).

                if (descansando) //Verifica se o jogador está parado.
                {
                    energia += taxaConsumo * Time.deltaTime; //Adiciona o valor total da taxa de consumo ao total de energia, por segundo. (10/s).
                }
            }
        }

        if (energia <= 0) //Verifica se a energia chegou à zero e então determina que o jogador parou de correr, em seguida exibindo um aviso.
        {
            energia = 0;
            correndo = false;
            Debug.Log("energia = " + energia);
        }
    }

    void Interacao()
    {
        switch (objetoProximo)
        {
            //Fase 2
            case "F2IL":
                //Se está colidindo com o item de limpeza, e não está segurando nada...
                if (!segurandoProd && !segurandoItemLimpeza)
                {
                    //Pegamos o item de limpeza
                    ItemLimpeza.GetComponent<F2ItemLimpeza>().sendoSegurado = true;
                    segurandoItemLimpeza = true;
                }
                break;
            case "F2Ar":
                //Se estamos colidindo com alguma Armário de limpeza, e estamos com um item de limpeza...
                if (segurandoItemLimpeza)
                {
                    //Verificamos se é o Armário certo do item, se sim, guardamos ele
                    if (ItemLimpeza.GetComponent<F2ItemLimpeza>().local == objInteragivel.name)
                    {
                        ItemLimpeza.GetComponent<F2ItemLimpeza>().sendoSegurado = false;
                        ItemLimpeza = null;
                        segurandoItemLimpeza = false;
                    }
                }
                break;

            //Fase 3
            case "Caixa":
                if (!segurandoProd && !segurandoItemLimpeza && objInteragivel.GetComponent<F3Caixas>().numTarefas > 0)
                {
                    objInteragivel.GetComponent<F3Caixas>().interagindoCPlayer = true;
                    segurandoProd = true;
                }
                break;
            case "Prateleiras":
                if (segurandoProd)
                {
                    if (produto.gameObject.GetComponent<F3Produtos>().tipo == objInteragivel.GetComponent<F3Prateleiras>().tipo
                    )
                    {
                        Pontuacao.pontos += 100;
                        objInteragivel.GetComponent<F3Prateleiras>().produto = produto;
                        segurandoProd = false;
                    }
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col) //Função de verificação de colisores em estado Trigger por frame atualizado.
    {
        switch (col.gameObject.tag) //Verifica a tag do objeto em que o jogador está colidindo, mudando os valores das variáveis relacionadas ao sistema de interação.
        {
            case "NPC": //Tag utilizada nos GameObjects de personagens não jogáveis.
                objetoProximo = col.gameObject.name; //Esta linha, assim como as demais iguais, atribui o valor da variável 'objetoProximo' como o nome do GameObject em que o jogador está interagindo no momento.
                Debug.Log("objetoProximo = " + objetoProximo);
                break;
            case "F4TA": //Tag utilizada nos GameObjects relacionados à tarefa principal da fase 4 (Caixas).
                if (!segurandoProd && !segurandoItemLimpeza)
                {
                    objetoProximo = col.gameObject.name;
                    Debug.Log("objetoProximo = " + objetoProximo);
                }
                break;
            case "F4TB": //Tag utilizada no GameObject relacionado à tarefa secundária da fase 4 (Telefone).
                if (!segurandoProd && !segurandoItemLimpeza)
                {
                    objetoProximo = col.gameObject.name;
                    Debug.Log("objetoProximo = " + objetoProximo);
                }
                break;            
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        switch (col.gameObject.tag) //Verifica a tag do objeto em que o jogador está colidindo, mudando os valores das variáveis relacionadas ao sistema de interação.
        {
            case "F2IL":
                if (!segurandoItemLimpeza && !segurandoProd)
                {
                    objetoProximo = col.gameObject.tag;
                    ItemLimpeza = col.gameObject;
                }
                break;
            case "F2Ar":
                objetoProximo = col.gameObject.tag;
                objInteragivel = col.gameObject;
                break;
            case "F3Ca":
                objetoProximo = "Caixa";
                objInteragivel = col.gameObject;
                break;
            case "F3Pa":
                objetoProximo = "Prateleiras";
                objInteragivel = col.gameObject;
                break;
        }
    }

    void OnTriggerExit2D(Collider2D col) //Função de verificação se o jogador deixou a area do colisor em estado de Trigger.
    {
        switch (col.gameObject.tag) //Verifica se o jogador saiu da área de colisão do objeto de tag especificada.
        {
            case "NPC":
                objetoProximo = null;
                break;
            case "F4TA":
                objetoProximo = null;
                break;
            case "F4TB":
                objetoProximo = null;
                break;
            case "F3Ca":
                objetoProximo = null;
                break;
            case "F3Pa":
                objetoProximo = null;
                break;
            case "F2IL":
                objetoProximo = null;
                break;
            case "F2Ar":
                objetoProximo = null;
                break;
        }
    }
}
