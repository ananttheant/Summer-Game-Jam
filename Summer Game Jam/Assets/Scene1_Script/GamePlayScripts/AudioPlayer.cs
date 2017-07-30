using UnityEngine;

namespace Scene1_Script.GamePlayScripts
{
    public class AudioPlayer : MonoBehaviour
    {
        public void PlayCorrect()
        {
            transform.GetChild(1).GetComponent<AudioSource>().Play();
        }

        public void PlayWrong()
        {
            transform.GetChild(0).GetComponent<AudioSource>().Play();
        }

        public void PlayDrink()
        {
            transform.GetChild(2).GetComponent<AudioSource>().Play();
        }
    }
}