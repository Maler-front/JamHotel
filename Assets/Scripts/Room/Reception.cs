using UnityEngine;

public class Reception : MonoBehaviour
{
    public static Reception Instance { get; private set; }

    [SerializeField] private Transform[] _queuePlaces;
     private PointChasing[] _queuedObjects;

    public int ObjectsNumber { get; private set; }
    public bool IsFull { get; private set; }

    private void Awake()
    {
        Instance = this;

        _queuedObjects = new PointChasing[_queuePlaces.Length];
    }

    public int GetObjectId(PointChasing findingObject)
    {
        for(int i = 0; i < ObjectsNumber; i++)
        {
            if(_queuedObjects[i] == findingObject)
            {
                return i;
            }
        }

        return -1;
    }

    public void RemoveElement(int id)
    {
        if(ObjectsNumber == 0) return;

        ObjectsNumber -= 1;
        _queuedObjects[id] = null;
        for(int i = id; i < ObjectsNumber; i++)
        {
            _queuedObjects[i] = _queuedObjects[i + 1];
            _queuedObjects[i].SetTarget(_queuePlaces[i]);
        }
        _queuedObjects[ObjectsNumber] = null;
    }

    public void AddElement(PointChasing newObject)
    {
        if(ObjectsNumber == _queuePlaces.Length) return;
        
        _queuedObjects[ObjectsNumber] = newObject;
        _queuedObjects[ObjectsNumber].SetTarget(_queuePlaces[ObjectsNumber]);
        ObjectsNumber += 1;

        IsFull = ObjectsNumber == _queuePlaces.Length ? true : false;
    }
}
