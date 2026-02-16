using UnityEngine;

public class DoorInteractable : MonoBehaviour
{

    [SerializeField] private Transform doorPivot;
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float closeAngle = 0f;
    [SerializeField] private float speed = 2f;
    
    
    private bool isOpen = false;
    private bool isAnimating = false;
    private Quaternion targetRot;

    private void Start()
    {
        targetRot = Quaternion.Euler(0f, closeAngle, 0f);
    }

    private void Update()
    {
        if (isAnimating)
        {
            doorPivot.localRotation = Quaternion.Lerp(doorPivot.localRotation, targetRot, speed * Time.deltaTime);

            if (Quaternion.Angle(doorPivot.localRotation, targetRot) < 0.1f)
            {
                doorPivot.localRotation = targetRot;
                isAnimating = false;
            }
        }
    }
    
    public void ToggleDoor()
    {
        if (!isAnimating)
        {
            isOpen = !isOpen;
            
            targetRot = Quaternion.Euler(0f, isOpen ? openAngle : closeAngle, 0f);
            
            isAnimating = true;
        }
    }
}
