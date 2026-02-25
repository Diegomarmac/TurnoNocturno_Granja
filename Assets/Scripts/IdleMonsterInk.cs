using UnityEngine;

/// <summary>
/// Controla la aparición temporal de un monstruo "Idle" cuando el jugador entra en un trigger.
/// El monstruo aparece y luego desaparece después de un tiempo determinado.
/// </summary>
public class IdleMonsterInk : MonoBehaviour
{
    [Header("Configuración del Monstruo")]
    [Tooltip("El objeto GameObject que representa al monstruo que aparecerá.")]
    [SerializeField] private GameObject monster;

    [Tooltip("Duración en segundos que el monstruo permanecerá visible antes de desaparecer.")]
    [SerializeField] private float duration;

    // Bandera para asegurar que el evento solo ocurra una vez.
    private bool isTriggered = false;

    /// <summary>
    /// Detecta cuando el jugador entra en el área de activación.
    /// </summary>
    /// <param name="other">El collider que entró en el trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si es el jugador y si el evento no ha sido activado previamente
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            
            // Activa el monstruo
            if (monster != null)
            {
                monster.SetActive(true);
                // Programa la desaparición del monstruo después de 'duration' segundos
                Invoke(nameof(Desaparecer), duration);
            }
        }
    }

    /// <summary>
    /// Desactiva el objeto del monstruo.
    /// </summary>
    private void Desaparecer()
    {
        if (monster != null)
        {
            monster.SetActive(false);
        }
    }
}
