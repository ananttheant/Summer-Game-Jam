using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene1_Script.GamePlayScripts.Debug_Scripts
{
    public class IngredientDebug : MonoBehaviour
    {

        private void OnCollisionEnter2D(Collision2D collision)
        {
            print(collision.transform.name);
        }


        private void OnTriggerEnter2D(Collider2D collider)
        {
            print(collider.transform.name);
        }

    }
}