using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla el comportamiento de la linterna: encendido, apagado, consumo de batería y recarga.
/// </summary>
public class Flashlight : MonoBehaviour
{
    [Header("Configuración de Datos")]
    [Tooltip("ScriptableObject que contiene los datos de configuración de la linterna (batería, tiempos, etc.).")]
    [SerializeField] private FlashlightSO flashlightSO;
    
    [Header("Referencias de Objetos")]
    [Tooltip("El objeto GameObject que representa la luz de la linterna.")]
    [SerializeField] private GameObject flashlight;

    [Tooltip("Fuente de audio para el sonido de encendido/apagado.")]
    [SerializeField] private AudioSource turnOn;
    
    // Referencia a los inputs del jugador
    private StarterAssetsInputs inputs;

    // Estado actual de la linterna (encendida/apagada)
    private bool isOn = false;

    private void Awake()
    {
        inputs = GetComponentInParent<StarterAssetsInputs>();
        
        // Inicializa la batería al máximo al comenzar
        if (flashlightSO != null)
        {
            flashlightSO.tiempoEncendido = flashlightSO.maxTime;
        }
    }

    private void Start()
    {
        // Asegura que la linterna comience apagada
        if (flashlight != null)
        {
            flashlight.SetActive(false);
        }
    }

    private void Update()
    {
        ManualOnOff(); // Controlador manual del encendido y apagado
    
        if (isOn) 
        {
            // Si está encendida, resta tiempo de vida de la lámpara
            flashlightSO.tiempoEncendido -= Time.deltaTime;
        }
        
        // Si se acaba la vida de la lámpara, se apaga automáticamente
        if (flashlightSO.tiempoEncendido <= 0) 
        {
            // Solo intentamos apagarla si está encendida para evitar comportamientos erráticos
            if (isOn)
            {
                OnOffHandle();
            }

            flashlightSO.tiempoEncendido = 0f;
        }

        if (!isOn) 
        {
            // Se recarga la vida de la lámpara cuando está apagada
            flashlightSO.tiempoEncendido += flashlightSO.tiempoCarga * Time.deltaTime;
        }

        // No puede exceder el límite de carga
        if (flashlightSO.tiempoEncendido >= flashlightSO.maxTime) 
        {
            flashlightSO.tiempoEncendido = flashlightSO.maxTime; 
        }
    }

    /// <summary>
    /// Alterna el estado de la linterna (On/Off) y reproduce el sonido correspondiente.
    /// </summary>
    private void OnOffHandle()
    {
        isOn = !isOn;
        if (flashlight != null) flashlight.SetActive(isOn);
        if (turnOn != null) turnOn.Play();
        
        // Resetea el input para evitar múltiples activaciones
        if (inputs != null) inputs.luz = false;
    }

    /// <summary>
    /// Verifica la entrada del usuario para encender o apagar la linterna manualmente.
    /// </summary>
    private void ManualOnOff()
    {
        if (inputs != null && inputs.luz)
        {
            OnOffHandle();
        }
    }
}
