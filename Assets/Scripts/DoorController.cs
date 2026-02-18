using UnityEngine;

public class DoorController : MonoBehaviour
{
  public enum ItemType
  {
    None,
    Door,
    Key,
  }
  
  [SerializeField] private ItemType _itemType = ItemType.None;
  
  private DoorInteractable doorInteractable;
  private KeyCollectable keyCollectable;
  
  
  private void Awake()
  {
    switch (_itemType)
    {
      case ItemType.Door: doorInteractable = GetComponent<DoorInteractable>(); break;
      case ItemType.Key: keyCollectable = GetComponent<KeyCollectable>(); break;
    }
    
  }

  public void ObjectInteract()
  {
    switch (_itemType)
        {
          case ItemType.Door: doorInteractable?.ToggleDoor(); break;
          case ItemType.Key: keyCollectable?.KeyPickUp(); break;
        }
  }
  
}
