using UnityEngine;

public class TorchPlacerTorchSpawn : MonoBehaviour, IInteractable
{
    public GameObject torch;
    public int torchCode = 0;
    public int thisTorchVal = 0;

    public void Start()
    {
        torch.SetActive(false);
    }
    public void DoSomething()
    {
        if (Input.GetKeyDown("e"))
        {
            torchCode = thisTorchVal;
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
