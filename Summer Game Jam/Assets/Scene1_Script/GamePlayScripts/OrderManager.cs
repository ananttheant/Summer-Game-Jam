using System.Collections.Generic;
using UnityEngine;

namespace Scene1_Script.GamePlayScripts
{
    public class OrderManager : MonoBehaviour
    {
        private Queue<GameObject> _customers;

        // Use this for initialization
        private void Start()
        {
            _customers = new Queue<GameObject>();
        }

        public int NumberOfCustomers()
        {
            return _customers.Count;
        }

        /// <summary>
        /// Returns if the order created by player is the same as order from _customers
        /// </summary>
        /// <returns></returns>
        public bool CheckOrder(IceCreamStructure icecream)
        {
            foreach (GameObject customer in _customers)
            {
                if (customer.GetComponent<Customer>().GetIceCream().ConeType.Id == icecream.ConeType.Id)
                {
                    if (customer.GetComponent<Customer>().GetIceCream().IceCream_FlavType.Id ==
                        icecream.IceCream_FlavType.Id)
                    {
                        if (customer.GetComponent<Customer>().GetIceCream().SyrupType.Id == icecream.SyrupType.Id)
                        {
                            if (customer.GetComponent<Customer>().GetIceCream().SprinkleType.Id ==
                                icecream.SprinkleType.Id)
                            {
                                return true;
                            }
                            continue;
                        }
                        continue;
                    }
                    continue;
                }
            }
            return false;
        }

        /// <summary>
        /// When a new customer enters the line to order Ice Cream
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(GameObject customer)
        {
            _customers.Enqueue(customer);
        }

        /// <summary>
        /// Removing the first customer in the queue
        /// </summary>
        public GameObject RemoveCustomer()
        {
            return _customers.Dequeue();
        }

        public void DebugCustomers()
        {
            foreach (GameObject customer in _customers)
            {
                print(customer.name);
                print(customer.GetComponent<Customer>().GetIceCream().ConeType.Id);
                print(customer.GetComponent<Customer>().GetIceCream().IceCream_FlavType.Id);
                print(customer.GetComponent<Customer>().GetIceCream().SyrupType.Id);
                print(customer.GetComponent<Customer>().GetIceCream().SprinkleType.Id);
            }
        }
    }
}
