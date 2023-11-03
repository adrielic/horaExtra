using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3Caixas : MonoBehaviour
{
    public GameObject prefProduto;

    public bool interagindoCPlayer = false;

    private void Update()
    {
        if (interagindoCPlayer)
        {
            Jogador.produto = Instantiate(prefProduto);
            interagindoCPlayer = false;
        }
    }
}
