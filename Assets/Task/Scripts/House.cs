using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private IntruderDetector _intruderDetector;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        if (_intruderDetector != null)
            _intruderDetector.IntruderDetectionChanged += HandleIntruderDetected;
    }

    private void OnDisable()
    {
        if (_intruderDetector != null)
            _intruderDetector.IntruderDetectionChanged -= HandleIntruderDetected;
    }

    private void HandleIntruderDetected(bool inside)
    {
        if (_alarm != null)
            _alarm.HandleIntruderDetected(inside);
    }
}
