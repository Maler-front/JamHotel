using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestsSpawner : MonoBehaviour
{
    [SerializeField] private float _tickRate;
    [SerializeField] private float _tickCapasity;
    [SerializeField] private float _tickSpread;
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
                yield return Spawn();
                _remainingTicks = Random.Range((_tickCapasity - _tickSpread) * 1000, (_tickCapasity + _tickSpread) * 1000) / 1000;
            }
            yield return null;
        }
    }

    private IEnumerator Spawn()
    {
        Dictionary<PeopleConstructor.BodyPart, Sprite> sprites = PeopleConstructor.Instance.GetRandomGuestSprites();

        while (Reception.Instance.IsFull)
        {
            yield return null;
        }
        
        GameObject newGuest = Instantiate(_guestPrefab, transform.position, Quaternion.identity, null);
        newGuest.GetComponent<Guest>().SetBodyParts(sprites[PeopleConstructor.BodyPart.Head], sprites[PeopleConstructor.BodyPart.Body]);
        Reception.Instance.AddElement(newGuest.GetComponent<PointChasing>());
    }
}
