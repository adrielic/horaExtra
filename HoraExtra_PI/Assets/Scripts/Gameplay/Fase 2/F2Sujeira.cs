using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2Sujeira : MonoBehaviour
{
    public string tipoDeUtencilio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Caso colida com o item que o player estiver segurando, ele verifica se o mesmo é compativel para limpar.
        if (collision.gameObject.tag.Equals("F2IL"))
        {
            if (collision.gameObject.name.Equals(tipoDeUtencilio))
            {
                Destroy(this.gameObject);
                Pontuacao.pontos += 50;
            }
        }
    }
}
