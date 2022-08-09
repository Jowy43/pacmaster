using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class packManController : MonoBehaviour
{
    public GameObject pacman;
    private float horizontalMove;
    private float verticalMove;
    private CharacterController pacManChCon;
    public float packManSpeed;
    private Vector3 playerInput;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;
    // Start is called before the first frame update
    void Start()
    {
        pacManChCon = pacman.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        camDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        pacManChCon.transform.LookAt(pacman.transform.position + movePlayer);
        pacManChCon.Move(movePlayer * packManSpeed * Time.deltaTime);


    }
    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}