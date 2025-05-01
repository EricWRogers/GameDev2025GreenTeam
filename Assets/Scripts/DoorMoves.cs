using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class DoorMover : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;

    public Vector3 door1Direction = Vector3.up;
    public Vector3 door2Direction = Vector3.up;

    public float moveDistance = 3f;
    public float moveSpeed = 2f;

    public Vector3 door1StartPos = Vector3.up;
    private Vector3 door2StartPos;

    private bool door1Moving = false;
    private bool door2Moving = false;

    public bool lightactive = false;
    public bool coinactive = false;
    public bool returns = false;

    public int lightcode = 9999;
    public int coincode = 999999999;
    private int moved = 0;
    public AudioClip doorSound;


    void Start()
    {
        if (door1 != null)
            door1StartPos = door1.transform.position;
        if (door2 != null)
            door2StartPos = door2.transform.position;
    }

    void Update()
    {
        if (door1Moving && door1 != null)
        {
            MoveDoor(door1, door1StartPos, door1Direction);
        }

        if (door2Moving && door2 != null)
        {
            MoveDoor(door2, door2StartPos, door2Direction);
        }
        if (lightactive == true && GlobalVarsSetup.torchCode == lightcode)
        {
            MoveDoor(door1, door1StartPos, door1Direction);
            moved = 1;
        }
        if (coinactive == true && GlobalVarsSetup.coincount >= coincode)
        {
            MoveDoor(door1, door1StartPos, door1Direction);
        }
        if (returns == true && lightactive == true && lightcode != GlobalVarsSetup.torchCode && door1StartPos != door1.transform.position && moved != 0)
        {
            MoveDoorBack(door1, door1StartPos, door1Direction);
        }
        if (door1.transform.position == door1StartPos)
        {
            moved = 0;
        }
    }

    private void MoveDoor(GameObject door, Vector3 startPos, Vector3 direction)
    {
        Vector3 targetPos = startPos + direction.normalized * moveDistance;
        door.transform.position = Vector3.MoveTowards(door.transform.position, targetPos, moveSpeed * Time.deltaTime);
        AudioSource.PlayClipAtPoint(doorSound, door.transform.position, 2f);
    }
    private void MoveDoorBack(GameObject door, Vector3 startPos, Vector3 direction)
    {
        door.transform.position = Vector3.MoveTowards(door.transform.position, door1StartPos, moveSpeed * Time.deltaTime);
        AudioSource.PlayClipAtPoint(doorSound, door.transform.position, 2f);
    }

    public void OpenDoors()
    {
        if (door1 != null)
            door1Moving = true;
        if (door2 != null)
            door2Moving = true;
    }
}
