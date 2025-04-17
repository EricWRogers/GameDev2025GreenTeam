using UnityEngine;

public class ButtonPress : MonoBehaviour, IInteractable
{
    public bool correctButton = false;
    public float pressDepth = 0.1f;
    public float pressSpeed = 5f;

    public Vector3 pressDirection = Vector3.back; // <-- New! Manual control over press direction
    public DoorMover doorMover; // Reference to DoorMover script

    private Vector3 originalPosition;
    private Vector3 pressedPosition;
    private bool isPressed = false;
    private bool isLookingAt = false;
    private bool hasActivatedDoors = false; // So doors only open once

    void Start()
    {
        originalPosition = transform.localPosition;
        pressedPosition = originalPosition + pressDirection.normalized * pressDepth;
    }

    void Update()
    {
        if (isPressed)
        {
            if (correctButton)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, pressedPosition, Time.deltaTime * pressSpeed);
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, pressedPosition, Time.deltaTime * pressSpeed);

                if (Vector3.Distance(transform.localPosition, pressedPosition) < 0.001f)
                {
                    isPressed = false;
                }
            }
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, originalPosition, Time.deltaTime * pressSpeed);
        }

        if (isLookingAt && Input.GetKeyDown(KeyCode.E))
        {
            PressButton();
        }
    }

    public void PressButton()
    {
        isPressed = true;

        if (correctButton && !hasActivatedDoors)
        {
            if (doorMover != null)
            {
                doorMover.OpenDoors();
                hasActivatedDoors = true;
            }
            else
            {
                Debug.LogWarning("DoorMover not assigned to ButtonPress!");
            }
        }
    }

    public void DoSomething()
    {
        isLookingAt = true;
    }

    private void LateUpdate()
    {
        isLookingAt = false;
    }
}
