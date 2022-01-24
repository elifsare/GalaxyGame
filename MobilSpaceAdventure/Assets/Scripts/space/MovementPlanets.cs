using UnityEngine;

public class MovementPlanets : MonoBehaviour
{
    private float speed=10;

    void Update()
    {
        transform.position -= Vector3.forward * speed * Time.deltaTime;
        DestroyPlanets();
    }

    void DestroyPlanets()
    {
        if (Camera.main.transform.position.z > transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
