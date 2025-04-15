using UnityEngine;

public class ArmHoldingTorch : MonoBehaviour
{
    public GameObject torch;
    void Update()
    {
        if (GlobalVarsSetup.torchCode == 0)
        {
            torch.SetActive(true);
        }
        else
        {
            torch.SetActive(false);
        }
    }
}
