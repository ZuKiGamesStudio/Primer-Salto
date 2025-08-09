using UnityEngine;

// Script para seguir al jugador con la cámara en un juego 2D

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float offsetX = 2f; // Desplazamiento en el eje X de la cámara respecto al jugador

    void LateUpdate()
    {
        Vector3 newPos = transform.position; // Obtener la posición actual de la cámara
        newPos.x = player.position.x + offsetX; // Actualizar la posición X de la cámara para que siga al jugador con un desplazamiento
        transform.position = newPos; // Asignar la nueva posición a la cámara
    }
}
