using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4Clientes : MonoBehaviour
{
    private Rigidbody2D npcRB;
    private float contagem, tempoLimite = 10f;
    private bool noCaixa = false;
    private string caixa;

    void Start()
    {
        npcRB = GetComponent<Rigidbody2D>();

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

                Debug.Log(gameObject.name + " saiu da fila");
                Debug.Log("falhas = " + F4Filas.falhas);
                Sair();
            }

            break;
        }

        while (noCaixa && Jogador.objetoProximo == caixa)
        {
            AtenderFila();
            break;
        }
    }

    void AtenderFila()
    {
        Debug.Log("F para interagir");

        if (Input.GetKeyDown(KeyCode.F))
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
            Pontuacao.pontos += 50;
            Debug.Log(gameObject.name + " atendido");
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
            caixa = col.gameObject.name;
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
            caixa = null;
        }

        if (col.gameObject.tag == "NPC")
        {
            Movimentacao(5f);
        }
    }
}
