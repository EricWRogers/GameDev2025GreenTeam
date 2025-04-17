using UnityEngine;

public class Fog_Start : MonoBehaviour
{
    public bool door = false;
    private void OnTriggerEnter(Collider other)
    {
        if (door == false)
        {
            door = true;
        }
        else if (door == true)
        {
            door = false;
        }
        
        if (door == true)
        {
            RenderSettings.fog = true;
        }
        else if (door == false)
        {
            RenderSettings.fog = false;
        }
    }
}
