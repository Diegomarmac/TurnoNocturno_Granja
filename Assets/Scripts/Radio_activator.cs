using UnityEngine;

public class Radio_activator : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
        }
    }
    
}
