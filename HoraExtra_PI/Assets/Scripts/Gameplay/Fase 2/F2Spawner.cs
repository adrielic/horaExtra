using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2Spawner : MonoBehaviour
{
    public GameObject[] _prefabSujeira = new GameObject[3];
    public GameObject[] _prefAreas = new GameObject[3];
    public int NumSujeiras;
    public static int qntdSujeiras;

    private bool perdendoPontos = false;

    void Start()
    {
        qntdSujeiras = 0;

        if (GerenciadorCenas.cenaAtual.name == "Fase 2")
        {
            GerarSujeira();
            GerenciadorInterface.instancia.txtNotificacao.text = "Os corredores precisam de limpeza.";
        }
    }

    void Update()
    {
        if (Tarefas.iniciandoSujeira)
        {
            GerarSujeira();
            GerenciadorInterface.instancia.txtNotificacao.text = "Os corredores precisam de limpeza.";
            Tarefas.iniciandoSujeira = false;
        }

        if (qntdSujeiras >= 5 && !perdendoPontos)
        {
            StartCoroutine(PerdaPontos(1.0f));
        }
        else if (qntdSujeiras < 5 && perdendoPontos)
        {
            StopAllCoroutines();
            perdendoPontos = false;
            Debug.Log("parou de perder pontos");
        }
    }

    void GerarSujeira()
    {
        int area = 0, sujeira = 0;

        for (int i = 0; i < NumSujeiras; i++) //Fazendo aparecer um número x de sujeiras, definidos no inspetor da unity
        {
            if (qntdSujeiras < 10)
            {
                sujeira = Random.Range(0, 3); //Escolhendo uma sujeira aleatória do vetor
                area = Random.Range(0, 3); //Escolhendo uma área aleatória do vetor

                GameObject objArea = _prefAreas[area].gameObject; //Definindo a área escolhida

                float posMinX = objArea.transform.position.x - (objArea.transform.localScale.x / 2);
                float posMaxX = objArea.transform.position.x + (objArea.transform.localScale.x / 2);

                float posMinY = objArea.transform.position.y - (objArea.transform.localScale.y / 2);
                float posMaxY = objArea.transform.position.y + (objArea.transform.localScale.y / 2);
                //Limitando os limites de spawn de acordo com a área escolhida

                float posX = Random.Range(posMinX, posMaxX);
                float posY = Random.Range(posMinY, posMaxY);
                //Definindo a posição final da sujeira

                Instantiate(_prefabSujeira[sujeira], new Vector2(posX, posY), Quaternion.identity);
                //Instanciando a sujeira
            }
        }
    }

    IEnumerator PerdaPontos(float espera)
    {
        perdendoPontos = true;

        while (qntdSujeiras >= 5)
        {
            Pontuacao.pontos--;
            Pontuacao.pontos = Mathf.Clamp(Pontuacao.pontos, 0, 999999);
            GerenciadorInterface.instancia.tarefa.GetComponent<Animator>().SetTrigger("-Dinheiro");
            Debug.Log("perdendo pontos");
            yield return new WaitForSeconds(espera);
        }

        perdendoPontos = false;
        Debug.Log("parou de perder pontos");
    }
}
