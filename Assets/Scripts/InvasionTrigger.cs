using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvasionTrigger : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            _audioSource.volume = 0f;
            _audioSource.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float volumeSpeed = 7f;
        float volumeEndValue = 0.10f;
            
        _audioSource.volume = Mathf.PingPong(Time.time * volumeSpeed * Time.deltaTime, volumeEndValue);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            _audioSource.Stop();
        }
    }
}
