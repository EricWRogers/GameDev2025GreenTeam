using Unity.VisualScripting;
using UnityEngine;

public class TorchPlacerTorchSpawn : MonoBehaviour, IInteractable
{
    public GameObject torch;
    public GameObject held_torch;
    public int torchCode = 0;
    public int thisTorchVal = 1;
    public int otherTorchval = 0;

    public void Start()
    {
        torch.SetActive(false);
    }
    public void DoSomething()
    {
        if (Input.GetKeyDown("e"))
        {
            if (torchCode == thisTorchVal && torch.activeSelf == true)
            {
                torchCode = otherTorchval;
            }
            else if (torchCode != thisTorchVal && held_torch.activeSelf == true)
            {
                torchCode = thisTorchVal;
            }

            if (torch.activeSelf == false && held_torch.activeSelf == false)
            {
                torchCode = 4;
            }
        
            if (torchCode == thisTorchVal)
            {
                torch.SetActive(true);
                held_torch.SetActive(false);
            }
            else if (torchCode == otherTorchval)
            {
                torch.SetActive(false);
                held_torch.SetActive(true);
            }
            else
            {
            }
    }
    }
}
