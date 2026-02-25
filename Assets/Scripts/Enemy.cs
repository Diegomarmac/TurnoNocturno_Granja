using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Controla el comportamiento del enemigo, persiguiendo al jugador y gestionando sus animaciones.
/// </summary>
public class Enemy : MonoBehaviour
{
    // Referencias a componentes internos y externos
    private FirstPersonController player;
    private NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
        // Obtiene los componentes necesarios del objeto enemigo
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        // Encuentra al jugador en la escena para poder perseguirlo
        player = FindFirstObjectByType<FirstPersonController>();
    }

    private void Update()
    {
        // Actualiza el destino del NavMeshAgent para que se dirija hacia la posición del jugador
        agent.SetDestination(player.transform.position);

        // Controla el parámetro "Running" del Animator basado en si el agente se está moviendo
        if (agent.velocity.magnitude != 0f)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }

    /// <summary>
    /// Se llama para procesar el movimiento basado en la animación (Root Motion).
    /// </summary>
    private void OnAnimatorMove()
    {
        // Si la animación de correr está activa, ajusta la velocidad del agente para coincidir con la animación
        if (animator.GetBool("Running"))
        {
            agent.speed = (animator.deltaPosition / Time.deltaTime).magnitude;
        }
    }
}
