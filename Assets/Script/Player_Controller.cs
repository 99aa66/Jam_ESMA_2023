using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public float speed = 5;
    
    [SerializeField]
    private float jumpForce = 5f;
    private Vector3 forceDirection = Vector3.zero;


    private Vector2 movementInput;
    private InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction move;
    


    // Start is called before the first frame update
    void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Gameplay");
    }
    private void OnEnable()
    {
        player.FindAction("Jump").started += DoJump;
        move = player.FindAction("Move");
        player.Enable();
    }
    private void OnDisable()
    {
        player.FindAction("Jump").started -= DoJump;
        move = player.FindAction("Move");
        player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }
    public void DoJump(InputAction.CallbackContext obj)
    {
        
        if (IsGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
        }
    }
    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.5f))
            return true;
        else
            return false;
    }
}
