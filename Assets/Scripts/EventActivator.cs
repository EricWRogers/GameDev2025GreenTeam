using UnityEngine;

public class EventActivator : MonoBehaviour
{
    public GameObject targetObject;
    private void OnTriggerEnter(Collider other)
    {
        targetObject.SetActive(true);
        gameObject.SetActive(false);
    }
}