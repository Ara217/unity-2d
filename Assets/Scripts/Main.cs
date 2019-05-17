using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [Header("Speeds")]
    public float WalkSpeed = 3;
    public float JumpForce = 5;

    private MoveState _moveState = MoveState.Idle;
    private DirectionState _directionState = DirectionState.Right;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Animator _animatorController;
    private float _walkTime = 0, _walkCooldown = 0.2f;

    public void MoveRight(float ax)
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            if (_directionState == DirectionState.Left)
            {
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
                _directionState = DirectionState.Right;
            }
            Vector3 diraaction = _transform.right * ax;

            _transform.position = Vector3.Lerp(_transform.position, _transform.position + diraaction, WalkSpeed * Time.deltaTime);
            _animatorController.Play("Walk");
        }
    }

    public void MoveLeft(float ax)
    {

        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            Debug.Log(_directionState);
            if (_directionState == DirectionState.Right)
            {
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
                _directionState = DirectionState.Left;
            }
            Vector3 diraaction = -_transform.right * ax;
            _transform.position = Vector3.Lerp(_transform.position, _transform.position - diraaction, WalkSpeed * Time.deltaTime);
            //_walkTime = _walkCooldown;
            _directionState = DirectionState.Left;
            _animatorController.Play("Walk");
        }
    }

    public void Jump()
    {
        if (_moveState != MoveState.Jump)
        {
            //_rigidbody.velocity = (Vector3.up * JumpForce * Time.deltaTime);
            _rigidbody.AddForce(_transform.up * JumpForce, ForceMode2D.Impulse);
            _moveState = MoveState.Jump;
            _animatorController.Play("Jump");
        }
    }

    public void Idle()
    {
        _moveState = MoveState.Idle;
        _animatorController.Play("Idle");
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animatorController = GetComponent<Animator>();
        _directionState = transform.localScale.x > 0 ? DirectionState.Right : DirectionState.Left;
    }



    private void Update()
    {

        if (_moveState == MoveState.Jump)
        {
            if (_rigidbody.velocity == Vector2.zero)
            {
                Idle();
            }
        }
    }

    enum DirectionState
    {
        Right,
        Left
    }

    enum MoveState
    {
        Idle,
        Walk,
        Jump
    }
}
