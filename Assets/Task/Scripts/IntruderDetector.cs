using UnityEngine;

public class IntruderDetector : MonoBehaviour
{
    public delegate void IntruderDetected(bool inside);
    public event IntruderDetected OnIntruderDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IIntruder>() != null)
            OnIntruderDetected?.Invoke(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IIntruder>() != null)
            OnIntruderDetected?.Invoke(false);
    }
}
