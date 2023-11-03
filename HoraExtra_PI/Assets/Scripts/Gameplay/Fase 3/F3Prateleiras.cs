using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F3Prateleiras : MonoBehaviour
{
    public int tipo;

    public GameObject produto;

    private void Update()
    {
        if (produto != null)
        {
            Destroy(produto.gameObject);
        }
    }
}
