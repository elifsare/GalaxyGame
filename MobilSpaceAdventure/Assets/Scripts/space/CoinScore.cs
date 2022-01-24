using UnityEngine;

public class CoinScore : MonoBehaviour
{
    private AudioManagment audio;

    private SpaceshipMove ship;

    void Start()
    {
        audio = FindObjectOfType<AudioManagment>();
        ship = FindObjectOfType<SpaceshipMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "coin_collison_controller")
        {
            gameObject.SetActive(false);
            ship.my_score += 50;
            audio.Coin();
            int x = Random.Range(-190, 190);
            int y = Random.Range(-100, 100);
            gameObject.transform.position = new Vector3(x, y, 500);
        }
    }
}
