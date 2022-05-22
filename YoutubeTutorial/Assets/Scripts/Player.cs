using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private bool _jumpKeyWasPressed;
    private float _horizontalInput;
    private Rigidbody _rigidbody;
    private float _jumpSpeed;
    private float _moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _jumpSpeed = 5.0f;
        _moveSpeed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpKeyWasPressed = true;
        }

        _horizontalInput = Input.GetAxis("Horizontal");
    }
    
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_horizontalInput * _moveSpeed, _rigidbody.velocity.y, 0);
        
        if (_jumpKeyWasPressed && Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0)
        {
            _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.VelocityChange);
            _jumpKeyWasPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            _jumpSpeed += 0.5f;
            ScoreManager.instance.UpdateJumpText();
        }
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            _moveSpeed += 0.2f;
            ScoreManager.instance.UpdateMoveText();
        }
    }
}
