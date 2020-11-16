using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private bool _inHouse;
    private float _directionIncreasingVolume = 0.01f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<WeapointMovement>(out WeapointMovement movement))
        {
            if(_inHouse == false)
            {
                _audioSource.Play();
                _inHouse = true;
            }
            else
            {
                _audioSource.Stop();
                _inHouse = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if(_audioSource.volume == 1)
        {
            _directionIncreasingVolume *= -1;
        }
        if(_audioSource.volume == 0)
        {
            _directionIncreasingVolume *= -1;
        }
        _audioSource.volume += Mathf.MoveTowards(_audioSource.volume, 1f, _directionIncreasingVolume);
    }
}
