using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filas : MonoBehaviour
{
    private Rigidbody2D npcRB;
    private float contagem, tempoLimite = 10f;
    private bool noCaixa = false;

    void Start()
    {
        npcRB = GetComponent<Rigidbody2D>();

        if (GeradorNPCs.numFila == 0)
        {
            GeradorNPCs.fila1.Enqueue(gameObject);
            Debug.Log(GeradorNPCs.fila1.Peek() + " é o primeiro da fila 1");
        }
        else if (GeradorNPCs.numFila == 1)
        {
            GeradorNPCs.fila2.Enqueue(gameObject);
            Debug.Log(GeradorNPCs.fila2.Peek() + " é o primeiro da fila 2");
        }

        Movimentacao(5f);
    }

    void Update()
    {
        while (noCaixa)
        {
            contagem += Time.deltaTime;

            if (contagem >= tempoLimite)
            {
                if (GeradorNPCs.fila1.Contains(gameObject))
                {
                    GeradorNPCs.fila1.Dequeue();
                    GeradorNPCs.falhas++;
                }
                else if (GeradorNPCs.fila2.Contains(gameObject))
                {
                    GeradorNPCs.fila2.Dequeue();
                    GeradorNPCs.falhas++;
                }

                Debug.Log(gameObject.name + " saiu da fila");
                Debug.Log("falhas = " + GeradorNPCs.falhas);
                Sair();
            }

            break;
        }

        while (noCaixa && Jogador.objetoProximo == "Caixa1")
        {
            InteragirFila1();
            break;
        }

        while (noCaixa && Jogador.objetoProximo == "Caixa2")
        {
            InteragirFila2();
            break;
        }
    }

    void InteragirFila1()
    {
        Debug.Log("F para interagir");

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (GeradorNPCs.fila1.Contains(gameObject))
            {
                GeradorNPCs.fila1.Dequeue();
                Pontuacao.pontos += 50;
                Debug.Log(gameObject.name + " atendido na fila 1");
                Sair();
            }
        }
    }

    void InteragirFila2()
    {
        Debug.Log("F para interagir");

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (GeradorNPCs.fila2.Contains(gameObject))
            {
                GeradorNPCs.fila2.Dequeue();
                Pontuacao.pontos += 50;
                Debug.Log(gameObject.name + " atendido na fila 2");
                Sair();
            }
        }
    }

    void Movimentacao(float npcVel)
    {
        npcRB.velocity = new Vector2(npcRB.velocity.x, -1 * npcVel);
    }

    void Sair()
    {
        Movimentacao(5f);
        Destroy(gameObject, 5);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "F4TA")
        {
            Movimentacao(0f);
            noCaixa = true;
        }

        if (col.gameObject.tag == "NPC")
        {
            Movimentacao(0f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "F4TA")
        {
            Movimentacao(5f);
            noCaixa = false;
        }

        if (col.gameObject.tag == "NPC")
        {
            Movimentacao(5f);
        }
    }
}
