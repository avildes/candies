using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class MatchFinder
    {
        private GameObject[,] map;

        public MatchFinder(GameObject[,] map)
        {
            this.map = map;
        }

        public IMatch FindMatch(GameObject candy)
        {
            Candy candyScript = candy.GetComponent<Candy>();

            int candyX = (int)candy.transform.position.x;
            int candyY = (int)candy.transform.position.y;

            Candy candy1 = map[candyX - 2, candyY].GetComponent<Candy>();
            Candy candy2 = map[candyX - 1, candyY].GetComponent<Candy>();
            Candy candy4 = map[candyX + 1, candyY].GetComponent<Candy>();
            Candy candy5 = map[candyX + 2, candyY].GetComponent<Candy>();

            if (candy1.type == candyScript.type && candy2.type == candyScript.type)
                return new Match3(new List<GameObject>() { candy1.gameObject, candy2.gameObject, candy });
            else if (candy2.type == candyScript.type && candy4.type == candyScript.type)
                return new Match3(new List<GameObject>() { candy2.gameObject, candy4.gameObject, candy });
            else if (candy4.type == candyScript.type && candy5.type == candyScript.type)
                return new Match3(new List<GameObject>() { candy4.gameObject, candy5.gameObject, candy });

            return null;
        }
    }
}
