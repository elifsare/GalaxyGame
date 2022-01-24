using UnityEngine;

public class AsteroidsScale : MonoBehaviour
{
    private int randomScale_X, randomScale_Y, randomScale_Z;

    void Start()
    {
        randomScale_X = Random.Range(35, 45);
        randomScale_Y = Random.Range(35, 45);
        randomScale_Z = Random.Range(35, 45);
        transform.localScale = new Vector3(randomScale_X, randomScale_Y, randomScale_Z);
    }
}
