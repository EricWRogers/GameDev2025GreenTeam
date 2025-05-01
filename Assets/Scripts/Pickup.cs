using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    public int value = 1;
    public AudioClip soundCollect;
    public void DoSomething()
    {
        if (Input.GetKeyDown("e"))
        {
            GlobalVarsSetup.coincount += value;
            AudioSource.PlayClipAtPoint(soundCollect, transform.position);
            gameObject.SetActive(false);
        }
    }
}
       