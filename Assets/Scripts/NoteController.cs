using UnityEngine;
using StarterAssets;
using TMPro;
using UnityEngine.Events;

public class NoteController : MonoBehaviour
{
    [SerializeField] GameObject noteCanvas;
    [SerializeField] TMP_Text noteTextArea;
    [SerializeField] [TextArea] private string noteText;
    [SerializeField] private UnityEvent openEvent;

    private bool isOpen = false;
    
    StarterAssetsInputs inputs;

    private void Awake()
    {
        inputs = FindFirstObjectByType<StarterAssetsInputs>();
    }
    

    public void ShowNote()
    {
        noteTextArea.text = noteText;
        noteCanvas.SetActive(true);
        openEvent.Invoke();
        
        isOpen = true;
    }

    void Disablenote()
    {
        noteCanvas.SetActive(false);
        isOpen = false;
    }

    void Update()
    {
        if (isOpen)
        {
            if (inputs.interact)
            {
                Disablenote();
                inputs.interact = false;
            }
        }
    }
    
    
    
}
