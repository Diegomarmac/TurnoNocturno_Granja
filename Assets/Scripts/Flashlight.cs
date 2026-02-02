using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;


public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    
    [SerializeField] AudioSource turnOn;

    StarterAssetsInputs inputs;

    bool isOn = false;


    private void Awake()
    {
        inputs = GetComponentInParent<StarterAssetsInputs>();
    }

    void Start()
    {
      
        flashlight.SetActive(false);
    }


    void Update()
    {
        if (inputs.luz)
        {
            isOn = !isOn;
            flashlight.SetActive(isOn);
            turnOn.Play();
            inputs.luz = false;

        }
    }
}
