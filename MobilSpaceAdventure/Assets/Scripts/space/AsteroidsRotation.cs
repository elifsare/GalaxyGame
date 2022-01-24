using UnityEngine;

public class AsteroidsRotation : MonoBehaviour
{
    private int randomRot_x, randomRot_y, randomRot_z;
    private Vector3 rotationVector;

    void Start()
    {
        randomRot_x = Random.Range(0, 360);
        randomRot_y = Random.Range(0, 360);
        randomRot_z = Random.Range(0, 360);
    }
    
    void Update()
    {
        rotationVector = transform.rotation.eulerAngles;
        rotationVector = new Vector3(randomRot_x, randomRot_y, randomRot_z);
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
