using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class MoveControle : MonoBehaviour
{
    [SerializeField] CharacterController _controller;
    [SerializeField, Range(1f, 500f)] float _speed = 12f;
    [SerializeField, Range(1f, 500f)] float _jumpHeight = 3f;
    [SerializeField] float _gravity = -20f;
    private Vector3 _velocity;

    void Update()
    {
        GravityForce();
        PlayerMove();
    }


    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.right * x + transform.forward * z) * _speed * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && _controller.isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }

        _controller.Move(moveDirection);
        
    }
    private void GravityForce()
    {
        if (_controller.isGrounded && _velocity.y <0f)
        {
            _velocity.y =-2f;  
        }
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
