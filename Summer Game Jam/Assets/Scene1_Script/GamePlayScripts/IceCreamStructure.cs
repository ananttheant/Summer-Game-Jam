using System.Collections;
using System.Collections.Generic;
using Scene1_Script.GamePlayScripts.Classes;
using UnityEngine;

namespace Scene1_Script.GamePlayScripts
{
    public class IceCreamStructure
    {
        public GameObject Obj;
        private Cone _cone;
        private IceCreamFlav _iceCreamflav;
        private Sprinkle _sprinkle;
        private Syrup _syrup;

        public IceCreamStructure()
        {
            _cone = new Cone();
            _sprinkle = new Sprinkle();
            _iceCreamflav = new IceCreamFlav();
            _syrup = new Syrup();
        }

        public Cone ConeType
        {
            get { return _cone; }

            set { _cone = value; }
        }

        public IceCreamFlav IceCream_FlavType
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
}