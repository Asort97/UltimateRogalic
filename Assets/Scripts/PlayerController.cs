using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform playerBody;
    private InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        Vector2 movement = inputManager.GetPlayerMovement();
        Debug.Log(movement);
        Vector3 move = playerCamera.TransformDirection(new Vector3(movement.x, 0f, movement.y));
        transform.Translate(new Vector3(move.x, 0f, move.z) * speed * Time.deltaTime);
        playerBody.transform.eulerAngles = new Vector3(0f, playerCamera.eulerAngles.y, 0f);
    }
    // private void 
}
