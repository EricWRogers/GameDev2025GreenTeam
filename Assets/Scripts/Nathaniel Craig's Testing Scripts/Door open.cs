using UnityEngine;

public class Dooropen : MonoBehaviour
{
    public GameObject door;
    public GameObject open;

    // Update is called once per frame
    void Update()
    {
        if (open.activeSelf == true)
        {
            door.SetActive(false);
        }
    }
}
