using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private AsteroidsMovement asteroid;

    private float my_speed;

    private void Start()
    {
        asteroid = FindObjectOfType<AsteroidsMovement>();
        my_speed = asteroid.speed ;
    }

    private void FixedUpdate()
    {
        transform.position -= Vector3.forward * my_speed * Time.deltaTime;
        transform.Rotate(0, 0, 3);
    }
}
