using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed = 5;

    Vector3 moveInput;
    float moveHorizontal;
    float moveVertical;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        moveInput = new Vector3(moveHorizontal, 0, moveVertical);
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        if (moveInput.magnitude > 0)
        {
            Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;

            _rb.MovePosition(_rb.position + movement * speed * Time.deltaTime);
        }
    }
}
