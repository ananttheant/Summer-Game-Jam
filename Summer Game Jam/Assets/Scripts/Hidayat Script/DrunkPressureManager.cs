using UnityEngine;

namespace Hidayat_Script
{
    public class DrunkPressureManager : MonoBehaviour
    {
        public float drunk_droprate;
        public float pressure_increaserate;

        public float drinking_increaserate;

        // Use this for initialization
        void Start()
        {
        }
        

        /// <summary>
        /// Serves as an Update but for the GameManager to call
        /// </summary>
        /// <returns></returns>
        public string UpdateValues(int numberofcustomers)
        {
            return "";
        }
    }
}
