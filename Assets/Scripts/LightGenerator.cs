using System;
using UnityEngine;

public class LightGenerator : MonoBehaviour
{

    [SerializeField] FlashlightSO flashlightSO;
    [SerializeField] GameObject lightA;
    [SerializeField] GameObject lightB;
    //[SerializeField] GameObject lightsText;
    
    [SerializeField] AudioSource audioSource;
    
    bool lightsActive = false;

    private void Awake()
    {
        flashlightSO.tiempoEncendido = flashlightSO.maxTime;
    }

    void Start()
    {
        lightA.SetActive(false);
        lightB.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnOffHandle();
        }
    }

    private void Update()
    {
        if (lightsActive)
        {
            flashlightSO.tiempoEncendido -= Time.deltaTime;
        }
        
        if (flashlightSO.tiempoEncendido <= 0) // se acaba la vida de la lampara y se apaga solita
        {
            OnOffHandle();

            flashlightSO.tiempoEncendido = 0f;
        }

        if (!lightsActive) // se recarga la vida de la lampara cuando esté apagada
        {
            flashlightSO.tiempoEncendido += flashlightSO.tiempoCarga * Time.deltaTime;
        }

        if (flashlightSO.tiempoEncendido >= flashlightSO.maxTime) flashlightSO.tiempoEncendido = flashlightSO.maxTime; // No puede exceder el limite de carga
    }


    private void OnOffHandle()
    {
        lightsActive = !lightsActive;
        lightA.SetActive(lightsActive);
        lightB.SetActive(lightsActive);
        audioSource.Play();
    }

    
}
