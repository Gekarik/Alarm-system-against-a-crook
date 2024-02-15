using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Range(0f, 1f)] private float _speedVolumeChange = 0.15f;

    private float _minValue = 0f;
    private float _maxValue = 1f;
    private Coroutine _volumeChangeCoroutine;

    public void HandleIntruderDetected(bool inside)
    {
        if (_volumeChangeCoroutine != null)
            StopCoroutine(_volumeChangeCoroutine);

        _volumeChangeCoroutine = StartCoroutine(ChangeVolume(inside ? _maxValue : _minValue));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speedVolumeChange * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == 0)
            _audioSource.Stop();
    }
}
