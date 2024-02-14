using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Range(0f,1f)] private float _speedVolumeDif;

    private bool _isPlayerInside = false;

    private void Update()
    {
        ChangeAlarmVolume();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInside = true;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInside = false;
        }
    }

    private void ChangeAlarmVolume()
    {
        if (_isPlayerInside && _audioSource.volume < 1)
        {
            _audioSource.volume += _speedVolumeDif * Time.deltaTime;
        }
        else if (!_isPlayerInside && _audioSource.volume > 0)
        {
            _audioSource.volume -= _speedVolumeDif * Time.deltaTime;
        }
    }
}