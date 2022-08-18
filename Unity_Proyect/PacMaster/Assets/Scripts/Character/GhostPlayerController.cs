using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.pacmaster.character
{
    public class GhostPlayerController : MonoBehaviour
    {
        [SerializeField]
        private CharacterController ghostController;

        [SerializeField]
        private Camera ghostCamera;

        [SerializeField]
        [Range(0f, 2f)]
        private float speed;

        [SerializeField]
        private GameObject cinemachineObject;

        [SerializeField]
        private List<string> cullingMask;

        private void Start()
        {
            if (!ghostController) Debug.LogWarning("No Ghost Character Controller found");
        }

        private void OnEnable()
        {
            cinemachineObject.SetActive(true);
            ghostCamera.cullingMask = LayerMask.GetMask(cullingMask.ToArray());
        }

        private void FixedUpdate()
        {
            Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

            if (inputDirection.magnitude >= 0.1f)
            {
                MoveCharacter(inputDirection);
            }
            ghostController.transform.eulerAngles = new Vector3(0f, ghostCamera.transform.eulerAngles.y, 0f);
        }

        private void MoveCharacter(Vector3 inputDirection)
        {
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + ghostCamera.transform.eulerAngles.y;
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            ghostController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}

