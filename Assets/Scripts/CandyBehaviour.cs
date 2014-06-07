using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class CandyBehaviour : MonoBehaviour {

    private const int WIDTH = 8;
    private const int HEIGHT = 8;

    public GameObject prefab;

    private GameObject[,] map;

    private GameObject previousSelectedCandy;

    private MatchFinder matchFinder;

	// Use this for initialization
    void Start()
    {
        map = new GameObject[WIDTH, HEIGHT];
        matchFinder = new MatchFinder(map);
    }
	
	// Update is called once per frame
    void Update()
    {
        for (int i = 0; i < WIDTH; ++i)
        {
            if(map[i, HEIGHT - 1] == null)
            {
                map[i, HEIGHT - 1] = Instantiate(prefab, new Vector3(i, 0, 0), Quaternion.identity) as GameObject;
                Candy candy = map[i, HEIGHT - 1].GetComponent<Candy>();

                ECandyType type = GenerateCandyType();
                candy.SetType(type);
            }
        }

        for (int i = 0; i < HEIGHT; ++i)
        {
            for (int j = 0; j < WIDTH; ++j)
            {
                if (map[j, i] == null)
                {
                    map[j, i] = map[j, i + 1];
                    map[j, i + 1] = null;

                    if (map[j, i] != null)
                        map[j, i].transform.position = new Vector3(j, i, 0);
                }
            }
        }
    }

    ECandyType GenerateCandyType()
    {
        int randomInt = Random.Range(0, 4);

        switch(randomInt)
        {
            case 0:
                return ECandyType.GREEN;
            case 1:
                return ECandyType.WHITE;
            case 2:
                return ECandyType.BLACK;
            default:
                return ECandyType.MAGENTA;
        }
    }

    void CandySelected(GameObject candy)
    {
        if (previousSelectedCandy == null)
        {
            previousSelectedCandy = candy;
            //candy.
        }
        else
            TrySwitchCandies(previousSelectedCandy, candy);
    }

    void CandyDestroyed(GameObject candy)
    {
        map[(int)candy.transform.position.x, (int)candy.transform.position.y] = null;
        Destroy(candy);
    }

    private void TrySwitchCandies(GameObject candy1, GameObject candy2)
    {
        if(AreNeighbors(candy1, candy2))
        {
            SwitchCandies(candy1, candy2);
            
            IMatch match1 = matchFinder.FindMatch(candy1);
            IMatch match2 = matchFinder.FindMatch(candy2);

            //faz a troca
            if (match1 != null || match2 != null)
            {
                if (match1 != null)
                    match1.Execute();
                
                if(match2!=null)
                    match2.Execute();
            }
            else
                SwitchCandies(candy1, candy2);

            //chama o metodo global do match
            //MegaMatch(candy1, candy2);
        }
        else
        {
            //vorta
        }

        previousSelectedCandy = null;
    }

    /*void MegaMatch(GameObject candy1, GameObject candy2)
    {
        int matchType;
        
        //procura por match
        matchType = MatchFinder(candy1);
        MatchFinder(candy2);

       // se n achar vorta

        // se achar: executa match correspondente
        if( 3 )
            match3
        else if( 3 )
            match4
        else if( 5 )
            match5

        VerifyAllMap();
    }*/

    private bool AreNeighbors(GameObject candy1, GameObject candy2)
    {
        return Mathf.Abs(candy1.transform.position.x - candy2.transform.position.x) == 1 ^
            Mathf.Abs(candy1.transform.position.y - candy2.transform.position.y) == 1;
    }

    private void SwitchCandies(GameObject candy1, GameObject candy2)
    {
        // animação de troca

        Vector3 candy1Pos = candy1.transform.position;

        candy1.transform.position = candy2.transform.position;
        candy2.transform.position = candy1Pos;
    }
}
