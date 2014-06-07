using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Match3 : IMatch
    {
        private List<GameObject> candies;

        public Match3(List<GameObject> candies)
        {
            this.candies = candies;
        }
        
        public void Execute()
        {
            foreach(GameObject candy in candies)
            {
                candy.SendMessage("OnMatch", null, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
