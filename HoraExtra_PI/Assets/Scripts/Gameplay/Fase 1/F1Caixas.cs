using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class F1Caixas : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "F1Ar")
        {
            if (col.gameObject.name.Contains("(T1)"))
            {
                if (gameObject.name.Contains("(T1)"))
                {
                    Destroy(gameObject, 2);
                }
            }
            else if (col.gameObject.name.Contains("(T2)"))
            {
                if (gameObject.name.Contains("(T2)"))
                {
                    Destroy(gameObject, 2);
                }
            }

            F1GeradorCaixas.limite--;
        }
    }
}
