using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private CharacterControllerMovement _characterMovement;
    [SerializeField] private float _distance;

    private Rigidbody _rigidbody;
    private Vector3 _playerShift;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveTowardsPlayer();
        _rigidbody.velocity = _playerShift;
    }

    private void MoveTowardsPlayer()
    {
        float distanceX = Mathf.Abs(_characterMovement.transform.position.x - _rigidbody.position.x);
        float distanceZ = Mathf.Abs(_characterMovement.transform.position.z - _rigidbody.position.z);

        if (distanceX > _distance || distanceZ > _distance)
            _rigidbody.position = Vector3.MoveTowards(_rigidbody.position, _characterMovement.transform.position, _speed);
    }
}
