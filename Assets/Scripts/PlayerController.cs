using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private InputAction _moveXAction;
    private InputAction _moveZAction;

    private float _currentXRotation;
    private float _currentZRotation;

    [FormerlySerializedAs("_rigidBody")][SerializeField] private Rigidbody rigidBody;
    [FormerlySerializedAs("_speed"), SerializeField] private float speed = 20.0f;
    [FormerlySerializedAs("_maxTilt"), SerializeField] private float maxTilt = 30.0f;

    private void Awake()
    {
        _moveXAction = new InputAction(type: InputActionType.Value);
        _moveXAction.AddCompositeBinding("Axis")
            .With("Negative", "<Keyboard>/w")
            .With("Positive", "<Keyboard>/s");
        
        _moveZAction = new InputAction(type: InputActionType.Value);
        _moveZAction.AddCompositeBinding("Axis")
            .With("Negative", "<Keyboard>/a")
            .With("Positive", "<Keyboard>/d");
    }

    private void OnEnable()
    {
        _moveXAction.Enable();
        _moveZAction.Enable();
    }

    private void OnDisable()
    {
        _moveXAction.Disable();
        _moveZAction.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (rigidBody == null) GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidBody.MoveRotation(Quaternion.Euler(_currentXRotation, 0, _currentZRotation));
    }

    // Update is called once per frame
    void Update()
    {
        var rotationX = _moveXAction.ReadValue<float>();
        var rotationZ = _moveZAction.ReadValue<float>();
        
        _currentXRotation += rotationX * speed * Time.deltaTime;
        _currentZRotation -= rotationZ * speed * Time.deltaTime;

        _currentXRotation = Mathf.Clamp(_currentXRotation, -maxTilt, maxTilt);
        _currentZRotation = Mathf.Clamp(_currentZRotation, -maxTilt, maxTilt);
    }
}
