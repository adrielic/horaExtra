using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telefone : MonoBehaviour
{
    [SerializeField] private float contagem, tempoLimite = 5f;
    private bool tocando = false;

    void Update()
    {
        if (Tarefas.iniciandoTel)
        {
            tocando = true;
            Tarefas.iniciandoTel = false;
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
            Debug.Log("F para interagir");
            AtenderTelefone();
            break;
        }
    }

    void AtenderTelefone()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            tocando = false;
            contagem = 0f;
            Pontuacao.pontos += 20;
            Debug.Log("Ligação atendida");
        }
    }
}
