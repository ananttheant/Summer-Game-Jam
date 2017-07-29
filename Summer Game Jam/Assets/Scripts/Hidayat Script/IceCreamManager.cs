using System.Collections;
using System.Collections.Generic;
using Hidayat_Script;
using Hidayat_Script.Classes;
using UnityEngine;

namespace Hidayat_Script
{
    public class IceCreamManager
    {
        private const int MinRange = 0;
        private const int MaxRange = 4;
        private readonly bool  _randomBool = (Random.value > 0.5f);

        public  IceCreamStructure CreateRandomIceCream()
        {
            var iceCream = new IceCreamStructure();
            iceCream.ConeType.Id = Random.Range(MinRange, MaxRange);
            iceCream.IceCream_FlavType.Id = Random.Range(MinRange, MaxRange);

            if (_randomBool)
            {
                iceCream.SyrupType.Id = Random.Range(MinRange, MaxRange);
            }
            else
            {
                iceCream.SyrupType.Id = -1;
            }
            if (_randomBool)
            {
                iceCream.SprinkleType.Id = Random.Range(MinRange, MaxRange);
            }
            else
            {
                iceCream.SprinkleType.Id = -1;
            }
            return iceCream;

        }
    }
}
