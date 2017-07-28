using System.Collections.Generic;
using UnityEngine;

namespace Hidayat_Script
{
    public class OrderManager : MonoBehaviour
    {
        Queue<GameObject> customers;

        // Use this for initialization
        void Start()
        {
            customers = new Queue<GameObject>();
        }
        
        public int NumberOfCustomers()
        {
            return customers.Count;
        }

        /// <summary>
        /// Returns if the order created by player is the same as order from customers
        /// </summary>
        /// <returns></returns>
        public bool CheckOrder()
        {
            //foreach (GameObject customer in customers)
            //{
            //    //  if (customer.order == order)
            //    //      customer.GetComponent<Order>();
            //}
            return false;
        }

        /// <summary>
        /// When a new customer enters the line to order Ice Cream
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(GameObject customer)
        {
            customers.Enqueue(customer);
        }

        /// <summary>
        /// Removing the first customer in the queue
        /// </summary>
        public void RemoveCustomer()
        {
            customers.Dequeue();
        }
    }
}
