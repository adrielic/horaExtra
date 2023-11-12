using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificacoes : MonoBehaviour
{
    private string textoAnterior;

    void Start()
    {
        textoAnterior = GerenciadorInterface.instancia.txtNotificacao.text;
        StartCoroutine(LimparNotificacao(0f));
    }

    void Update()
    {
        if (GerenciadorInterface.instancia.txtNotificacao.text != textoAnterior)
        {
            textoAnterior = GerenciadorInterface.instancia.txtNotificacao.text;
            StopAllCoroutines();
            StartCoroutine(LimparNotificacao(5f));
        }
    }

    IEnumerator LimparNotificacao(float espera)
    {
        yield return new WaitForSeconds(espera);
        GerenciadorInterface.instancia.txtNotificacao.text = null;
    }
}
