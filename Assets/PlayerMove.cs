using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento
    public float lookSensitivity = 2f;  // Sensibilidad del mouse

    private float rotationX = 0f;  // Para rotar en el eje X (hacia arriba y abajo)
    private float rotationY = 0f;  // Para rotar en el eje Y (hacia los lados)

    void Start()
    {
        // Bloquea el cursor al centro de la pantalla
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        // Movimiento del mouse para rotar la cámara
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        rotationY += mouseX;  // Rotación alrededor del eje Y (horizontal)
        rotationX -= mouseY;  // Rotación alrededor del eje X (vertical)
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);  // Limita el ángulo vertical

        // Aplica la rotación a la cámara
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0f);

        // Movimiento con WASD
        float moveX = Input.GetAxis("Horizontal");  // A/D o flechas izquierda/derecha
        float moveZ = Input.GetAxis("Vertical");    // W/S o flechas arriba/abajo

        // Mueve la cámara en la dirección en que está apuntando
        Vector3 moveDirection = transform.forward * moveZ + transform.right * moveX;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
