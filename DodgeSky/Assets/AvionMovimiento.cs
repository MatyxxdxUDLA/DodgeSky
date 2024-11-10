using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AvionMovimiento : MonoBehaviour
{
    public float maxSpeed;
    public float rotSpeed;
    void Start()
    {

    }
    void FixedUpdate()
    {
        //Rotacion
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0,0,z);
        transform.rotation = rot;

        //Movimiento
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;

        transform.position = pos;

    }
}
