using Unity.VisualScripting;
using UnityEngine;

public class TorchPlacerTorchSpawn : MonoBehaviour, IInteractable
{
    public GameObject torch;
    public GameObject held_torch;
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
            if (GlobalVarsSetup.torchCode == thisTorchVal && torch.activeSelf == true)
            {
                GlobalVarsSetup.torchCode = otherTorchval;
            }
            else if (GlobalVarsSetup.torchCode != thisTorchVal && held_torch.activeSelf == true)
            {
                GlobalVarsSetup.torchCode = thisTorchVal;
            }

            if (torch.activeSelf == false && held_torch.activeSelf == false)
            {
                GlobalVarsSetup.torchCode = 4;
            }
        
            if (GlobalVarsSetup.torchCode == thisTorchVal)
            {
                torch.SetActive(true);
                held_torch.SetActive(false);
            }
            else if (GlobalVarsSetup.torchCode == otherTorchval)
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
