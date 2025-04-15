using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactivity : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    public TMP_Text textMeshPro;

    void Update()
    {
            RaycastHit hit;
            var raycastThing = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);

            if (raycastThing)
            {
                IInteractable interactable = hit.transform.GetComponent<IInteractable>();

                if (interactable != null)
            {
                textMeshPro.enabled = true;
                interactable.DoSomething();
            }
            else
            {
                textMeshPro.enabled = false;
            }
        }
    }
}

public interface IInteractable
{
    public void DoSomething();
}