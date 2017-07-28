using UnityEngine;

public class DrunkPressureManager : MonoBehaviour {

    public float drunk_droprate;
    public float pressure_increaserate;

    public float drinking_increaserate;
    
    // Player class

    /// <summary>
    /// Serves as an Update but for the GameManager to call
    /// </summary>
    /// <returns></returns>
    public string UpdateValues(int numberofcustomers)
    {
        // Player.PressureValue += pressure_increaserate * numberofcustomers;
        return "";
    }

    public void Drink()
    {
        // Player.DrunkValue += drinking_increaserate;
    }

    

}
