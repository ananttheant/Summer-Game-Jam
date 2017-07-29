using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ingredients")
        {
            Destroy(collider.GetComponent<Rigidbody2D>());
            collider.transform.SetParent(transform);
            collider.transform.localPosition = new Vector3();
        }
    }
}
