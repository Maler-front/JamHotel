using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskSheet
{
    private List<Task> _tasks;

    public TaskSheet(int tasksCount)
    {
        _tasks = new List<Task>();
        for (int i = 0; i < tasksCount + 1; i++)
        {
            _tasks.Add(TaskStorage.Instance.GetRandomTask());
        }
    }

    public Task GetRandomTask()
    {
        int taskId = Random.Range(0, _tasks.Count);
        Task returningTask = _tasks[taskId];
        _tasks.RemoveAt(taskId);
        return returningTask;
    }

    public NumberOfTasks[] GetInfoForBubble()
    {
        List<NumberOfTasks> info = new List<NumberOfTasks>();
        for (int i = 0; i < _tasks.Count; i++)
        {
            bool isNew = true;
            for (int j = 0; j < info.Count; j++)
            {
                if (_tasks[i].Id == info[j].id)
                {
                    isNew = false;
                    info[j].count += 1;
                    break;
                }
            }

            if (isNew)
            {
                info.Add(new NumberOfTasks(_tasks[i].Id, _tasks[i].Sprite));
            }
        }

        return info.ToArray();
    }

    public class NumberOfTasks
    {
        public int id { get; private set; }
        public int count;
        public Sprite sprite;

        public NumberOfTasks(int id, Sprite sprite)
        {
            this.id = id;
            this.sprite = sprite;
            count = 1;
        }
    }
}
