using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace Scene1_Script.GamePlayScripts
{
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

            if (player.DrunkValue > player.MaxDrunkValue / 2)
            {
                float blur = (player.DrunkValue - 50) / (player.MaxDrunkValue - 50);
                camera.GetComponent<BlurOptimized>().blurSize = blur * 3;
            }

            if (player.PressureValue >= player.MaxPressureValue)
            {
                return "Pressured";
            }

            if (player.DrunkValue >= player.MaxDrunkValue)
            {
                return "Drunk";
            }

            player.PressureValue = player.PressureValue - pressure_droprate;
            player.DrunkValue = player.DrunkValue - drunk_droprate;

            pressure_meter.transform.localScale = new Vector3(pressure_meter.transform.localScale.x,
                Mathf.Clamp01(player.PressureValue / player.MaxPressureValue), pressure_meter.transform.localScale.z);
            drunk_meter.transform.localScale = new Vector3(drunk_meter.transform.localScale.x,
                Mathf.Clamp01(player.DrunkValue / player.MaxDrunkValue), drunk_meter.transform.localScale.z);
            return "Normal";
        }

        public void Drinking()
        {
            player.PressureValue = Mathf.Clamp(player.PressureValue - (drinking_increaserate / 2), 0, 110);
            player.DrunkValue = player.DrunkValue + drinking_increaserate;
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
}