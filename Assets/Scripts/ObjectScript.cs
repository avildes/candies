using UnityEngine;
using System.Collections;

public class ObjectScript : MonoBehaviour {

    private SpriteRenderer sptRenderer;

    void Start()
    {
        sptRenderer = gameObject.GetComponent<SpriteRenderer>();

    }

	void OnTouchDown()
    {
        sptRenderer.color = Color.green;

    }

    void OnTouchUp()
    {
        sptRenderer.color = Color.white;

    }

    void OnTouchPhaseMoved()
    {


    }
}
