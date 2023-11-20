using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorRelógio : MonoBehaviour
{
    [SerializeField]
    private float tempoTotal;

    [SerializeField]
    private bool contarHoras;

    private IEnumerator controleMinutos,
        controleHoras;

    private void Awake()
    {
        if (!contarHoras)
        {
            controleMinutos = ControleMinutos((tempoTotal / 8) / 60);
            StartCoroutine(controleMinutos);
        }
        else
        {
            controleHoras = ControleHoras((tempoTotal / 8) / 60);
            StartCoroutine(controleHoras);
        }
    }

    IEnumerator ControleMinutos(float minutosNoJogo)
    {
        while (true)
        {
            yield return new WaitForSeconds(minutosNoJogo);

            float anguloPorMinuto = (360f * ((tempoTotal / 8) / 60)) / (tempoTotal / 8);

            transform.Rotate(Vector3.back, (anguloPorMinuto * minutosNoJogo) * 2);
        }
    }

    IEnumerator ControleHoras(float minutosNoJogo)
    {
        while (true)
        {
            yield return new WaitForSeconds(minutosNoJogo);

            float anguloPorMinuto = (0.5f);

            transform.Rotate(Vector3.back, (anguloPorMinuto * minutosNoJogo) * 2);
        }
    }
}
