using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GerenciadorInterface : MonoBehaviour
{
    public static GerenciadorInterface instancia;
    public GameObject energia, relogio, dinheiro, tutorial, interacao, pausa, produtos, tarefa, passarDialogo, clientesPerdidos;
    public Image imgRelogio, imgBarraEnergia, imgInteracao, imgClientes;
    public TMP_Text txtPontuacao, txtContador, txtNotificacao, txtEnergia, txtClientes, txtInteracao, txtDialogos,
    txtProduto1, txtProduto2, txtProduto3, txtProduto4, txtProduto5;

    void Awake()
    {
        instancia = this;
    }
}
