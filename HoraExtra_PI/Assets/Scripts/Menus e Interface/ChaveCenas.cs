using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChaveCenas : MonoBehaviour
{
    public Animator transicaoAnim; //Recebe o animator dos canvas de transições.

    public void IniciarCena(string nomeCena) //Função que é chamada em outros scripts com o nome da cena desejada. 
    {
        StartCoroutine(CarregarCena(nomeCena)); //Inicia a Coroutine que carrega a cena desejada.
    }

    IEnumerator CarregarCena(string nomeCena) //Coroutine que toca a animação de transição e carrega a cena em seguida.
    {
        transicaoAnim.SetTrigger("Iniciar"); //Parâmetro do animator. Faz a transição para a segunda animação (Saída).

        yield return new WaitForSecondsRealtime(1f); //Segura a coroutine por 1 seg.
        SceneManager.LoadScene(nomeCena); //Carrega a cena.
    }
}
