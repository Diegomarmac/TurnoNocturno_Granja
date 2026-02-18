using UnityEngine;

public class invokePersecutor : MonoBehaviour
{
 
    [SerializeField] private GameObject monster;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            monster.SetActive(true);
        }
    }
    
}
