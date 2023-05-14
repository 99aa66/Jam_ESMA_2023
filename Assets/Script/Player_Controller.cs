using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public float speed = 5;
    
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float TurnSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;


    private Vector2 movementInput;
    private InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction move;
    private Rigidbody rb;
    private Animator Anim;


    // Start is called before the first frame update
    void Awake()
    {
        inputAsset = this.GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Gameplay");
        rb = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        player.FindAction("Jump").started += DoJump;
        //player.FindAction("Push").started += DoPush;
        move = player.FindAction("Move");
        player.Enable();
    }
    private void OnDisable()
    {
        player.FindAction("Jump").started -= DoJump;
        //player.FindAction("Push").started += DoPush;
        move = player.FindAction("Move");
        player.Disable();
    }


    private void Update()
    {
        Debug.Log(movementInput.x);
        Vector3 deplacement = new Vector3(movementInput.x, 0f, movementInput.y);
        rb.velocity = deplacement * speed * Time.deltaTime;
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
        
        if (movementInput.x == 0 && movementInput.y == 0)
        {
            Anim.SetBool("Run", false);
        }
    }
    public void DoPush(InputAction.CallbackContext obj)
    {

    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
        Anim.SetBool("Run", true);
    }
    
    //private void TurnPlayer()
    //{
    //    if (movementDirection.sqrMagnitude > 0.01f)
    //    {

    //        Quaternion rotation = Quaternion.Slerp(rb.rotation,
    //                                             Quaternion.LookRotation(CameraDirection(movementDirection)),TurnSpeed);

    //        rb.MoveRotation(rotation);

    //    }
    //} 

    public void DoJump(InputAction.CallbackContext obj)
    {
        
        if (IsGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
            Anim.SetBool("Jump", true);
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
