using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Administra la interfaz de usuario del inventario, mostrando las llaves recolectadas.
/// </summary>
public class UInventManager : MonoBehaviour
{
    [Header("Configuración de UI")]
    [Tooltip("El panel donde se instanciarán las imágenes de las llaves.")]
    [SerializeField] private Transform keyPanel;

    [Tooltip("El prefab de la llave en UI.")]
    [SerializeField] private GameObject keyImagePrefab;
    
    // Diccionario para rastrear las imágenes de las llaves creadas y evitar duplicados.
    private Dictionary<KeySO, GameObject> keyImages = new Dictionary<KeySO, GameObject>();
    
    /// <summary>
    /// Instancia única de la clase (Singleton).
    /// </summary>
    public static UInventManager Instance { get; private set; }

    private void Awake()
    {
        // Implementación del patrón Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Agrega una llave a la interfaz de usuario si no ha sido agregada previamente.
    /// </summary>
    /// <param name="key">El objeto ScriptableObject de la llave a agregar.</param>
    public void AddKeyToUi(KeySO key)
    {
        // Verifica si la llave ya está en el diccionario
        if (!keyImages.ContainsKey(key))
        {
            // Instancia el prefab de la imagen de la llave en el panel
            GameObject keyImage = Instantiate(keyImagePrefab, keyPanel);
            
            // Asigna el sprite de la llave al componente Image
            keyImage.GetComponent<Image>().sprite = key.keySprite;
            
            // Agrega la llave y su imagen al diccionario
            keyImages[key] = keyImage;
        }
    }
}
