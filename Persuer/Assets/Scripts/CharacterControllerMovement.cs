using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private CharacterController _characterController;
    private Vector3 _playerShift;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if ( _characterController != null )
        {
            DefinePlayerShift();

            if (_characterController.isGrounded )
            {
                _characterController.Move(_playerShift + Vector3.down);
            }
            else
            {
                _characterController.Move(_characterController.velocity + Physics.gravity * Time.deltaTime);
            }
        }
    }

    private Vector3 DefinePlayerShift()
    {
        _playerShift = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _playerShift *= _speed * Time.deltaTime;
        return _playerShift;
    }
}