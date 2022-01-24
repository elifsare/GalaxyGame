using UnityEngine;

public class AsteroidsMovement : MonoBehaviour
{
   public int speed;

    void Start()
    {
        speed = Random.Range(65, 100);
    }

    void Update()
    {
        transform.position -= Vector3.forward * speed * Time.deltaTime;
    }
}
