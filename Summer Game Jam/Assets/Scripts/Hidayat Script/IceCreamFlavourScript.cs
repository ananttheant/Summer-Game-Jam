using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamFlavourScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Sprinkle")
        {
            Destroy(collider.GetComponent<Rigidbody2D>());
            collider.transform.SetParent(transform);
            collider.transform.localPosition = new Vector3(7.7f, 3.6f, 0);
        }
        else if (collider.name == "Syrup")
        {
            Destroy(collider.GetComponent<Rigidbody2D>());
            collider.transform.SetParent(transform);
            collider.transform.localPosition = new Vector3(4.4f, 0, 0);
        }
    }
}
