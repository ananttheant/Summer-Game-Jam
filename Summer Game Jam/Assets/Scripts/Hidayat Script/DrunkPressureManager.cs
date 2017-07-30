using UnityEngine;

public class DrunkPressureManager : MonoBehaviour
{
    public float drunk_droprate;
    public float drinking_increaserate;
    public float pressure_increaserate;
    public float pressure_multiplier;

    public Player player;

    public GameObject pressure_meter;
    public GameObject drunk_meter;

    // Use this for initialization
    void Start()
    {
        if (player == null)
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
        

    /// <summary>
    /// Serves as an Update but for the GameManager to call
    /// </summary>
    /// <returns></returns>
    public string UpdateValues(int numberofcustomers)
    {
        CustomerInQueue(numberofcustomers);

        pressure_meter.transform.localScale = new Vector3(pressure_meter.transform.localScale.x, Mathf.Clamp01(player.PressureValue / player.maxPressureValue), pressure_meter.transform.localScale.z);

        drunk_meter.transform.localScale = new Vector3(drunk_meter.transform.localScale.x, Mathf.Clamp01(player.DrunkValue / player.maxDrunkValue), drunk_meter.transform.localScale.z);

        if (player.PressureValue == player.maxPressureValue)
        {
            return "Pressured";
        }

        if (player.DrunkValue == player.maxDrunkValue)
        {
            return "Drunk";
        }

        return "Normal";
    }

    public void CustomerAngry()
    {
        player.PressureValue += pressure_increaserate * 5;
    }

    public void CustomerHappy()
    {
        player.PressureValue -= pressure_increaserate * 2;
    }

    void PressureDrunkAffector()
    {
            
    }

    void CustomerInQueue(int numberofcustomers)
    {
        Mathf.Clamp(player.PressureValue += pressure_increaserate * numberofcustomers, 0, player.maxPressureValue);
        print(numberofcustomers);
    }
}