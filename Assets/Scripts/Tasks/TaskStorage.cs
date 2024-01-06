using UnityEngine;

public class TaskStorage : MonoBehaviour
{
    public static TaskStorage Instance { get; private set; }

    [SerializeField] private Task[] _tasks;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("SingletonError");
            return;
        }
        Instance = this;
    }

    public Task GetTask(int id)
    {
        return _tasks[id];
    }

    public Task GetRandomTask()
    {
        return _tasks[Random.Range(0, _tasks.Length)];
    }
}
