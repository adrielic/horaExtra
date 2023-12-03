using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class F1Caixas : MonoBehaviour
{
    private bool emContato = false;

    void Start()
    {
        if (gameObject.name.Contains("(T1)"))
        {
            F1GeradorCaixas.limiteT1++;
            Debug.Log("limiteT1 = " + F1GeradorCaixas.limiteT1);
        }
        else
        {
            F1GeradorCaixas.limiteT2++;
            Debug.Log("limiteT2 = " + F1GeradorCaixas.limiteT2);
        }
    }

    void Update()
    {
        if (emContato && GetComponent<Rigidbody2D>().velocity.magnitude > 0.1f)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("Arrastando"));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            emContato = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            emContato = false;
        }
    }
}
