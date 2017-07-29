using UnityEngine;

namespace Hidayat_Script
{
    public class DrunkPressureManager : MonoBehaviour
    {
        public float drunk_droprate;
        public float pressure_increaserate;
        public float drinking_increaserate;

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
        public string UpdateValues(int numberofcustomers)
        {
            return "";
        }
    }
}
