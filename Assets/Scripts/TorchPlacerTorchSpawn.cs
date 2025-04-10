using UnityEngine;

public class TorchPlacerTorchSpawn : MonoBehaviour, IInteractable
{
    public GameObject torch;
    public int torchCode = 0;
    public int thisTorchVal = 1;
    public int nottorchval = 0;

    public void Start()
    {
        torch.SetActive(false);
    }
    public void DoSomething()
    {
        if (Input.GetKeyDown("e"))
        {
            if (torchCode == thisTorchVal)
            {
                torchCode -= 1;
            }
            if (torchCode != thisTorchVal)
            {
                torchCode += 1;
            }
        }
        if (torchCode == thisTorchVal)
        {
            torch.SetActive(true);
        }
        else
        {
            torch.SetActive(false);
        }
    }
}
