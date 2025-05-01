using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Plate Movement (visual only)")]
    [Tooltip("Drag your child PlateVisual here")]
    public Transform plateVisual; // Reference to the visual part of the plate

    public Vector3 pressDirection = Vector3.down; // Direction the plate visually moves
    public float pressDepth = 0.1f; // How far the plate moves
    public float pressSpeed = 5f; // Speed of the plate movement

    [Header("Activation")]
    public bool correctPlate = false; // Is this the plate meant to trigger something?
    public bool stayDownIfCorrect = false; // Should the plate stay down permanently if it's the correct one?
    public DoorMover doorMover; // Reference to door mover

    private Vector3 originalPos; // Starting position of the plate visual
    private Vector3 pressedPos; // Target position when pressed
    private bool isSteppedOn = false; // Is player currently on the plate?
    private bool hasActivated = false; // Has the plate triggered already?

    void Start()
    {
        if (plateVisual == null)
            plateVisual = transform; // Use self if nothing assigned

        originalPos = plateVisual.localPosition;
        pressedPos = originalPos + pressDirection * pressDepth; // Apply depth and direction
    }

    void Update()
    {
        // Determine if the plate should stay down
        bool shouldStayDown = stayDownIfCorrect && correctPlate && hasActivated;

        // Choose target position based on interaction state or permanent press state
        Vector3 target = (isSteppedOn || shouldStayDown) ? pressedPos : originalPos;

        // Smooth transition between current and target
        plateVisual.localPosition = Vector3.MoveTowards(
            plateVisual.localPosition,
            target,
            pressSpeed * Time.deltaTime
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isSteppedOn = true;

            if (correctPlate && !hasActivated)
            {
                if (doorMover != null)
                {
                    doorMover.OpenDoors(); // Trigger door
                    hasActivated = true;   // Prevent reactivation
                }
                else
                {
                    Debug.LogWarning($"[{name}] doorMover not assigned");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Don't unset isSteppedOn if the plate should stay down
            if (!(stayDownIfCorrect && correctPlate && hasActivated))
                isSteppedOn = false;
        }
    }
}
