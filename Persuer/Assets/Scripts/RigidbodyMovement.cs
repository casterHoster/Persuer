using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _stepRayLower;
    [SerializeField] private GameObject _stepRayUpper;
    [SerializeField] private float stepSmooth;
    [SerializeField] private float _rayLowerLenght;
    [SerializeField] private float _rayUpperLenght;

    private Rigidbody _rigidbody;
    private Vector3 _playerShift;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        DefinePlayerShift();

        _rigidbody.velocity = _playerShift;
        //_rigidbody.velocity += Physics.gravity;
        //StepClimb();
        Debug.DrawRay(_stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), Color.red);
        Debug.DrawRay(_stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), Color.red);
    }

    private Vector3 DefinePlayerShift()
    {
        _playerShift = new Vector3(Input.GetAxis("Horizontal") * _speed, _rigidbody.velocity.y, Input.GetAxis("Vertical") * _speed);
        return _playerShift;
    }

    //private void StepClimb()
    //{
    //    if (Physics.Raycast(_stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitLower, _rayLowerLenght))
    //    {
    //        Debug.Log(hitLower);
    //        if (!Physics.Raycast(_stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitUpper, _rayUpperLenght))
    //        {
    //            _rigidbody.position += new Vector3(0, stepSmooth, 0);
    //        }
    //    }
    //}
}
