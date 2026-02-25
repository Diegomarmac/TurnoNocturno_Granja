using UnityEngine;
using StarterAssets;
using TMPro;
using UnityEngine.Events;

/// <summary>
/// Controla la visualización de notas en el juego, permitiendo al jugador leer texto en una interfaz dedicada.
/// </summary>
public class NoteController : MonoBehaviour
{
    [Header("Configuración de UI")]
    [Tooltip("El objeto Canvas o Panel que contiene la interfaz de la nota.")]
    [SerializeField] GameObject noteCanvas;

    [Tooltip("El componente de texto (TextMeshPro) donde se mostrará el contenido.")]
    [SerializeField] TMP_Text noteTextArea;

    [Header("Contenido de la Nota")]
    [Tooltip("El texto específico que se mostrará en esta nota.")]
    [SerializeField] [TextArea] private string noteText;

    [Header("Eventos")]
    [Tooltip("Evento que se invoca cuando se abre la nota.")]
    [SerializeField] private UnityEvent openEvent;

    // Estado interno para saber si la nota está visible
    private bool isOpen = false;
    
    // Referencia a los inputs del jugador
    private StarterAssetsInputs inputs;

    private void Awake()
    {
        // Busca el componente de inputs en la escena
        inputs = FindFirstObjectByType<StarterAssetsInputs>();
    }
    
    /// <summary>
    /// Muestra la nota en la pantalla, actualiza el texto y dispara los eventos asociados.
    /// </summary>
    public void ShowNote()
    {
        if (noteTextArea != null)
        {
            noteTextArea.text = noteText;
        }
        
        if (noteCanvas != null)
        {
            noteCanvas.SetActive(true);
        }

        if (openEvent != null)
        {
            openEvent.Invoke();
        }
        
        isOpen = true;
    }

    /// <summary>
    /// Oculta la nota y restablece el estado de interacción.
    /// </summary>
    void Disablenote()
    {
        if (noteCanvas != null)
        {
            noteCanvas.SetActive(false);
        }
        isOpen = false;
    }

    void Update()
    {
        // Si la nota está abierta, espera a que el jugador presione el botón de interacción para cerrarla
        if (isOpen)
        {
            if (inputs != null && inputs.interact)
            {
                Disablenote();
                // Resetea el input para evitar interacciones accidentales inmediatas
                inputs.interact = false;
            }
        }
    }
}
