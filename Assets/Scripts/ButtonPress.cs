using UnityEngine;

// This script allows a button to be interacted with and animate when pressed.
// If it's the correct button, it will open doors via the DoorMover script.
public class ButtonPress : MonoBehaviour, IInteractable
{
    // Set to true in the Inspector if this is the correct button that opens the door
    public bool correctButton = false;

    // How far the button moves inward when pressed
    public float pressDepth = 0.3f;

    // How quickly the button moves
    public float pressSpeed = 1f;

    // Direction the button moves when pressed (can be customized per button)
    public Vector3 pressDirection = Vector3.back;

    // Reference to the DoorMover script that this button should trigger
    public DoorMover doorMover;

    // Internal state
    private Vector3 originalPosition;     // The button's starting position
    private Vector3 pressedPosition;      // The target position when pressed
    private bool isPressed = false;       // Whether the button is currently animating as pressed
    private bool isLookingAt = false;     // Whether the player is currently looking at this button
    private bool hasActivated = false;    // Ensures the door only opens once

    void Start()
    {
        // Save the original position of the button
        originalPosition = transform.localPosition;

        // Calculate the pressed position based on the direction and depth
        pressedPosition = originalPosition + pressDirection.normalized * pressDepth;
    }

    void Update()
    {
        // If the button has been pressed, move it toward the pressed position
        if (isPressed)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, pressedPosition, Time.deltaTime * pressSpeed);

            // If it's NOT the correct button, allow it to return after fully pressed
            if (!correctButton && Vector3.Distance(transform.localPosition, pressedPosition) < 0.001f)
            {
                isPressed = false;
            }
        }
        else
        {
            // Button returns to its original position when not pressed
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, originalPosition, Time.deltaTime * pressSpeed);
        }

        // Player input: if player is looking at this button and presses E
        if (isLookingAt && Input.GetKeyDown(KeyCode.E))
        {
            PressButton();
        }
    }

    public void PressButton()
    {
        isPressed = true;

        // If this is the correct button and hasn't already activated the door
        if (correctButton && !hasActivated && doorMover != null)
        {
            doorMover.OpenDoors();   // Trigger the door to open
            hasActivated = true;     // Prevent multiple activations
        }
    }

    public void DoSomething()
    {
        isLookingAt = true;
    }

    public void ResetLookingAt()
    {
        isLookingAt = false;
    }
}
