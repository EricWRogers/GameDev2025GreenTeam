using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [Header("Plate Movement (visual only)")]
    [Tooltip("Drag your child PlateVisual here")]
    public Transform plateVisual;

    public Vector3 pressDirection = Vector3.down;
    public float pressDepth = 0.1f;
    public float pressSpeed = 5f;

    [Header("Activation")]
    public bool correctPlate = false;
    public DoorMover doorMover;   

    private Vector3 originalPos;
    private Vector3 pressedPos;
    private bool isSteppedOn = false;
    private bool hasActivated = false;

    void Start()
    {
        if (plateVisual == null)
            plateVisual = transform; // fallback, but ideally assign child

        originalPos = plateVisual.localPosition;
        pressedPos = originalPos + pressDirection.normalized * pressDepth;
    }

    void Update()
    {
        // Move only the visual down/up
        Vector3 target = isSteppedOn ? pressedPos : originalPos;
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
                    doorMover.OpenDoors();
                    hasActivated = true;
                }
                else
                {
                    Debug.LogWarning($"[{name}] doorMover not assigned!");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isSteppedOn = false;
    }
}
