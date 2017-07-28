using System.Collections;
using System.Collections.Generic;
using Hidayat_Script;
using Hidayat_Script.Classes;
using UnityEngine;

namespace Hidayat_Script
{

    public class IceCreamManager : MonoBehaviour
    {

        private const int MinRange = 0;
        private const int MaxRange = 4;

        public class IceCreamStructure
        {
            private Cone _cone;
            private IceCream_Flav _iceCreamflav;
            private Sprinkle _sprinkle;
            private Syrup _syrup;

            public IceCreamStructure()
            {
                _cone = new Cone();
                _sprinkle = new Sprinkle();
                _iceCreamflav = new IceCream_Flav();
                _syrup = new Syrup();
            }

            public Cone ConeType
            {
                get { return _cone; }

                set { _cone = value; }
            }

            public IceCream_Flav IceCream_FlavType
            {
                get { return _iceCreamflav; }

                set { _iceCreamflav = value; }
            }

            public Sprinkle SprinkleType
            {
                get { return _sprinkle; }
                set { _sprinkle = value; }
            }

            public Syrup SyrupType
            {
                get { return _syrup; }
                set { _syrup = value; }
            }

        }

        public IceCreamStructure CreateRandomIceCream()
        {
            var iceCream = new IceCreamStructure();
            iceCream.ConeType.Id = Random.Range(MinRange, MaxRange);
            iceCream.IceCream_FlavType.Id = Random.Range(MinRange, MaxRange);
            iceCream.SyrupType.Id = Random.Range(MinRange, MaxRange);
            iceCream.SprinkleType.Id = Random.Range(MinRange, MaxRange);
            return iceCream;
        }

    }
}
