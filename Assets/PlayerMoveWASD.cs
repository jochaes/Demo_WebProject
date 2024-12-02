using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveWASD : MonoBehaviour
{
    public float moveSpeed = 5f;      // Velocidad de movimiento
    public float lookSensitivity = 2f; // Sensibilidad del mouse

    private float rotationY = 0f;     // Para almacenar la rotaci�n en el eje Y (horizontal)

    void Start()
    {
        // Bloquear el cursor al centro de la pantalla
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        // Rotaci�n con el mouse solo en el eje Y (horizontal)
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        rotationY += mouseX;

        // Aplica la rotaci�n solo alrededor del eje Y
        transform.localEulerAngles = new Vector3(0f, rotationY, 0f);

        // Movimiento con WASD
        float moveX = Input.GetAxis("Horizontal");  // A/D o flechas izquierda/derecha
        float moveZ = Input.GetAxis("Vertical");    // W/S o flechas arriba/abajo

        // Mueve la c�mara en la direcci�n en que est� apuntando (solo en el plano XZ)
        Vector3 moveDirection = transform.forward * moveZ + transform.right * moveX;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
