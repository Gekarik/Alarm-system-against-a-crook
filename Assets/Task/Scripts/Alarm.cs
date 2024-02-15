using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _speedVolumeChange;
    [SerializeField] private AudioSource _audioSource;

    IntruderDetector _detector;
    private Coroutine _volumeChangeCoroutine;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private void Awake()
    {
        _detector = GetComponent<IntruderDetector>();
    }

    private void Start()
    {
        if (_detector != null)
            _detector.OnIntruderDetected += HandleIntruderDetected;
    }

    private void HandleIntruderDetected(bool inside)
    {
        if (_volumeChangeCoroutine != null)
            StopCoroutine(_volumeChangeCoroutine);

        if (_audioSource.isPlaying==false)
            _audioSource.Play();  

        _volumeChangeCoroutine = StartCoroutine(ChangeVolume(inside ? _maxVolume : _minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speedVolumeChange * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == 0)
            _audioSource.Stop();
    }
}
