using UnityEngine;

public class Pickup : MonoBehaviour
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
       