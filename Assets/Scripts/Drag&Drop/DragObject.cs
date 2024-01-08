using UnityEngine;
using UnityEngine.EventSystems;


public class DragObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool NeedToRespawn
    {
        get {return _needToRespawn;}
        set {_needToRespawn = value;}
    }

    public Transform DefaultPosition
    {
        get {return _defaultPosition;}
        set {_defaultPosition = value;}
    }

    private Collider2D _collider;
    private Rigidbody2D _rigidbody;
    private bool _needToRespawn = true;
    [SerializeField] protected bool _canBeDragged = true;
    [SerializeField] protected Transform _defaultPosition;

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

        if(TryGetComponent<PointChasing>(out PointChasing pointChasingComponent))
        {
            pointChasingComponent.OnChangeChasingState += (state) => { _canBeDragged = !state; };
        }
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (!_canBeDragged) return;

        _collider.enabled = false;
        _rigidbody.gravityScale = 0;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        if (!_canBeDragged) return;

        Vector3 newPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(newPosition.x,newPosition.y, 0);
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (!_canBeDragged) return;

        if(_needToRespawn)
        {
            Respawn();
        }
        _collider.enabled = true;
        _rigidbody.gravityScale = 1;
    }

    public void Respawn()
    {
        Debug.Log(_defaultPosition);
        transform.position = _defaultPosition.position;
        _needToRespawn = true;
    }

    private void OnDestroy()
    {
        if (TryGetComponent<PointChasing>(out PointChasing pointChasingComponent))
        {
            pointChasingComponent.OnChangeChasingState -= (state) => { _canBeDragged = !state; };
        }
    }
}
