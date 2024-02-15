using UnityEngine;

public class Mover : MonoBehaviour, IIntruder
{
    [SerializeField] private float _rotateSpeed = 15f;
    [SerializeField] private float _moveSpeed = 5f;

    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Move()
    {
        float _movement = Input.GetAxis(Vertical);

        transform.Translate(_movement * _moveSpeed * Time.deltaTime * Vector3.forward);
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);

        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime * Vector3.up);
    }
}