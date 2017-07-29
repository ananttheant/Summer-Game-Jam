using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDebug : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.transform.name);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        print(collider.transform.name);
    }

    void Update()
    { transform.position += new Vector3(0, -1); }
}
