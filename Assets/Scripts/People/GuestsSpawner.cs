using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestsSpawner : MonoBehaviour
{
    [SerializeField] private float _tickRate;
    [SerializeField] private float _tickCapasity;
    private float _remainingTicks;

    private void Awake()
    {
        _remainingTicks = _tickCapasity;
        StartCoroutine(SpawnOnTicks());
    }

    private IEnumerator SpawnOnTicks()
    {
        while (true)
        {
            _remainingTicks -= _tickRate * Time.fixedDeltaTime;
            
            if(_remainingTicks <= 0f)
            {
                Spawn();
                _remainingTicks = _tickCapasity;
            }
            yield return null;
        }
    }

    private void Spawn()
    {
        Dictionary<PeopleConstructor.BodyPart, Sprite> sprites = new Dictionary<PeopleConstructor.BodyPart, Sprite>();
        sprites = PeopleConstructor.Instance.GetRandomGuestSprites();
        Debug.Log($"I alive!!!!!!!!!\n{sprites[0]}");
    }
}
