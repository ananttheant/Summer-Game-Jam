using UnityEngine;

namespace Hidayat_Script
{
    public class GameManager : MonoBehaviour
    {
        [Header("Time for gameplay")]
        public int minutes;
        public int seconds;
        [Header("Canvas & Customer Prefab")]
        public Transform canvas;
        public GameObject customer_prefab;

        float gameplay_time;
        float score;

        OrderManager order_manager;
        DrunkPressureManager dp_manager;


        // Use this for initialization
        void Start()
        {
            gameplay_time = (minutes * 60) + seconds;
            score = 0;
            order_manager = GetComponent<OrderManager>();
            dp_manager = GetComponent<DrunkPressureManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.timeSinceLevelLoad > gameplay_time)
            {
                if (order_manager.NumberOfCustomers() <= 0)
                {
                    // Scene Change
                    Debug.Log("Gameplay End");
                }
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                order_manager.DebugCustomers();
            }
        }

        /// <summary>
        /// Instantiates a customer to animate and create the order
        /// </summary>
        void Create_NewCustomer()
        {
            Vector3 position = new Vector3();
            GameObject customer = Instantiate(customer_prefab, position, Quaternion.identity, canvas); //Instantiate();
            order_manager.AddCustomer(customer);
        }

        void IceCreamChecking(IceCreamStructure icecream)
        {
            if (order_manager.CheckOrder(icecream))
            {
                CustomerHappy();
            }
            else
            {
                CustomerAngry();
            }
        }

        void CustomerHappy()
        {

        }

        void CustomerAngry()
        {

            order_manager.RemoveCustomer();
        }
    }
}
