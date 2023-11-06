using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2Sujeira : MonoBehaviour
{
    public string tipoDeUtencilio;
    private IEnumerator perda;

    void Start()
    {
        perda = PerdaPontos(1f);
        StartCoroutine(perda);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Caso colida com o item que o player estiver segurando, ele verifica se o mesmo é compativel para limpar.
        if (collision.gameObject.tag.Equals("F2IL"))
        {
            if (collision.gameObject.name.Equals(tipoDeUtencilio))
            {
                StopCoroutine(perda);
                Pontuacao.pontos += 50;
                Destroy(this.gameObject);
            }
        }
    }

    private IEnumerator PerdaPontos(float espera)
    {
        while (true)
        {
            yield return new WaitForSeconds(espera);
            Pontuacao.pontos--;
        }
    }
}
