using UnityEngine;
using TMPro;

public class Creditos : MonoBehaviour
{
    [SerializeField] private float speed = 40f;

    private RectTransform _rectTransform;
    
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        _rectTransform.anchoredPosition += new Vector2(0,speed * Time.deltaTime);
    }
}
