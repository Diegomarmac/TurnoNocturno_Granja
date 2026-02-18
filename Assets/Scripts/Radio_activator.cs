using UnityEngine;

public class Radio_activator : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    
    private bool isTriggered = false;
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {   
            isTriggered = true;
            audioSource.Play();
        }
    }
    
}
