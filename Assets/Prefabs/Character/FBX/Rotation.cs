using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float SpeedRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, SpeedRotation, 0);
    }
}