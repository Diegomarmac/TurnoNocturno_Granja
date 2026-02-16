using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] float rayLength;

    private Camera _camera; 
    
    private NoteController _noteController;

    StarterAssetsInputs inputs;

    private void Awake()
    {
        inputs = FindFirstObjectByType<StarterAssetsInputs>();
    }
    
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward,
                out RaycastHit hit, rayLength))
        {
            var readableItem = hit.collider.GetComponent<NoteController>();

            if (readableItem != null)
            {
                _noteController = readableItem;
            }
            else
            {
                ClearNote();
            }
        }
        else
        {
            ClearNote();
        }

        if (_noteController != null)
        {
            if (inputs.interact)
            {
                _noteController.ShowNote();
                inputs.interact = false;
            }
        }
    }


    void ClearNote()
    {
        if (_noteController != null)
        {
            _noteController = null;
        }
    }
    
    
}