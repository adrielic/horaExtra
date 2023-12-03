using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4Clientes : MonoBehaviour
{
    private Rigidbody2D npcRB;
    private Animator npcAnim;
    private float contagem, tempoLimite = 20f;
    private bool noCaixa = false, atendido = false;
    private string caixa;

    void Start()
    {
        npcRB = GetComponent<Rigidbody2D>();
        npcAnim = GetComponent<Animator>();

        if (F4Filas.numFila == 0)
        {
            F4Filas.fila1.Enqueue(gameObject);
            Debug.Log(F4Filas.fila1.Peek() + " é o primeiro da fila 1");
        }
        else if (F4Filas.numFila == 1)
        {
            F4Filas.fila2.Enqueue(gameObject);
            Debug.Log(F4Filas.fila2.Peek() + " é o primeiro da fila 2");
        }

        Movimentacao(5f);
    }

    void Update()
    {
        while (noCaixa)
        {
            GerenciadorInterface.instancia.txtNotificacao.text = "Há um novo cliente na fila.";
            contagem += Time.deltaTime;

            if (contagem >= tempoLimite)
            {
                if (F4Filas.fila1.Contains(gameObject))
                {
                    F4Filas.fila1.Dequeue();
                    F4Filas.falhas++;
                }
                else if (F4Filas.fila2.Contains(gameObject))
                {
                    F4Filas.fila2.Dequeue();
                    F4Filas.falhas++;
                }

                GerenciadorInterface.instancia.txtNotificacao.text = "Um cliente foi embora furioso.";
                Debug.Log(gameObject.name + " saiu da fila");
                Debug.Log("falhas = " + F4Filas.falhas);
                Sair();
            }

            break;
        }

        while (noCaixa && Jogador.objetoProximo == caixa)
        {
            AtenderFila();
            GerenciadorInterface.instancia.interacao.GetComponent<Animator>().SetBool("Exibindo", true);
            GerenciadorInterface.instancia.txtInteracao.text = "Passar compra";
            break;
        }
    }

    void AtenderFila()
    {
        Debug.Log("C para interagir");

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.C))
        {
            if (F4Filas.fila1.Contains(gameObject))
            {
                F4Filas.fila1.Dequeue();
            }

            if (F4Filas.fila2.Contains(gameObject))
            {
                F4Filas.fila2.Dequeue();
            }

            Sair();
            Pontuacao.pontos += 150;
            GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Passando Compra"), 0.2f);
            GerenciadorInterface.instancia.tarefa.GetComponent<Animator>().SetTrigger("+Dinheiro");
            GerenciadorInterface.instancia.txtNotificacao.text = null;
            Debug.Log(gameObject.name + " atendido");
        }
    }

    void Movimentacao(float npcVel)
    {
        npcRB.velocity = new Vector2(npcRB.velocity.x, -1 * npcVel);

        if (npcRB.velocity.y != 0)
        {
            npcAnim.SetInteger("vMove", 1);
        }
        else
        {
            npcAnim.SetInteger("vMove", 0);
        }
    }

    void Sair()
    {
        noCaixa = false;
        caixa = null;
        Movimentacao(5f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "F4TA")
        {
            Movimentacao(0f);

            if (!atendido)
            {
                noCaixa = true;
                caixa = col.gameObject.name;
            }
        }

        if (col.gameObject.tag == "NPC")
        {
            Movimentacao(0f);
        }

        if (col.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "F4TA")
        {
            Movimentacao(5f);
        }

        if (col.gameObject.tag == "NPC")
        {
            Movimentacao(5f);
        }
    }
}
