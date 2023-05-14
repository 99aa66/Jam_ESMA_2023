using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    public float speed = 5f;
    public bool ready = false;

    [SerializeField]
    private float TurnSmoothTime = 0.1f;

    [SerializeField]
    private float TurnSmoothVelocity;


    public float rotationSpeed = 10f;

    [SerializeField]
    private float jumpForce = 5f;

    private Vector3 forceDirection = Vector3.zero;

    public bool isOnGround = true;

    private Vector2 movementInput;
    private InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction move;
    private Rigidbody rb;
    private Animator Anim;
    public Transform cam;
    public GameObject attack;


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
        //Debug.Log(movementInput.x);
        //Vector3 deplacement = new Vector3(movementInput.x, 0f, movementInput.y);
        //rb.velocity = deplacement * speed * Time.deltaTime;
        //transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);

        //if (movementInput.x == 0 && movementInput.y == 0)
        //{
        //    Anim.SetBool("Run", false);
        //}

        Vector3 direction = new Vector3(movementInput.x, 0f, movementInput.y).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TurnSmoothVelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //controller.Move(movDir.normalized * speed * Time.deltaTime);
            Debug.Log(movementInput);
            transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
        }

        //transform.Rotate(Vector3.up, movementInput.x * rotationSpeed * Time.deltaTime);

    }
    public void DoPush(InputAction.CallbackContext obj)
    {
        Anim.SetBool("Attaque", true);
        attack = GameObject.Find("Attack"); ;
        attack.GetComponent<BoxCollider>().enabled = true;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
        Anim.SetBool("Run", true);
    }
    public void Start(InputAction.CallbackContext obj)
    {
        ready = true;
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

        if (isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            Anim.SetBool("Jump", true);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            Anim.SetBool("Jump", false);
        }

    }
}
