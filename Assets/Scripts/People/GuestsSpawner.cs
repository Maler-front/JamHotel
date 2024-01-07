using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestsSpawner : MonoBehaviour
{
    [SerializeField] private float _tickRate;
    [SerializeField] private float _tickCapasity;
    [SerializeField] private GameObject _guestPrefab;
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
        Dictionary<PeopleConstructor.BodyPart, Sprite> sprites = PeopleConstructor.Instance.GetRandomGuestSprites();
        Instantiate(_guestPrefab)
            .GetComponent<Guest>()
            .SetBodyParts(sprites[PeopleConstructor.BodyPart.Head], sprites[PeopleConstructor.BodyPart.Body]);
    }
}
