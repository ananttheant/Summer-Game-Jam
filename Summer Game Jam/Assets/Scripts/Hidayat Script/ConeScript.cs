using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Ice Cream Flavour")
        {
            Destroy(collider.GetComponent<Rigidbody2D>());
            collider.transform.SetParent(transform);
            collider.transform.localPosition = new Vector3(23.7f, 13.8f, 0f);
        }
    }
}
