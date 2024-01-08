using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Task", menuName = "ScriptableObject/Task", order = 1)]
public class Task : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private float _duration;
    [SerializeField] private float _reward;
    [SerializeField] private Sprite _sprite;

    public int Id
    {
        get { return _id; }
        private set { _id = value; }
    }

    public float Duration 
    {
        get { return _duration; }
        private set { _duration = value; }
    }
    public float Reward
    {
        get { return _reward; }
        private set { _reward = value; }
    }
    public Sprite Sprite
    {
        get { return _sprite; }
        private set { _sprite = value; }
    }
}
