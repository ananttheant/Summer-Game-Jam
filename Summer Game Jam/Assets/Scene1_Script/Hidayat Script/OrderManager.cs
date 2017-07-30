using System.Collections.Generic;
using UnityEngine;

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
    public bool CheckOrder(IceCreamStructure icecream)
    {
        foreach (GameObject customer in customers)
        {
            if (customer.GetComponent<Customer>().GetIceCream().ConeType.Id == icecream.ConeType.Id)
            {
                if (customer.GetComponent<Customer>().GetIceCream().IceCream_FlavType.Id == icecream.IceCream_FlavType.Id)
                {
                    if (customer.GetComponent<Customer>().GetIceCream().SyrupType.Id == icecream.SyrupType.Id)
                    {
                        if (customer.GetComponent<Customer>().GetIceCream().SprinkleType.Id == icecream.SprinkleType.Id)
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
        customers.Enqueue(customer);
    }

    /// <summary>
    /// Removing the first customer in the queue
    /// </summary>
    public GameObject RemoveCustomer()
    {
        return customers.Dequeue();
    }

    public void DebugCustomers()
    {
        foreach (GameObject customer in customers)
        {
            print(customer.name);
            print(customer.GetComponent<Customer>().GetIceCream().ConeType.Id);
            print(customer.GetComponent<Customer>().GetIceCream().IceCream_FlavType.Id);
            print(customer.GetComponent<Customer>().GetIceCream().SyrupType.Id);
            print(customer.GetComponent<Customer>().GetIceCream().SprinkleType.Id);
        }
    }
}
