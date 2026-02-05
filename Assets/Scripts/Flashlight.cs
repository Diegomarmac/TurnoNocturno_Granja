using StarterAssets;
using UnityEngine;
using UnityEngine.UI;


public class Flashlight : MonoBehaviour
{
    [SerializeField] FlashlightSO flashlightSO;
    
    [SerializeField] GameObject flashlight;
    [SerializeField] AudioSource turnOn;
    
    StarterAssetsInputs inputs;

    bool isOn = false;


    private void Awake()
    {
        inputs = GetComponentInParent<StarterAssetsInputs>();
        flashlightSO.tiempoEncendido = flashlightSO.maxTime;
    }

    void Start()
    {
        flashlight.SetActive(false);
    }


    void Update()
    {
        ManualOnOff(); // controlador Manual del encendido y apagado
    
        if (isOn) // que en cuanto encienda, reste tiempo de vida de la lampara
        {
            flashlightSO.tiempoEncendido -= Time.deltaTime;
        }

        
        if (flashlightSO.tiempoEncendido <= 0) // se acaba la vida de la lampara y se apaga solita
        {
            OnOffHandle();

            flashlightSO.tiempoEncendido = 0f;
        }

        if (!isOn) // se recarga la vida de la lampara cuando esté apagada
        {
            flashlightSO.tiempoEncendido += flashlightSO.tiempoCarga * Time.deltaTime;
        }

        if (flashlightSO.tiempoEncendido >= flashlightSO.maxTime) flashlightSO.tiempoEncendido = flashlightSO.maxTime; // No puede exceder el limite de carga
    }

    private void OnOffHandle()
    {
        isOn = !isOn;
        flashlight.SetActive(isOn);
        turnOn.Play();
        inputs.luz = false;
    }

    private void ManualOnOff()
    {
        if (inputs.luz)
        {
            OnOffHandle();

        }
    }
}
