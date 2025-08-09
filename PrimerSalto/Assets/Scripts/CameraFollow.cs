using UnityEngine;

// Script para seguir al jugador con la c�mara en un juego 2D

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float offsetX = 2f; // Desplazamiento en el eje X de la c�mara respecto al jugador

    void LateUpdate()
    {
        Vector3 newPos = transform.position; // Obtener la posici�n actual de la c�mara
        newPos.x = player.position.x + offsetX; // Actualizar la posici�n X de la c�mara para que siga al jugador con un desplazamiento
        transform.position = newPos; // Asignar la nueva posici�n a la c�mara
    }
}
