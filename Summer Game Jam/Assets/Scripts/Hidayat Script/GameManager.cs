using System.Collections;
using System.Collections.Generic;
using Hidayat_Script;
using UnityEngine;

namespace Hidayat_Script
{
    public class GameManager : MonoBehaviour
    {
        public OrderManager order_manager;
        public DrunkPressureManager dp_manager;

        // Use this for initialization
        void Start()
        {
            if (order_manager == null)
            {
                // Find GameObject with the script
            }
        }

        // Update is called once per frame
        void Update()
        {
            string status = dp_manager.UpdateValues(order_manager.NumberOfCustomers());

        }

        /// <summary>
        /// Instantiates a customer to animate and create the order
        /// </summary>
        void Create_NewCustomer()
        {
            GameObject customer = null; //Instantiate();
            order_manager.AddCustomer(customer);
        }
    }
}
