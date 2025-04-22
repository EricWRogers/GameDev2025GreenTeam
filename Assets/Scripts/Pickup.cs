using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    public int value = 1;
    public void DoSomething()
    {
        if (Input.GetKeyDown("e"))
        {
            GlobalVarsSetup.coincount += value;
            gameObject.active = false;
        }
    }
}
       