using UnityEngine;

/// <summary>
/// ScriptableObject que almacena la configuración y el estado de la batería de la linterna.
/// Permite compartir datos de la linterna entre diferentes scripts o instancias.
/// </summary>
[CreateAssetMenu(fileName = "FlashlightSO", menuName = "Scriptable Objects/FlashlightSO")]
public class FlashlightSO : ScriptableObject
{
    [Header("Estado de la Batería")]
    [Tooltip("Tiempo actual restante de encendido en segundos.")]
    public float tiempoEncendido = 10f;

    [Header("Configuración de Rendimiento")]
    [Tooltip("Tiempo máximo de duración de la batería en segundos.")]
    public float maxTime = 10f;

    [Tooltip("Velocidad de recarga de la batería por segundo cuando la linterna está apagada.")]
    public float tiempoCarga = 1f;
}
