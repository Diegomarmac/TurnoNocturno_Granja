using System;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    [SerializeField] private List<int> keyIds = new List<int>();
    
    public static KeyInventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //si creo más escenas, el inventario es persistente...
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddKey(KeySO key)
    {
        if (!keyIds.Contains(key.id))
        {
            keyIds.Add(key.id);
            Debug.Log($"Llave agregada: {key.KeyName}");
            UInventManager.Instance.AddKeyToUi(key);
        }
    }


    public bool HasKey(KeySO key)
    {
        return keyIds.Contains(key.id);
    }
    
    
}
