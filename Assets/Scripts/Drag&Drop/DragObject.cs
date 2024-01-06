using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragObject : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool NeedToRespawn
    {
        get {return _needToRespawn;}
        set {_needToRespawn = value;}
    }

    private Collider2D _collider;
    private Rigidbody2D _rigidbody;
    private bool _needToRespawn = true;
    [SerializeField] private Transform _defaultPosition;

    private void Awake() 
    {
        if(!TryGetComponent<Collider2D>(out _collider))
        {
            Debug.LogWarning("No Collider2D Attached!");
        }
        if(!TryGetComponent<Rigidbody2D>(out _rigidbody))
        {
            Debug.LogWarning("No Rigidbody2D Attached!");
        }
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _collider.enabled = false;
        _rigidbody.gravityScale = 0;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(newPosition.x,newPosition.y, 0);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End");
        if(_needToRespawn)
        {
            Respawn();
        }
        _collider.enabled = true;
        _rigidbody.gravityScale = 1;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("Down!");
        
    }

    public void OnPointerUp(PointerEventData data)
    {
        // Debug.Log("Release!");
    }

    public void Respawn()
    {
        transform.position = _defaultPosition.position;
        _needToRespawn = true;
    }

}
