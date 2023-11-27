using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapaBuraco : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetTrigger("Saindo");
    }
}
