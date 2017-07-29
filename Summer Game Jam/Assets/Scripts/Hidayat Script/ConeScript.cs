using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        //collider.GetComponent<Rigidbody2D>().gravityScale = 0;
        collider.transform.parent = transform;
        collider.GetComponent<RectTransform>().localPosition = new Vector2();
    }
}
