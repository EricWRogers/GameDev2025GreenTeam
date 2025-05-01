using UnityEngine;

public class ButtonPress : MonoBehaviour, IInteractable
{
    [Header("Button Settings")]

    [Tooltip("Set true if this is the correct button that should open the doors.")]
    public bool correctButton = false;

    [Tooltip("How far the button moves inward when pressed.")]
    public float pressDepth = 0.3f;

    [Tooltip("Speed of the button press and release animation.")]
    public float pressSpeed = 1f;

    [Tooltip("Direction the button moves when pressed.")]
    public Vector3 pressDirection = Vector3.back;

    [Header("References")]

    [Tooltip("Reference to the DoorMover script to trigger door actions.")]
    public DoorMover doorMover;

    // Internal state tracking
    private Vector3 originalPosition;     // The button's initial position
    private Vector3 pressedPosition;      // Target position when pressed
    private bool isPressed = false;       // Whether the button is currently animating as pressed
    private bool isLookingAt = false;     // Whether the player is looking at this button this frame
    private bool hasActivated = false;    // Prevents multiple door activations

    void Start()
    {
        // Store the initial position of the button
        originalPosition = transform.localPosition;

        // Calculate where the button should move when pressed
        pressedPosition = originalPosition + pressDirection.normalized * pressDepth;
    }

    void Update()
    {
        // Animate button press movement
        if (isPressed)
        {
            // Move toward the pressed position
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, pressedPosition, Time.deltaTime * pressSpeed);

            // If it's not a correct button, let it return after pressing
            if (!correctButton && Vector3.Distance(transform.localPosition, pressedPosition) < 0.001f)
            {
                isPressed = false;
            }
        }
        else
        {
            // If not pressed, return to original position
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, originalPosition, Time.deltaTime * pressSpeed);
        }

        // If player is looking at this and presses E this frame, trigger the press
        if (isLookingAt && Input.GetKeyDown(KeyCode.E))
        {
            PressButton();
        }

        // Reset look flag every frame to require fresh raycast input
        isLookingAt = false;
    }

    public void PressButton()
    {
        isPressed = true;

        // Activate door only once, and only if this is the correct button
        if (correctButton && !hasActivated && doorMover != null)
        {
            doorMover.OpenDoors();   // Trigger door opening logic
            hasActivated = true;     // Prevent re-triggering
        }
    }

    public void DoSomething()
    {
        isLookingAt = true;
    }
}
