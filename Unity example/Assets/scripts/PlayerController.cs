
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    private Vector3 playerInput;

    private CharacterController playerController;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float gravityMultiplier = 2.0f;
    private float fallVelocity;
    private const float terminalVelocity = -20f;
    [SerializeField] private float jumpForce = 10f;

    private Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;

    private bool isOnSlope = false;
    private Vector3 hitNormal;
    [SerializeField] private float slideVelocity = 5f;
    [SerializeField] private float slopeForceDown = 5f;

    [SerializeField] private float slopeSlideThreshold = 45f;  // Ángulo mínimo de pendiente para deslizarse
    [SerializeField] private float stepHeight = 0.3f;          // Altura máxima de los escalones que puede subir

    void Start()
    {
        playerController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleInput();
        CamDirection();

        // Calcula la dirección de movimiento
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        // Aplica gravedad o maneja el salto
        if (playerController.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            HandleJump();
        }
        else
        {
            ApplyGravity();
        }

        // Orienta al jugador hacia la dirección de movimiento
        if (movePlayer != Vector3.zero)
        {
            playerController.transform.forward = movePlayer;
        }

        // Aplica el movimiento, incluyendo la gravedad
        playerController.Move((movePlayer * playerSpeed + Vector3.up * fallVelocity) * Time.deltaTime);

        // Maneja el deslizamiento en pendientes
        SlideDown();
    }

    private void HandleInput()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        // Normaliza la entrada para evitar velocidad diagonal superior
        playerInput = Vector3.ClampMagnitude(new Vector3(horizontalMove, 0, verticalMove), 1);
    }

    private void CamDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        // Ignora la dirección vertical de la cámara
        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();
    }

    private void HandleJump()
    {
        if (Input.GetButton("Jump") && playerController.isGrounded)
        {
            fallVelocity = jumpForce;
        }
    }

    private void ApplyGravity()
    {
        // Aplica la gravedad multiplicada y acumula la velocidad de caída
        fallVelocity -= gravity * gravityMultiplier * Time.deltaTime;

        // Limita la velocidad de caída al valor de terminalVelocity
        if (fallVelocity < terminalVelocity)
        {
            fallVelocity = terminalVelocity;
        }
    }

    private void SlideDown()
    {
        // Calcula el ángulo de la superficie actual
        float slopeAngle = Vector3.Angle(Vector3.up, hitNormal);

        // Si el ángulo de la pendiente es mayor que el umbral de deslizamiento y no es un escalón, desliza
        if (slopeAngle > slopeSlideThreshold && !IsStep(hitNormal))
        {
            isOnSlope = true;
            // Desliza en la dirección de la pendiente
            Vector3 slideDirection = new Vector3(hitNormal.x, -hitNormal.y, hitNormal.z);
            playerController.Move(slideDirection * slideVelocity * Time.deltaTime);
            fallVelocity += slopeForceDown * Time.deltaTime;  // Aumenta la gravedad para acelerar el deslizamiento
        }
        else
        {
            isOnSlope = false;
        }
    }

    private bool IsStep(Vector3 normal)
    {
        // Ajusta la detección de escalones usando la altura máxima permitida
        float stepAngleLimit = Mathf.Cos(Mathf.Deg2Rad * slopeSlideThreshold);  // Ajusta el límite de ángulo para los escalones
        return normal.y > stepAngleLimit && normal.y > Mathf.Cos(Mathf.Deg2Rad * stepHeight);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Captura el normal de la colisión para calcular ángulos de pendiente
        hitNormal = hit.normal;
    }


  
}
