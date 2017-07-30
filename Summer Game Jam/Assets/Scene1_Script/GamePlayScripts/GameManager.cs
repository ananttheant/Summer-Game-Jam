using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Scene1_Script.GamePlayScripts
{
    public class GameManager : MonoBehaviour
    {
        [Header("Time for gameplay")] public int minutes;
        public int seconds;
        [Header("Canvas & Customer Prefab")] public Transform canvas;
        public GameObject[] customer_prefabs;
        public GameObject colliderObj;

        float gameplay_time;
        float score;
        float timefromspawn;
        float spawntime = 1.5f;
        bool[] customer_positions;

        string status;
        int lastserved;

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
            if (Input.GetKeyDown(KeyCode.L))
            {
                print("Press");
            }
            status = dp_manager.UpdateValues(order_manager.NumberOfCustomers());

            if (status == "Normal")
            {
                if (Time.time > gameplay_time)
                {
                    // Scene Change
                    Debug.Log("Gameplay End");
                    SceneManager.LoadScene(1);
                }
                if (IceCream != null)
                {
                    print(icecream);
                    if (Input.GetKeyDown(KeyCode.L))
                    {
                        IceCreamChecking(icecream);
                        Destroy(icecream.Obj);
                    }

                    if (Input.GetKeyDown(KeyCode.Backspace))
                    {
                        // increase pressure
                        Destroy(icecream.Obj);

                    }
                    //colliderObj.GetComponent<ColliderCheck>().OrderUp();
                }
            }
            else if (status == "Drunk" || status == "Pressured")
            {
                SceneManager.LoadScene(1);
            }

            if (timefromspawn < Time.time)
            {
                if (IsThereSpace())
                    Create_NewCustomer();
            }
            print("dasugfdua");

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


            while (true)
            {
                if (customer_positions[rando_spot])
                    rando_spot = Random.Range(0, 3);
                else
                    break;
            }

            spawntime = Time.time + timefromspawn;

            GameObject customer =
                Instantiate(customer_prefabs[rando_customer], canvas.GetChild(1), true); //Instantiate();
            customer.name = "customer " + rando_customer;
            customer.GetComponent<Customer>().ID = rando_spot;
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
            lastserved = customer.GetComponent<Customer>().ID;
        }

        void CustomerAngry()
        {
            audioplayer.PlayWrong();
            GameObject customer = order_manager.RemoveCustomer();
            dp_manager.CustomerAngry();
            customer.GetComponent<Image>().sprite = customer.GetComponent<Customer>().angry_Images;
            customer.GetComponent<Animator>().SetInteger("CorrectOrder", 0);
            customer_positions[customer.GetComponent<Customer>().ID] = false;
            lastserved = customer.GetComponent<Customer>().ID;
        }

        public IceCreamStructure IceCream
        {
            get { return icecream; }
            set
            {
                icecream = value;
                print(icecream);
            }
        }
    }
}