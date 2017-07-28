using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour {

    Queue<GameObject> customers;

	// Use this for initialization
	void Start ()
    {
        customers = new Queue<GameObject>();
	}
	
    /// <summary>
    /// When a new customer enters the line to order Ice Cream
    /// </summary>
    /// <param name="customer"></param>
    public void AddCustomer(GameObject customer)
    {
        customers.Enqueue(customer);
    }

    public int NumberOfCustomers()
    {
        return customers.Count;
    }

    /// <summary>
    /// Removing the first customer in the queue
    /// </summary>
    public void RemoveCustomer()
    {
        customers.Dequeue();
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
}
