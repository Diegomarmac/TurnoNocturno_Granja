using UnityEngine;

[CreateAssetMenu(fileName = "FlashlightSO", menuName = "Scriptable Objects/FlashlightSO")]
public class FlashlightSO : ScriptableObject
{
    public float tiempoEncendido = 10f;
    public float maxTime = 10f;
    public float tiempoCarga = 1f;
}
