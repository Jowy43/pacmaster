using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class packManController : MonoBehaviour
{
    public GameObject pacman;
    private float horizontalMove;
    private float verticalMove;
    public CharacterController pacManChCon;
    public float packManSpeed;
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
    }

    private void FixedUpdate()
    {
        Vector3 move = pacman.transform.right * horizontalMove + pacman.transform.forward * verticalMove;
        pacManChCon.Move(move * packManSpeed * Time.deltaTime);
    }
}
