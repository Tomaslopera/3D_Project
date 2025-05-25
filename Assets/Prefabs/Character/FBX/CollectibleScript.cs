using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public float SpeedRotation = 100f;
    public GameObject onCollectEffect;

    void Update()
    {
        // Rotación en 3D: puedes ajustar los ejes según el efecto deseado
        transform.Rotate(0, SpeedRotation * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador
        if (other.GetComponent<PlayerController>() != null)
        {
            // Efecto de recogida
            if (onCollectEffect != null)
            {
                Instantiate(onCollectEffect, transform.position, transform.rotation);
            }

            // Destruye el objeto recogido
            Destroy(gameObject);
        }
    }
}

