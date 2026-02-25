using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Administra la visualización de textos o pistas en la UI basándose en temporizadores.
/// Controla cuándo aparece y desaparece un objeto de pista.
/// </summary>
public class textUIManager : MonoBehaviour
{
    [Header("Configuración de Tiempos")]
    [Tooltip("Tiempo en segundos a esperar antes de mostrar la pista.")]
    [SerializeField] float timeToWait;

    [Tooltip("Tiempo absoluto en segundos en el que la pista dejará de mostrarse (debe ser mayor que timeToWait).")]
    [SerializeField] float timeToRead;
    
    [Header("Referencias de UI")]
    [Tooltip("El objeto de juego que contiene la pista o texto a mostrar/ocultar.")]
    [SerializeField] GameObject HintObject;
    
    // Estado inicial del objeto de pista.
    bool isActive = false;
    
    // Temporizador interno para controlar los eventos.
    private float _timer = 0f;
    // Bandera para indicar si el ciclo de visualización ha terminado.
    private bool hasfinished = false;

    void Start()
    {
        // Inicializa el estado del objeto de pista (generalmente desactivado al inicio).
        HintObject.SetActive(isActive);
    }

    void Update()
    {
        // Si ya terminó el proceso de mostrar y ocultar, no hace nada.
        if (hasfinished) return;

        // Incrementa el temporizador con el tiempo transcurrido.
        _timer += Time.deltaTime;

        // Si ha pasado el tiempo de espera pero aún no se cumple el tiempo de lectura...
        if (_timer >= timeToWait && _timer < timeToRead)
        {
            // Activa el objeto de pista si no está activo.
            if(!HintObject.activeSelf) HintObject.SetActive(true);
        }

        // Si se ha alcanzado o superado el tiempo límite de lectura...
        if (_timer >= timeToRead)
        {
            // Oculta el objeto de pista.
            HintObject.SetActive(false);
            // Marca el proceso como finalizado para detener la actualización.
            hasfinished = true;
        }
    }
}
