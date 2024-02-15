using System;
using UnityEngine;

public class IntruderDetector : MonoBehaviour
{
    public event Action<bool> IntruderDetectionChanged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IIntruder>() != null)
            IntruderDetectionChanged?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IIntruder>() != null)
            IntruderDetectionChanged?.Invoke(false);
    }
}