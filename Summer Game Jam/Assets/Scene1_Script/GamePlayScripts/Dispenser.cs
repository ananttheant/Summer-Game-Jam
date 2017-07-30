
using UnityEngine;

namespace Scene1_Script.GamePlayScripts
{
    public class Dispenser : MonoBehaviour
    {
        public GameObject[] output
            ; // this is the game object that should be present in the scene , cuz it will get duplicated.


        private const float TimeToPress = 1;
        private float _startTime = 0;

        public void SpawnFirst()
        {
            var positionToSpawn = transform.GetChild(0).position;
            var ingredients = Instantiate(output[0], positionToSpawn, Quaternion.identity,
                transform.root.GetChild(3));
            var substringName = ingredients.name.Substring(0, ingredients.name.Length - 9);
            ingredients.name = substringName;
        }

        public void SpawnSecond()
        {
            var positionToSpawn = transform.GetChild(0).position;
            var ingredients = Instantiate(output[1], positionToSpawn, Quaternion.identity,
                transform.root.GetChild(3));
            var substringName = ingredients.name.Substring(0, ingredients.name.Length - 9);
            ingredients.name = substringName;
        }

        public void SpawnThird()
        {
            var positionToSpawn = transform.GetChild(0).position;
            var ingredients = Instantiate(output[2], positionToSpawn, Quaternion.identity,
                transform.root.GetChild(3));
            var substringName = ingredients.name.Substring(0, ingredients.name.Length - 9);
            ingredients.name = substringName;
        }

        public void SpawnFourth()
        {
            var positionToSpawn = transform.GetChild(0).position;
            var ingredients = Instantiate(output[3], positionToSpawn, Quaternion.identity,
                transform.root.GetChild(3));
            var substringName = ingredients.name.Substring(0, ingredients.name.Length - 9);
            ingredients.name = substringName;
        }

        public void SetToIdle()
        {
            GetComponent<Animator>().SetBool("Dispense", false);
        }
    }
}