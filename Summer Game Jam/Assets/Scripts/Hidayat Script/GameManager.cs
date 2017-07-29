using System.Collections;
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
        public GameObject[] customer_prefabs;

        float gameplay_time;
        float score;

        bool[] customer_positions;

        OrderManager order_manager;
        DrunkPressureManager dp_manager;


        // Use this for initialization
        void Start()
        {
            score = 0;
            gameplay_time = (minutes * 60) + seconds;
            customer_positions = new bool[3];

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

            if (Input.GetKeyDown(KeyCode.N))
            {
                int i = 0;
                for (int j = 0; j < customer_positions.Length; j++)
                {
                    if (!customer_positions[j])
                        break;
                    else
                        i++;
                }
                if (i == 3)
                    return;
                Create_NewCustomer();
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
            int rando_customer = Random.Range(0, 3);
            int rando_spot = Random.Range(0, 3);

            int loopbreaker = 0;

            if (!IsThereSpace())
                return;

            while (true)
            {
                if (customer_positions[rando_spot])
                    rando_spot = Random.Range(0, 3);
                else
                    break;
            }
            
            GameObject customer = Instantiate(customer_prefabs[rando_customer], canvas.GetChild(0), true); //Instantiate();
            customer.transform.localScale = new Vector3(1, 1, 1);
            customer_positions[rando_spot] = true;
            customer.GetComponent<Animator>().Play("WalkToPosition" + ++rando_spot);
        }

        bool IsThereSpace()
        {
            for (int i = 0; i < customer_positions.Length; i++)
            {
                if (!customer_positions[i])
                    return true;
            }
            return false;
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
