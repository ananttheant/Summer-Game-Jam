using Hidayat_Script;
using UnityEngine;

public class Customer : MonoBehaviour
{
    IceCreamManager icecream_manager;
    IceCreamStructure icecream;

    void Start()
    {
        icecream_manager = new IceCreamManager();
        icecream = icecream_manager.CreateRandomIceCream();
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
}