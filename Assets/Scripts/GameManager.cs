using UnityEngine;
using System.Collections;
using System.Threading;

public class GameManager : MonoBehaviour {

    public GameObject prefab;

    private int xInicial = -3;
    private int yInicial = 11;
    private int largura = 8;
    private int altura;

    private bool start = true;


	// Use this for initialization
	void Start ()
    {
        altura = largura * 2;

        

        


	}

    IEnumerator StartObjects()
    {
        for (int i = 0; i < altura; i++)
        {
            for (int j = 0; j < largura; j++)
            {
                Instantiate(prefab, new Vector3(xInicial + j, yInicial, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(1);
        }
     
    }


	// Update is called once per frame
	void Update () {
        if(start)
        {
            StartCoroutine(StartObjects());
            start = false;
        }


	}
}
