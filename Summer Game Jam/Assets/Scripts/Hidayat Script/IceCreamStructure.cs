using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamStructure : MonoBehaviour
{
    private Cone _cone;
    private IceCream_Flav _iceCreamflav;
    private Sprinkle _sprinkle;
    private Syrup _syrup;

    public IceCreamStructure()
    {
        _cone = new Cone();
        _sprinkle = new Sprinkle();
        _iceCreamflav = new IceCream_Flav();
        _syrup = new Syrup();
    }

    public Cone ConeType
    {
        get { return _cone; }

        set { _cone = value; }
    }

    public IceCream_Flav IceCream_FlavType
    {
        get { return _iceCreamflav; }

        set { _iceCreamflav = value; }
    }

    public Sprinkle SprinkleType
    {
        get { return _sprinkle; }
        set { _sprinkle = value; }
    }

    public Syrup SyrupType
    {
        get { return _syrup; }
        set { _syrup = value; }
    }

    public void ConeImage(int id)
    {
    }

    public void IceCreamFlavourImage()
    {

    }

    public void SprinkleImage()
    {

    }

    public void SyrupImage()
    {

    }
}