using UnityEngine;
using UnityEngine.UI;

public class textUIManager : MonoBehaviour
{

    [SerializeField] float timeToWait;
    [SerializeField] float timeToRead;
    
    [SerializeField] GameObject HintObject;
    
    bool isActive = false;
    
    
    void Start()
    {
        HintObject.SetActive(isActive);
    }


    void Update()
    {
        if (Time.time > timeToWait)
        {
            isActive = true;
            HintObject.SetActive(isActive);
        }
        
        if (Time.time > timeToRead)
        {
            isActive = false;
            HintObject.SetActive(isActive);  
        }
    }
}
