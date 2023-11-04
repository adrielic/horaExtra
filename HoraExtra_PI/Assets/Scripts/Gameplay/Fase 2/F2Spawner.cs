using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F2Spawner : MonoBehaviour
{
    public GameObject[] _prefabSujeira = new GameObject[3];
    public GameObject[] _prefAreas = new GameObject[3];

    public int numMaxSujeiras;

    void Update()
    {
        if (Tarefas.sujandoF2)
            Spawn();
    }

    public void Spawn()
    {
        int area = 0,
            sujeira = 0;

        for (int i = 0; i < numMaxSujeiras; i++) //Fazendo aparecer um número x de sujeiras, definidos no inspetor da unity
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
            Tarefas.sujandoF2 = false;
            //Instanciando a sujeira
        }
    }
}
