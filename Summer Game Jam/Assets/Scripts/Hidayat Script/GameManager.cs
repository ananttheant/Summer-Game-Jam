using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public OrderManager order_manager;
    public DrunkPressureManager dp_manager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string status = dp_manager.UpdateValues();
    }

    /// <summary>
    /// Instantiates a customer to animate and create the order
    /// </summary>
    void Create_NewCustomer()
    {
        GameObject customer = null;//Instantiate();
        order_manager.AddCustomer(customer);
        Make_Order(customer);
    }

    void Make_Order(GameObject customer)
    {
        //customer.GetComponent<OrderManager>().Order();
    }
}
