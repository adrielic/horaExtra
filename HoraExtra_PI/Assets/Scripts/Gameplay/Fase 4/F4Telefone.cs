using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F4Telefone : MonoBehaviour
{
    [SerializeField] private float contagem, tempoLimite = 18f;
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
            GerenciadorInterface.instancia.txtNotificacao.text = "O telefone está tocando.";
            contagem += Time.deltaTime;

            if (contagem >= tempoLimite)
            {
                tocando = false;
                contagem = 0f;
                Pontuacao.pontos -= 150;
                GerenciadorInterface.instancia.tarefa.GetComponent<Animator>().SetTrigger("-Dinheiro");
                GerenciadorInterface.instancia.txtNotificacao.text = "Você perdeu uma ligação.";
                Debug.Log("Ligação perdida");
            }

            break;
        }

        while (tocando && Jogador.objetoProximo == gameObject.name)
        {
            Debug.Log("C para interagir");
            GerenciadorInterface.instancia.interacao.GetComponent<Animator>().SetBool("Exibindo", true);
            GerenciadorInterface.instancia.txtInteracao.text = "Atender";
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
            GerenciadorInterface.instancia.tarefa.GetComponent<Animator>().SetTrigger("+Dinheiro");
            GerenciadorInterface.instancia.interacao.GetComponent<Animator>().SetBool("Exibindo", false);
            GerenciadorInterface.instancia.txtNotificacao.text = null;
            Debug.Log("Ligação atendida");
        }
    }
}
