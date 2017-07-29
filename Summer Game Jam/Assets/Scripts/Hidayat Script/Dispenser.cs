
using UnityEngine;

public class Dispenser : MonoBehaviour
{

    public string KeyPressed; // the key pressed by the player. TODO
    public GameObject Output; // this is the game object that should be present in the scene , cuz it will get duplicated.
    

	// Update is called once per frame
	private void Update ()
    {
        if (Input.GetKeyDown(KeyPressed))
        {
            DespenseObject();
        }
    }

    private void DespenseObject()
    {
        var position = gameObject.transform.position;
        Object.Instantiate(Output, position , Output.transform.rotation , gameObject.transform);
    }

}
