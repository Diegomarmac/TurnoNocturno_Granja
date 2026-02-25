using UnityEngine;

/// <summary>
/// Controla un generador de luz que activa o desactiva luces en la escena
/// basándose en la interacción del jugador y el consumo de energía definido en un ScriptableObject.
/// </summary>
public class LightGenerator : MonoBehaviour
{
    [Header("Configuración de Energía")]
    [Tooltip("ScriptableObject que contiene los datos de energía (tiempo de encendido, carga, etc.).")]
    [SerializeField] private FlashlightSO flashlightSO;

    [Header("Referencias de Luces")]
    [Tooltip("Primera luz controlada por el generador.")]
    [SerializeField] private GameObject lightA;
    [Tooltip("Segunda luz controlada por el generador.")]
    [SerializeField] private GameObject lightB;
    //[SerializeField] GameObject lightsText; // Referencia opcional para texto de UI
    
    [Header("Audio")]
    [Tooltip("Fuente de audio que se reproduce al interactuar con el generador.")]
    [SerializeField] private AudioSource audioSource;
    
    // Estado actual de las luces (encendidas/apagadas)
    private bool lightsActive = false;

    private void Awake()
    {
        // Inicializa la energía al máximo al comenzar
        if (flashlightSO != null)
        {
            flashlightSO.tiempoEncendido = flashlightSO.maxTime;
        }
    }

    private void Start()
    {
        // Asegura que las luces comiencen apagadas
        if (lightA != null) lightA.SetActive(false);
        if (lightB != null) lightB.SetActive(false);
    }

    /// <summary>
    /// Detecta cuando el jugador entra en la zona del generador para activar/desactivar las luces.
    /// </summary>
    /// <param name="other">El collider que entró en el trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnOffHandle();
            if (audioSource != null) audioSource.Play();
        }
    }

    private void Update()
    {
        // Si las luces están activas, consume energía
        if (lightsActive)
        {
            flashlightSO.tiempoEncendido -= Time.deltaTime;
        }
        
        // Si se acaba la energía, las luces se apagan automáticamente
        if (flashlightSO.tiempoEncendido <= 0) 
        {
            // Solo apaga si estaban encendidas para evitar llamadas redundantes
            if (lightsActive)
            {
                OnOffHandle();
                if (audioSource != null) audioSource.Stop();
            }
            flashlightSO.tiempoEncendido = 0f;
        }

        // Si las luces están apagadas, la energía se recarga
        if (!lightsActive) 
        {
            flashlightSO.tiempoEncendido += flashlightSO.tiempoCarga * Time.deltaTime;
        }

        // Limita la energía al máximo permitido
        if (flashlightSO.tiempoEncendido >= flashlightSO.maxTime) 
        {
            flashlightSO.tiempoEncendido = flashlightSO.maxTime; 
        }
    }

    /// <summary>
    /// Alterna el estado de las luces (encendido/apagado).
    /// </summary>
    private void OnOffHandle()
    {
        lightsActive = !lightsActive;
        if (lightA != null) lightA.SetActive(lightsActive);
        if (lightB != null) lightB.SetActive(lightsActive);
    }
}
