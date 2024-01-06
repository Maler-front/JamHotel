using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class DropArea : MonoBehaviour, IDropHandler
{
    private Collider2D _collider;

    private void Awake() 
    {
        if(!TryGetComponent<Collider2D>(out _collider))
        {
            Debug.LogWarning("No Collider2D Attached!");
        }
    }
    
    public abstract void OnDrop(PointerEventData eventData);
}
