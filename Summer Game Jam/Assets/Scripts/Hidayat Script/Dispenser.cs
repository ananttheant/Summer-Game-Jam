
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    public KeyCode[] keyPressed; // the key pressed by the player. TODO
    public GameObject[] output; // this is the game object that should be present in the scene , cuz it will get duplicated.
    

	// Update is called once per frame
	private void Update ()
    {
        for (int i = 0; i < keyPressed.Length; i++)
        {
            if (Input.GetKeyDown(keyPressed[i]))
            {
                Vector3 positionToSpawn = transform.GetChild(0).position;
                GameObject ingredients = Instantiate(output[i], positionToSpawn, Quaternion.identity, transform.root);
            }
        }
    }

}
