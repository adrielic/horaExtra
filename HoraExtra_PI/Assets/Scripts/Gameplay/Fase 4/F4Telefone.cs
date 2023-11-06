using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4Telefone : MonoBehaviour
{
    [SerializeField] private float contagem, tempoLimite = 5f;
    private bool tocando = false;

    void Update()
    {
        if (Tarefas.iniciandoTelefone)
        {
            tocando = true;
            Tarefas.iniciandoTelefone = false;
            Debug.Log("Telefone tocando");
        }

        while (tocando)
        {
            contagem += Time.deltaTime;

            if (contagem >= tempoLimite)
            {
                tocando = false;
                contagem = 0f;
                Debug.Log("Ligação perdida");
            }

            break;
        }

        while (tocando && Jogador.objetoProximo == gameObject.name)
        {
            Debug.Log("C para interagir");
            AtenderTelefone();
            break;
        }
    }

    void AtenderTelefone()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.C))
        {
            tocando = false;
            contagem = 0f;
            Pontuacao.pontos += 150;
            Debug.Log("Ligação atendida");
        }
    }
}
