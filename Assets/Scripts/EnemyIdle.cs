using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIdle : MonoBehaviour
{
   
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Running", false);
    }

}
