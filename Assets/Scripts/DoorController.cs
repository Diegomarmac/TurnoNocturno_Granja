using UnityEngine;

/// <summary>
/// Controlador central para objetos interactuables como puertas y llaves.
/// Delega la interacción al componente específico según el tipo configurado.
/// </summary>
public class DoorController : MonoBehaviour
{
    /// <summary>
    /// Tipos de objetos interactuables disponibles.
    /// </summary>
    public enum ItemType
    {
        None,
        Door, // Puerta
        Key,  // Llave
    }
  
    [Header("Configuración del Objeto")]
    [Tooltip("Define el tipo de objeto interactuable para este GameObject.")]
    [SerializeField] private ItemType _itemType = ItemType.None;
  
    // Referencias a los componentes específicos de interacción
    private DoorInteractable doorInteractable;
    private KeyCollectable keyCollectable;
  
    private void Awake()
    {
        // Obtiene la referencia al componente correspondiente según el tipo seleccionado
        switch (_itemType)
        {
            case ItemType.Door: 
                doorInteractable = GetComponent<DoorInteractable>(); 
                break;
            case ItemType.Key: 
                keyCollectable = GetComponent<KeyCollectable>(); 
                break;
        }
    }

    /// <summary>
    /// Ejecuta la lógica de interacción correspondiente al tipo de objeto.
    /// </summary>
    public void ObjectInteract()
    {
        switch (_itemType)
        {
            case ItemType.Door: 
                // Intenta abrir o cerrar la puerta si el componente existe
                doorInteractable?.ToggleDoor(); 
                break;
            case ItemType.Key: 
                // Intenta recoger la llave si el componente existe
                keyCollectable?.KeyPickUp(); 
                break;
        }
    }
}
