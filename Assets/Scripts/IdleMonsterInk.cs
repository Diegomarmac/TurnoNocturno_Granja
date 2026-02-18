using UnityEngine;

public class IdleMonsterInk : MonoBehaviour
{

    [SerializeField] private GameObject monster;
    [SerializeField] private float duration;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            monster.SetActive(true);

            Invoke(nameof(Desaparecer), duration);
        }
    }

    private void Desaparecer()
    {
        monster.SetActive(false);
    }

}
