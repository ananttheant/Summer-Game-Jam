
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Scene1_Script.GamePlayScripts
{
    public class IceCreamFlavourScript : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collider)
        {
            switch(collider.name)
            {
                case "Sprinkle" :
                {
                    Destroy(collider.GetComponent<Rigidbody2D>());
                    collider.transform.SetParent(transform);
                    collider.transform.localPosition = new Vector3(7.7f, 3.6f, 0);
                        break;
                    
                }
            
                 case "Syrup":
                {
                    Destroy(collider.GetComponent<Rigidbody2D>());
                    collider.transform.SetParent(transform);
                    collider.transform.localPosition = new Vector3(4.4f, 0, 0);
                    break;
                }
                default: Debug.Log("damn");
                    break;
                    
            }
            
        }
    }
}