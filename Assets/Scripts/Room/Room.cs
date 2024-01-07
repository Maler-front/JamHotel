using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class Room : DropArea
{
    [Header("Info")]
    [Space]
    [SerializeField] private int _cost;
    [SerializeField] private Employee _employee;
    [SerializeField] private Guest _guest;

    [Header("Task Specs")]
    [Space]
    [SerializeField] private Task _task;
    [SerializeField] private float _taskCooldown;
    [Range(1, 5)]
    [SerializeField] private float _randomness;
    private float _currentTaskCooldown = -10;

    [Header("UI")]
    [Space]
    [SerializeField] private TaskUI _taskPrefab;
    [SerializeField] private GameObject _holder;



    private void FixedUpdate() 
    {
        if(_currentTaskCooldown == -10) return;

        if(_currentTaskCooldown > 0)
        {
            _currentTaskCooldown -= Time.fixedDeltaTime;
        }else
        {
            // Debug.Log("Task");
            _currentTaskCooldown = -10;
            StartTask();
        }
    }

    public override void OnDrop(PointerEventData eventData)
    {
        // Debug.Log("Something Dropped!");

        if(_guest == null)
        {
            if(eventData.pointerDrag.TryGetComponent<Guest>(out _guest))
            {
                // Debug.Log("Get Tasks");
                (_guest as DragObject).NeedToRespawn = false;
                GetNextTask();
                Reception.Instance.RemoveElement(Reception.Instance.GetObjectId(_guest.GetComponent<PointChasing>()));
            }else
            {
                Debug.Log("Room Is Empty");
            }
        }else
        {
            if(eventData.pointerDrag.TryGetComponent<Employee>(out _employee) && _currentTaskCooldown == -10)
            {
                // Debug.Log("Start Work");
                (_employee as DragObject).NeedToRespawn = false;
                StartCoroutine(FinishTaskCo());
            }else
            {
                Debug.Log("Room Is Occupied");
            }
        }
    }

    private void GetNextTask()
    {
        _task = _guest.TaskSheet.GetRandomTask();
        _currentTaskCooldown = Random.Range(_taskCooldown - _randomness, _taskCooldown + _randomness); 
    }

    private void StartTask()
    {
        Instantiate(_taskPrefab, _holder.transform).UpdateUI(_task.Sprite, 1);
    }

    private IEnumerator FinishTaskCo()
    {
        yield return new WaitForSeconds(_task.Duration / _employee.Efficiency);

        foreach(Transform child in _holder.transform)
        {
            Destroy(child.gameObject);
        }

        (_employee as DragObject).Respawn();
        _employee = null;
        GetNextTask();
    }
}