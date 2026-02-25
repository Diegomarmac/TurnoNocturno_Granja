using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

/// <summary>
/// Gestiona la detección de objetos interactuables mediante Raycast desde la cámara.
/// Permite al jugador interactuar con notas y puertas/llaves.
/// </summary>
public class Raycast : MonoBehaviour
{
    [Header("Configuración del Raycast")]
    [Tooltip("La distancia máxima a la que el Raycast puede detectar objetos.")]
    [SerializeField] private float rayLength;

    // Referencia a la cámara principal para lanzar el rayo desde el centro de la pantalla
    private Camera _camera; 
    
    // Referencias a los controladores de los objetos detectados actualmente
    private NoteController _noteController;
    private DoorController _doorController;

    // Referencia a los inputs del jugador
    private StarterAssetsInputs inputs;

    private void Awake()
    {
        // Busca el componente de inputs en la escena
        inputs = FindFirstObjectByType<StarterAssetsInputs>();
        // Obtiene la cámara adjunta a este objeto
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        // Realiza el raycast en cada frame para detectar objetos
        PerformRaycast();
        // Verifica si el jugador intenta interactuar con el objeto detectado
        InteractionInput();
    }

    /// <summary>
    /// Lanza un rayo desde el centro de la cámara hacia adelante para detectar objetos interactuables.
    /// </summary>
    void PerformRaycast()
    {
        // Crea un rayo desde el centro de la pantalla (Viewport 0.5, 0.5)
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out RaycastHit hit, rayLength))
        {
            // Intenta obtener los componentes interactuables del objeto golpeado
            var readableItem = hit.collider.GetComponent<NoteController>();
            var doorItem = hit.collider.GetComponent<DoorController>();
            
            if (readableItem != null)
            {
                _noteController = readableItem;
                _doorController = null;
            }
            else if(doorItem != null)
            {
                _noteController = null;
                _doorController = doorItem;
            }
            else
            {
                // Si no es un objeto interactuable conocido, limpia las referencias
                Clear();
            }
        }
        else
        {
            // Si el rayo no golpea nada, limpia las referencias
            Clear();
        }
    }

    /// <summary>
    /// Procesa la entrada del jugador para interactuar con el objeto detectado.
    /// </summary>
    void InteractionInput()
    {
        if (inputs == null) return;

        if (_noteController != null)
        {
            if (inputs.interact)
            {
                _noteController.ShowNote();
                // Resetea el input para evitar múltiples interacciones
                inputs.interact = false;
            }
        }
        else if (_doorController != null)
        {
            if (inputs.interact)
            {
                _doorController.ObjectInteract();
                // Resetea el input para evitar múltiples interacciones
                inputs.interact = false;
            }
        }
    }

    /// <summary>
    /// Limpia las referencias a los objetos interactuables cuando ya no están en la mira.
    /// </summary>
    void Clear()
    {
        if (_noteController != null)
        {
            _noteController = null;
        }
        
        if (_doorController != null)
        {
            _doorController = null;
        }
    }
}
