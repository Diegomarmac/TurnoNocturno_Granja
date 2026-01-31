using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private FirstPersonController player;
    
    NavMeshAgent agent;
    
    private Animator animator;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);

        if (agent.velocity.magnitude != 0f)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
    }
}
