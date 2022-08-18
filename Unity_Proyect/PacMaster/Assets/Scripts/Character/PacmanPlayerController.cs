using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.pacmaster.character
{
    public class PacmanPlayerController : MonoBehaviour
    {

        [SerializeField]
        private CharacterController pacmanController;
        
        [SerializeField]
        private Transform pacmanCamera;

        [SerializeField]
        [Range(0f, 2f)]
        private float speed;

        [SerializeField]
        [Range(0f, 0.2f)]
        private float turnSmoothTime;

        private float turnSmoothVelocity;

        [SerializeField]
        private GameObject cinemachineObject;




        private void Start()
        {
            if (!pacmanController) Debug.LogWarning("No Pacman Character Controller found");
        }

        private void OnEnable()
        {
            cinemachineObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

            if (inputDirection.magnitude >= 0.1f)
            {
                MoveCharacter(inputDirection);
            }
        }

        private void MoveCharacter(Vector3 inputDirection)
        {
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + pacmanCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(pacmanController.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            pacmanController.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            pacmanController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }


    }
}

