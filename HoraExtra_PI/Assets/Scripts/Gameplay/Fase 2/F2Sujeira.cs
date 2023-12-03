using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2Sujeira : MonoBehaviour
{
    public string tipoDeUtencilio;

    void Start()
    {
        F2Spawner.qntdSujeiras++;
        Debug.Log("qntdSujeiras = " + F2Spawner.qntdSujeiras);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Caso colida com o item que o player estiver segurando, ele verifica se o mesmo é compativel para limpar.
        if (collision.gameObject.tag.Equals("F2IL"))
        {
            if (collision.gameObject.name.Equals(tipoDeUtencilio))
            {
                Pontuacao.pontos += 50;
                GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Varrendo"));
                GerenciadorInterface.instancia.tarefa.GetComponent<Animator>().SetTrigger("+Dinheiro");
                F2Spawner.qntdSujeiras--;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                Destroy(this.gameObject, 0.8f);
            }
        }
    }
}
