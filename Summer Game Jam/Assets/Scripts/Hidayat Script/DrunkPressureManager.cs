using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class DrunkPressureManager : MonoBehaviour
{
    public float drunk_droprate;
    public float drinking_increaserate;
    public float pressure_increaserate;
    public float pressure_multiplier;
    public float pressure_droprate;

    public Player player;

    public GameObject pressure_meter;
    public GameObject drunk_meter;

    public BlurOptimized camera;

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

        if (player.DrunkValue > player.maxDrunkValue / 2)
        {
            float blur = (player.DrunkValue - 50) / (player.maxDrunkValue - 50);
            camera.GetComponent<BlurOptimized>().blurSize = blur * 3;
        }

        if (player.PressureValue == player.maxPressureValue)
        {
            return "Pressured";
        }

        if (player.DrunkValue == player.maxDrunkValue)
        {
            return "Drunk";
        }

        player.PressureValue = Mathf.Clamp(player.PressureValue - pressure_droprate, 0, 100);
        player.DrunkValue = Mathf.Clamp(player.DrunkValue - drunk_droprate, 0, 100);

        pressure_meter.transform.localScale = new Vector3(pressure_meter.transform.localScale.x, Mathf.Clamp01(player.PressureValue / player.maxPressureValue), pressure_meter.transform.localScale.z);
        drunk_meter.transform.localScale = new Vector3(drunk_meter.transform.localScale.x, Mathf.Clamp01(player.DrunkValue / player.maxDrunkValue), drunk_meter.transform.localScale.z);


        return "Normal";
    }

    public void Drinking()
    {
        player.PressureValue = Mathf.Clamp(player.PressureValue - (drinking_increaserate / 2), 0, 100);
        player.DrunkValue = Mathf.Clamp(player.DrunkValue + drinking_increaserate, 0, 100);
    }

    public void ThrowAway()
    {
        player.PressureValue += 0.02f;
    }

    public void CustomerAngry()
    {
        player.PressureValue += pressure_increaserate * 5;
    }

    public void CustomerHappy()
    {
        player.PressureValue -= pressure_increaserate * 2;
    }

    void CustomerInQueue(int numberofcustomers)
    {
        player.PressureValue = player.PressureValue + pressure_increaserate * numberofcustomers;
    }
}