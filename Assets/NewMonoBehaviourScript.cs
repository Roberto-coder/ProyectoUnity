using System;
using UnityEngine;

public class inputSe : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] float runSpeed = 15.0f; // Velocidad al correr
    [SerializeField] float jumpForce = 5.0f; // Fuerza de salto
    [SerializeField] float speedRot = 3.0f;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] AudioSource stepSound; // Audio de pasos

    CharacterController controller;
    Transform cameraTransform;
    private Animator anim;
    float xRotation = 0f;
    float verticalVelocity = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = GetComponentInChildren<Camera>().transform;
        anim = GetComponentInChildren<Animator>();

        // Verifica si hay un AudioSource en el objeto
        if (stepSound == null)
        {
            stepSound = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        Vector3 direction = Vector3.zero;

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        if (Input.GetKey(KeyCode.W)) direction += forward;
        if (Input.GetKey(KeyCode.S)) direction -= forward;
        if (Input.GetKey(KeyCode.D)) direction += right;
        if (Input.GetKey(KeyCode.A)) direction -= right;

        // Detectar si se está moviendo
        bool isMoving = direction.magnitude > 0f;
        bool isRunning = isMoving && Input.GetKey(KeyCode.LeftShift);

        // Aplicar velocidad normal o de carrera
        float currentSpeed = isRunning ? runSpeed : speed;
        direction *= currentSpeed;

        // Manejo de la gravedad y el salto
        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f; // Pequeño ajuste para mantener al personaje en el suelo

            if (Input.GetKeyDown(KeyCode.Space)) // Salto con Space
            {
                verticalVelocity = jumpForce;
                anim.SetTrigger("Jump");
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        direction.y = verticalVelocity;
        controller.Move(direction * Time.deltaTime);

        anim.SetBool("isWalking", isMoving);
        anim.SetBool("isRunning", isRunning);

        // Manejo del sonido de pasos
        if (stepSound != null)
        {
            if (isMoving && controller.isGrounded)
            {
                if (!stepSound.isPlaying)
                    stepSound.Play();
            }
            else
            {
                stepSound.Pause();
            }

            // Ajustar velocidad del sonido si se corre
            stepSound.pitch = Input.GetKey(KeyCode.LeftShift) ? 1.5f : 1.0f;
        }

        // Control de la cámara
        float mX = Input.GetAxis("Mouse X");
        float mY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mX * speedRot);

        xRotation -= mY * speedRot;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cameraTransform.localEulerAngles = new Vector3(xRotation, 0, 0);
    }
}
