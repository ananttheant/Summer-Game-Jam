using UnityEngine;


namespace Hidayat_Script
{
    public class DrunkPressureManager : MonoBehaviour
    {

        public float drunk_droprate;
        public float pressure_increaserate;

        public float drinking_increaserate;

        float drunk_value;
        float pressure_value;

        // Use this for initialization
        void Start()
        {
            drunk_value = pressure_value = 0;
        }

        public float DrunkValue
        {
            get { return drunk_value; }
            set { drunk_value = value; }
        }

        public float PressureValue
        {
            get { return pressure_value; }
            set { pressure_value = value; }
        }

        /// <summary>
        /// Serves as an Update but for the GameManager to call
        /// </summary>
        /// <returns></returns>
        public string UpdateValues()
        {
            return "";
        }

        public void Drink()
        {
            drunk_value += drinking_increaserate;
        }
    }
}
