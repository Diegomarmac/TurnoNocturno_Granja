using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gestiona el inventario de llaves del jugador, permitiendo agregar y verificar la posesión de llaves.
/// </summary>
public class KeyInventory : MonoBehaviour
{
    [Header("Estado del Inventario")]
    [Tooltip("Lista de IDs de las llaves que el jugador ha recolectado.")]
    [SerializeField] private List<int> keyIds = new List<int>();
    
    /// <summary>
    /// Instancia única de la clase (Singleton).
    /// </summary>
    public static KeyInventory Instance { get; private set; }

    private void Awake()
    {
        // Implementación del patrón Singleton
        if (Instance == null)
        {
            Instance = this;
            // Hace que el objeto persista entre cargas de escenas
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            // Si ya existe una instancia, destruye este objeto duplicado
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Agrega una llave al inventario si no se posee ya.
    /// </summary>
    /// <param name="key">El ScriptableObject de la llave a agregar.</param>
    public void AddKey(KeySO key)
    {
        // Verifica si la llave ya está en la lista por su ID
        if (!keyIds.Contains(key.id))
        {
            keyIds.Add(key.id);
            Debug.Log($"Llave agregada: {key.KeyName}");
            
            // Actualiza la interfaz de usuario si existe el manager
            if (UInventManager.Instance != null)
            {
                UInventManager.Instance.AddKeyToUi(key);
            }
        }
    }

    /// <summary>
    /// Verifica si el jugador posee una llave específica.
    /// </summary>
    /// <param name="key">El ScriptableObject de la llave a verificar.</param>
    /// <returns>True si la llave está en el inventario, False en caso contrario.</returns>
    public bool HasKey(KeySO key)
    {
        return keyIds.Contains(key.id);
    }
}
