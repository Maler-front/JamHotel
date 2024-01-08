using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _speed;

    void Start()
    {
        _camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _camera.Translate(0, _speed * Time.fixedDeltaTime * Input.mouseScrollDelta.y, 0f);

        if (_camera.position.y < _minHeight)
        {
            _camera.position = new Vector3(_camera.position.x, _minHeight, _camera.position.z);
        }

        if (_camera.position.y > _maxHeight)
        {
            _camera.position = new Vector3(_camera.position.x, _maxHeight, _camera.position.z);
        }
    }
}
