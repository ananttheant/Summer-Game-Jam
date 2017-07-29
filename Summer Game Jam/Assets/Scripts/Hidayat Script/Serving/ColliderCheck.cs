using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public GameObject WaitingIceCream;

    private void OnCollisionEnter2D(Collision2D currentTouchingGameObject)
    {
        if (WaitingIceCream == null && currentTouchingGameObject.gameObject.CompareTag("Ingredients"))
        {
            WaitingIceCream = currentTouchingGameObject.gameObject;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(),
                WaitingIceCream.gameObject.GetComponent<Collider2D>(), true);

            var iceCreamMade = new IceCreamStructure();
            iceCreamMade.ConeType.Id = currentTouchingGameObject.transform.GetComponent<Cone>().Id;
            iceCreamMade.IceCream_FlavType.Id = currentTouchingGameObject.transform.FindChild("Ice Cream Flavour").GetComponent<IceCream_Flav>().Id;

            iceCreamMade.SprinkleType.Id = currentTouchingGameObject.transform.FindChild("Sprinkle").GetComponent<Sprinkle>().Id;
            iceCreamMade.SyrupType.Id = currentTouchingGameObject.transform.FindChild("Syrup").GetComponent<Syrup>().Id;
        }
    }

    void OnCollisionStay(Collision currentTouchingGameObjectStayCollision)
    {
        if (WaitingIceCream == null && currentTouchingGameObjectStayCollision.gameObject.CompareTag("Ingredients"))
        {
            WaitingIceCream = currentTouchingGameObjectStayCollision.gameObject;
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(),
                WaitingIceCream.gameObject.GetComponent<Collider2D>(), true);
        }
            
    }

    void SendOrderToCheck(IceCreamStructure iceCream)
    {
        GameObject.FindGameObjectWithTag("Game Logic").GetComponent<OrderManager>().CheckOrder(iceCream);
        WaitingIceCream = null;
    }

}
