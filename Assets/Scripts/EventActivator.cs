using UnityEngine;

public class EventActivator : MonoBehaviour
{
    public GameObject targetObject;
    public bool deactivatorInstead = false;
    private void OnTriggerEnter(Collider other)
    {
        if (deactivatorInstead != true)
        {
            targetObject.SetActive(true);
        }
        else
        {
            targetObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}