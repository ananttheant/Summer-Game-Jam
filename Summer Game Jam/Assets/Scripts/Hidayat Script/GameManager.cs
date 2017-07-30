using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Time for gameplay")]
    public int minutes;
    public int seconds;
    [Header("Canvas & Customer Prefab")]
    public Transform canvas;
    public GameObject[] customer_prefabs;
    public GameObject colliderObj;

    float gameplay_time;
    float score;
    float timefromspawn;
    float spawntime = 1.5f;

    bool drinking = false;
    bool[] customer_positions;

    public AudioPlayer audioplayer;
    OrderManager order_manager;
    DrunkPressureManager dp_manager;
    IceCreamStructure icecream;

    // Use this for initialization
    void Start()
    {
        score = 0;
        gameplay_time = (minutes * 60) + seconds;
        customer_positions = new bool[3];

        order_manager = GetComponent<OrderManager>();
        dp_manager = GetComponent<DrunkPressureManager>();

        timefromspawn = Time.time + spawntime;
    }

    // Update is called once per frame
    void Update()
    {
        string status = dp_manager.UpdateValues(order_manager.NumberOfCustomers());

        if (timefromspawn < Time.time)
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

        if (!drinking)
        {
            if (status == "Normal")
            {
                if (Time.timeSinceLevelLoad > gameplay_time)
                {
                    if (order_manager.NumberOfCustomers() <= 0)
                    {
                        // Scene Change
                        Debug.Log("Gameplay End");
                    }
                }

                if (icecream != null)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        IceCreamChecking(icecream);
                        Destroy(icecream.obj);
                    }

                    if (Input.GetKeyDown(KeyCode.Backspace))
                    {
                        // increase pressure
                        Destroy(icecream.obj);

                    }
                    //colliderObj.GetComponent<ColliderCheck>().OrderUp();
                }
            }
            else if (status == "Drunk")
            {
                // Change Scene
            }
            else if (status == "Pressured")
            {
                // Change SCene
            }
        }
    }

    public void Drink()
    {
        audioplayer.PlayDrink();
        dp_manager.Drinking();
    }

    /// <summary>
    /// Instantiates a customer to animate and create the order
    /// </summary>
    void Create_NewCustomer()
    {
        int rando_customer = Random.Range(0, 3);
        int rando_spot = Random.Range(0, 3);

        if (!IsThereSpace())
            return;

        while (true)
        {
            if (customer_positions[rando_spot])
                rando_spot = Random.Range(0, 3);
            else
                break;
        }

        spawntime = Time.time + timefromspawn;

        GameObject customer = Instantiate(customer_prefabs[rando_customer], canvas.GetChild(1), true); //Instantiate();
        customer.name = "customer " + rando_customer;
        customer.GetComponent<Customer>().ID = rando_customer;
        customer.transform.localPosition = new Vector3(-300, 100);
        customer.transform.localScale = new Vector3(1, 1, 1);
        customer_positions[rando_spot] = true;
        customer.GetComponent<Animator>().Play("WalkToPosition" + ++rando_spot);
        order_manager.AddCustomer(customer);
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
        audioplayer.PlayCorrect();
        GameObject customer = order_manager.RemoveCustomer();
        dp_manager.CustomerHappy();
        customer.GetComponent<Image>().sprite = customer.GetComponent<Customer>().happy_Images;
        customer.GetComponent<Animator>().SetInteger("CorrectOrder", 1);
        customer_positions[customer.GetComponent<Customer>().ID] = false;
    }

    void CustomerAngry()
    {
        audioplayer.PlayWrong();
        GameObject customer = order_manager.RemoveCustomer();
        dp_manager.CustomerAngry();
        customer.GetComponent<Image>().sprite = customer.GetComponent<Customer>().angry_Images;
        customer.GetComponent<Animator>().SetInteger("CorrectOrder", 0);
        customer_positions[customer.GetComponent<Customer>().ID] = false;
    }

    public IceCreamStructure IceCream
    {
        get { return icecream; }
        set { icecream = value; }
    }
}
