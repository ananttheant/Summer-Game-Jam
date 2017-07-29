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

            IceCreamStructure iceCreamMade = new IceCreamStructure();

            if (WaitingIceCream.GetComponent<Cone>() != null)
                iceCreamMade.ConeType.Id = currentTouchingGameObject.transform.GetComponent<Cone>().Id;
            else
                iceCreamMade.ConeType.Id = -1;

            if (WaitingIceCream.transform.FindChild("Ice Cream Flavour").GetComponent<IceCream_Flav>() != null)
                iceCreamMade.IceCream_FlavType.Id = currentTouchingGameObject.transform.FindChild("Ice Cream Flavour").GetComponent<IceCream_Flav>().Id;
            else
                iceCreamMade.ConeType.Id = -1;

            if (WaitingIceCream.transform.FindChild("Syrup").GetComponent<Syrup>() != null)
                iceCreamMade.SyrupType.Id = currentTouchingGameObject.transform.FindChild("Syrup").GetComponent<Syrup>().Id;
            else
                iceCreamMade.SyrupType.Id = -1;

            if (WaitingIceCream.transform.FindChild("Sprinkle").GetComponent<Sprinkle>() != null)
                iceCreamMade.SprinkleType.Id = currentTouchingGameObject.transform.FindChild("Sprinkle").GetComponent<Sprinkle>().Id;
            else
                iceCreamMade.SprinkleType.Id = -1;
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
