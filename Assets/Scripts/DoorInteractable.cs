using UnityEngine;

/// <summary>
/// Controla la lógica de interacción de una puerta, permitiendo abrirla y cerrarla
/// con una animación suave.
/// </summary>
public class DoorInteractable : MonoBehaviour
{
    [Header("Configuración de la Puerta")]
    [Tooltip("El punto de pivote sobre el cual rotará la puerta.")]
    [SerializeField] private Transform doorPivot;

    [Tooltip("Ángulo de rotación cuando la puerta está abierta.")]
    [SerializeField] private float openAngle = 90f;

    [Tooltip("Ángulo de rotación cuando la puerta está cerrada.")]
    [SerializeField] private float closeAngle = 0f;

    [Tooltip("Velocidad de la animación de apertura/cierre.")]
    [SerializeField] private float speed = 2f;

    [Header("Variables de Cierre")]
    [SerializeField] private bool isLocked = false;
    [SerializeField] private KeySO requiredKey;
    
    private bool isOpen = false;
    private bool isAnimating = false;
    private Quaternion targetRot;
    
    private AudioSource audioSource;
    
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;
    [SerializeField] private AudioClip LockedSound;

    private void Start()
    {
        targetRot = Quaternion.Euler(0f, closeAngle, 0f);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isAnimating)
        {
            doorPivot.localRotation = Quaternion.Lerp(doorPivot.localRotation, targetRot, speed * Time.deltaTime);

            if (Quaternion.Angle(doorPivot.localRotation, targetRot) < 0.1f)
            {
                doorPivot.localRotation = targetRot;
                isAnimating = false;
            }
        }
    }
    
    /// <summary>
    /// Alterna el estado de la puerta entre abierto y cerrado.
    /// Inicia la animación si no se está animando actualmente.
    /// </summary>
    public void ToggleDoor()
    {
        if (isLocked)
        {
            if (KeyInventory.Instance.HasKey(requiredKey))
            {
                //Debug.Log($"Puerta '{gameObject.name}' abierta con: {requiredKey.KeyName} ");

                isLocked = false;
            }
            else
            {
                //Debug.Log($"La puerta {gameObject.name} está cerrada, Necesitas la llave correcta: {requiredKey.KeyName}");
                PlaySound(LockedSound);
                
                return;
            }
        }
        
        if (!isAnimating)
        {
            isOpen = !isOpen;
            
            targetRot = Quaternion.Euler(0f, isOpen ? openAngle : closeAngle, 0f);
            
            isAnimating = true;
            
            PlaySound(isOpen ? openSound : closeSound);
        }
    }


    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
    
}
