
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

    [SerializeField] private float slopeSlideThreshold = 45f;  // �ngulo m�nimo de pendiente para deslizarse
    [SerializeField] private float stepHeight = 0.3f;          // Altura m�xima de los escalones que puede subir

    void Start()
    {
        playerController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        HandleInput();
        CamDirection();

        // Calcula la direcci�n de movimiento
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

        // Orienta al jugador hacia la direcci�n de movimiento
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

        // Ignora la direcci�n vertical de la c�mara
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
        // Aplica la gravedad multiplicada y acumula la velocidad de ca�da
        fallVelocity -= gravity * gravityMultiplier * Time.deltaTime;

        // Limita la velocidad de ca�da al valor de terminalVelocity
        if (fallVelocity < terminalVelocity)
        {
            fallVelocity = terminalVelocity;
        }
    }

    private void SlideDown()
    {
        // Calcula el �ngulo de la superficie actual
        float slopeAngle = Vector3.Angle(Vector3.up, hitNormal);

        // Si el �ngulo de la pendiente es mayor que el umbral de deslizamiento y no es un escal�n, desliza
        if (slopeAngle > slopeSlideThreshold && !IsStep(hitNormal))
        {
            isOnSlope = true;
            // Desliza en la direcci�n de la pendiente
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
        // Ajusta la detecci�n de escalones usando la altura m�xima permitida
        float stepAngleLimit = Mathf.Cos(Mathf.Deg2Rad * slopeSlideThreshold);  // Ajusta el l�mite de �ngulo para los escalones
        return normal.y > stepAngleLimit && normal.y > Mathf.Cos(Mathf.Deg2Rad * stepHeight);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Captura el normal de la colisi�n para calcular �ngulos de pendiente
        hitNormal = hit.normal;
    }


  
}
