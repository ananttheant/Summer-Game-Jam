using UnityEngine;

namespace Hidayat_Script
{
    public class DrunkPressureManager : MonoBehaviour
    {
        public float drunk_droprate;
        public float drinking_increaserate;
        public float pressure_increaserate;
        public float pressure_multiplier;

        public Player player;

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
        public void UpdateValues(int numberofcustomers)
        {
            CustomerInQueue(numberofcustomers);
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
            player.PressureValue += pressure_increaserate * numberofcustomers;
        }
    }
}
