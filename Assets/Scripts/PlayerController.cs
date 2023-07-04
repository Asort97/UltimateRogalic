using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform playerBody;
    private InputManager inputManager;

    [Inject]
    public void Construct(Camera playerCamera)
    {
        this.playerCamera = playerCamera;
    }
    private void Start()
    {
        inputManager = InputManager.Instance;
    }
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        Vector2 movement = inputManager.GetPlayerMovement();
        if(movement.x != 0f || movement.y != 0f)
        {
            Vector3 move = playerCamera.transform.TransformDirection(new Vector3(movement.x, 0f, movement.y));

            transform.Translate(new Vector3(move.x, 0f, move.z) * speed * Time.deltaTime);
            playerBody.transform.eulerAngles = new Vector3(0f, playerCamera.transform.eulerAngles.y, 0f);              
        }
    }
}
