
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class MazeScript : MonoBehaviour
{
    private InputAction _moveXAction;
    private InputAction _moveZAction;
    
    private float _currentXRotation;
    private float _currentZRotation;
    
    [FormerlySerializedAs("_speed")] [SerializeField]
    private float speed = 20.0f;
    
    [FormerlySerializedAs("_maxTilt")] [SerializeField]
    private float maxTilt = 30.0f;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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

    // Update is called once per frame
    void Update()
    {
        var moveX = _moveXAction.ReadValue<float>();
        var moveZ = _moveZAction.ReadValue<float>();
        
        _currentXRotation += moveX * speed * Time.deltaTime;
        _currentZRotation -= moveZ * speed * Time.deltaTime;
        
        _currentXRotation = Mathf.Clamp(_currentXRotation, -maxTilt, maxTilt);
        _currentZRotation = Mathf.Clamp(_currentZRotation, -maxTilt, maxTilt);

        transform.rotation = Quaternion.Euler(_currentXRotation, 0f, _currentZRotation);
    }
}
