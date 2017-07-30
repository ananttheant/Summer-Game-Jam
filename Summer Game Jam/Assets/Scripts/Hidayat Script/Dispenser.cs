
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    public GameObject[] output; // this is the game object that should be present in the scene , cuz it will get duplicated.

    
    private const float TimeToPress = 1;
    private float _startTime = 0;

    public void SpawnFirst()
    {
        Vector3 positionToSpawn = transform.GetChild(0).position;
        GameObject ingredients = Instantiate(output[0], positionToSpawn, Quaternion.identity, transform.root.GetChild(3));
        string name = ingredients.name.Substring(0, ingredients.name.Length - 9);
        ingredients.name = name;
    }

    public void SpawnSecond()
    {
        Vector3 positionToSpawn = transform.GetChild(0).position;
        GameObject ingredients = Instantiate(output[1], positionToSpawn, Quaternion.identity, transform.root.GetChild(3));
        string name = ingredients.name.Substring(0, ingredients.name.Length - 9);
        ingredients.name = name;
    }

    public void SpawnThird()
    {
        Vector3 positionToSpawn = transform.GetChild(0).position;
        GameObject ingredients = Instantiate(output[2], positionToSpawn, Quaternion.identity, transform.root.GetChild(3));
        string name = ingredients.name.Substring(0, ingredients.name.Length - 9);
        ingredients.name = name;
    }

    public void SpawnFourth()
    {
        Vector3 positionToSpawn = transform.GetChild(0).position;
        GameObject ingredients = Instantiate(output[3], positionToSpawn, Quaternion.identity, transform.root.GetChild(3));
        string name = ingredients.name.Substring(0, ingredients.name.Length - 9);
        ingredients.name = name;
    }

    public void SetToIdle()
    {
        GetComponent<Animator>().SetBool("Dispense", false);
    }
}
