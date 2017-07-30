using Hidayat_Script;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    IceCreamManager icecream_manager;
    IceCreamStructure icecream;

    public Sprite happy_Images;
    public Sprite angry_Images;

    public Sprite[] cone_Images;
    public Sprite[] iceCream_Images;
    public Sprite[] syrup_Images;
    public Sprite[] sprinke_Images;

    public int ID;
    public float timeToWait;

    private void Start()
    {
        icecream_manager = new IceCreamManager();
        icecream = icecream_manager.CreateRandomIceCream();
    }

    public void DisplayIceCream()
    {
        var cone = transform.GetChild(0).GetChild(0);
        cone.GetComponent<Image>().sprite = cone_Images[icecream.ConeType.Id];
        cone.GetChild(0).GetComponent<Image>().sprite = iceCream_Images[icecream.IceCream_FlavType.Id];

        if (icecream.SyrupType.Id > -1)
            cone.GetChild(0).GetChild(0).GetComponent<Image>().sprite = syrup_Images[icecream.SyrupType.Id];
        else
            cone.GetChild(0).GetChild(0).gameObject.SetActive(false);

        if (icecream.SprinkleType.Id > -1)
            cone.GetChild(0).GetChild(1).GetComponent<Image>().sprite = sprinke_Images[icecream.SprinkleType.Id];
        else
            cone.GetChild(0).GetChild(1).gameObject.SetActive(false);
    }

    public IceCreamStructure GetIceCream()
    {
        return icecream;
    }

    public void DebugIceCream()
    {
        print("Cone : " + icecream.ConeType.Id);
        print("Flavour : " + icecream.IceCream_FlavType.Id);
        print("Syrup : " + icecream.SyrupType.Id);
        print("Sprinkle : " + icecream.SprinkleType.Id);
    }

    public void Bye()
    {
        Destroy(gameObject);
    }
}