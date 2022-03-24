using UnityEngine;

public class MouseMove : MonoBehaviour
{

    [SerializeField] private float _mouseSensitivity = 100f;

    [SerializeField] private Transform _playerBody;
    private float _xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        MoveMouse();
    }
    private void MoveMouse()
    {
       float xRot = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
       float yRot = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= yRot;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        _playerBody.Rotate(Vector3.up * xRot);



    }
}
