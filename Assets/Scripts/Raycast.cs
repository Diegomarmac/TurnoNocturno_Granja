using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] float rayLength;

    private Camera _camera; 
    
    private NoteController _noteController;
    private DoorController _doorController;

    StarterAssetsInputs inputs;

    private void Awake()
    {
        inputs = FindFirstObjectByType<StarterAssetsInputs>();
        _camera = GetComponent<Camera>();
    }


    void Update()
    {
        
        PerformRaycast();
        InteractionInput();

    }

    void PerformRaycast()
    {
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward,
                out RaycastHit hit, rayLength))
        {
            var readableItem = hit.collider.GetComponent<NoteController>();
            var doorItem = hit.collider.GetComponent<DoorController>();
            
            // Primero manejamos las notas ya que es lo que más se usará...
            if (readableItem != null)
            {
                _noteController = readableItem;
                _doorController = null;
            }else if(doorItem != null)
            {
                _noteController = null;
                _doorController = doorItem;
            }
            else
            {
                Clear();
            }
        }
        else
        {
            Clear();
        }
    }

    void InteractionInput()
    {
        if (_noteController != null)
        {
            if (inputs.interact)
            {
                _noteController.ShowNote();
                inputs.interact = false;
            }
        }else if (_doorController != null)
        {
            if (inputs.interact)
            {
                _doorController.ObjectInteract();
                inputs.interact = false;
            }
        }
    }

    void Clear()
    {
        if (_noteController != null)
        {
            _noteController = null;
        }else if (_doorController != null)
        {
            _doorController = null;
        }
    }
    
    
}