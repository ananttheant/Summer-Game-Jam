using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hidayat_Script
{
    public class Customer : MonoBehaviour
    {
       public IceCreamManager IceCreamManager;

        void Start()
        {
            IceCreamManager.CreateRandomIceCream();
        }


    }
}
