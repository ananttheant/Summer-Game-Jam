
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    public KeyCode[] keyPressed; // the key pressed by the player. TODO
    public GameObject[] output; // this is the game object that should be present in the scene , cuz it will get duplicated.

    
    private KeyCode _lastPressed;
    private const float TimeToPress = 1;
    private float _startTime = 0;
    // Update is called once per frame
	void Update ()
    {
        if (Time.time > _startTime + TimeToPress)
        {
            for (int i = 0; i < keyPressed.Length; i++)
            {
                if (Input.GetKeyDown(keyPressed[i]))
                {
                    _startTime = Time.time;
                    _lastPressed = keyPressed[i];
                    GetComponent<Animator>().SetBool("Dispense", true);
                }
            }
        }
    }

    public void SpawnObject()
    {
        for (int i = 0; i < keyPressed.Length; i++)
        {
            if (keyPressed[i] == _lastPressed)
            {
                Vector3 positionToSpawn = transform.GetChild(0).position;
                GameObject ingredients = Instantiate(output[i], positionToSpawn, Quaternion.identity, transform.root.GetChild(0));
                string name = ingredients.name.Substring(0, ingredients.name.Length - 9);
                ingredients.name = name;
            }
        }
    }

    public void SetToIdle()
    {
        GetComponent<Animator>().SetBool("Dispense", false);
    }
}
