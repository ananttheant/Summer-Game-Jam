using System.Collections;
using System.Collections.Generic;
using Hidayat_Script;
using UnityEngine;

namespace Hidayat_Script
{
    public class GameManager : MonoBehaviour
    {
        float score;

        OrderManager order_manager;
        DrunkPressureManager dp_manager;

        public Transform canvas;
        public GameObject customer_prefab;

        // Use this for initialization
        void Start()
        {
            score = 0;
            order_manager = GetComponent<OrderManager>();
            dp_manager = GetComponent<DrunkPressureManager>();
            Create_NewCustomer();
        }

        // Update is called once per frame
        void Update()
        {
            string status = dp_manager.UpdateValues(order_manager.NumberOfCustomers());

            if (Input.GetKeyDown(KeyCode.P))
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
            order_manager.RemoveCustomer();
        }

        void CustomerHappy()
        {

        }

        void CustomerAngry()
        { }
    }
}
