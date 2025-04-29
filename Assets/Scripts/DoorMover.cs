using UnityEngine;


// This script controls the movement of two doors based on certain conditions
public class DoorMoverNew : MonoBehaviour
{
    // Public references to the door GameObjects in the scene
    public GameObject door1;
    public GameObject door2;


    // Directions in which each door will move when activated
    public Vector3 door1Direction = Vector3.up;
    public Vector3 door2Direction = Vector3.up;


    // How far each door will move from its starting position
    public float moveDistance = 3f;
    public float moveSpeed = 2f;


    // Initial positions of the doors, set at start
    private Vector3 door1StartPos;
    private Vector3 door2StartPos;


    // Flags to track whether each door should currently be moving
    private bool door1Moving = false;
    private bool door2Moving = false;


    // Flags and codes used to control door movement based on external conditions
    public bool lightactive = false;
    public bool coinactive = false;


    public int lightcode = 9999;         // Code needed from torch to open the door
    public int coincode = 999999999;     // Coin count needed to open the door


    void Start()
    {
        // Store the starting position of each door if they are assigned
        if (door1 != null)
            door1StartPos = door1.transform.position;
        if (door2 != null)
            door2StartPos = door2.transform.position;
    }


    void Update()
    {
        // If the door is flagged as moving, move it towards the target position
        if (door1Moving && door1 != null)
        {
            MoveDoor(door1, door1StartPos, door1Direction);
        }


        if (door2Moving && door2 != null)
        {
            MoveDoor(door2, door2StartPos, door2Direction);
        }


        // If the light is active and the torchCode matches the required code, move door1
        if (lightactive == true && GlobalVarsSetup.torchCode == lightcode)
        {
            MoveDoor(door1, door1StartPos, door1Direction);
        }


        // If the coin condition is active and player has enough coins, move door1
        if (coinactive == true && GlobalVarsSetup.coincount >= coincode)
        {
            MoveDoor(door1, door1StartPos, door1Direction);
        }
    }


    // Moves a given door towards its target position based on direction and distance
    private void MoveDoor(GameObject door, Vector3 startPos, Vector3 direction)
    {
        Vector3 targetPos = startPos + direction.normalized * moveDistance;
        door.transform.position = Vector3.MoveTowards(door.transform.position, targetPos, moveSpeed * Time.deltaTime);
    }


    // Public method that starts moving both doors when called
    public void OpenDoors()
    {
        if (door1 != null)
            door1Moving = true;
        if (door2 != null)
            door2Moving = true;
    }
}





