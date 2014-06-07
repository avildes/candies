using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Candy : MonoBehaviour
    {
        private GameObject manager;
        private SpriteRenderer sptRenderer;
        public ECandyType type
        { get; private set; }

        void Awake()
        {
            manager = GameObject.FindGameObjectWithTag("GameController");
            sptRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        void OnTouchDown()
        {
            manager.SendMessage("CandySelected", gameObject, SendMessageOptions.DontRequireReceiver);
        }

        void OnTouchStay()
        {


        }

        internal void SetType(ECandyType type)
        {
            this.type = type;
            switch (type)
            {
                case ECandyType.BLACK:
                    sptRenderer.color = Color.black;
                    break;
                case ECandyType.GREEN:
                    sptRenderer.color = Color.green;
                    break;
                case ECandyType.MAGENTA:
                    sptRenderer.color = Color.magenta;
                    break;
                case ECandyType.WHITE:
                    sptRenderer.color = Color.white;
                    break;
            }
        }

        void OnMatch()
        {
            manager.SendMessage("CandyDestroyed", gameObject, SendMessageOptions.DontRequireReceiver);
        }

    }
}
