using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody _rb;
    [SerializeField]
    private float playerSpeed = 5f;
    [SerializeField]
    private float _turnspeed = 360f;
    private Vector3 _input;

    private void Update()
    {
        GatherInput();
        Look();
        Move();
    }
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    void Move()
    {
        _rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * playerSpeed * Time.deltaTime);
    }
    void Look()
    {
        if (_input != Vector3.zero)
        {
            
            var relative = (transform.position + _input.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnspeed * Time.deltaTime);
        }
    }
}
