using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iluminacao : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            anim.SetTrigger("On");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            anim.SetTrigger("Off");
    }
}
