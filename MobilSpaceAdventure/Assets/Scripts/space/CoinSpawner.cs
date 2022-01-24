using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject coin_prefab;

    [SerializeField]
    private GameObject coins_parent;

    private static CoinSpawner SharedInstance;

    public List<GameObject> coin_pool = new List<GameObject>();

    private int coinAmountAtStart = 50;

    private GameObject spawn_coin;

    MyTimer timer;

    private void Awake()
    {
        SharedInstance = this;
        for (int i = 0; i < coinAmountAtStart; i++)
        {
            int x = Random.Range(-190, 190);
            int y = Random.Range(-100, 100);
            Vector3 coin_transform = new Vector3(x, y, 500);
            Quaternion coin_rotation = Quaternion.Euler(-90, transform.rotation.y, transform.rotation.z);

            spawn_coin = Instantiate(coin_prefab, coin_transform, coin_rotation, coins_parent.transform);
            spawn_coin.SetActive(false);
            coin_pool.Add(spawn_coin);
        }
    }

    void Start()
    {
        timer = FindObjectOfType<MyTimer>();
        timer.TimerTick += Timer_TimerTick;
    }


    private void Timer_TimerTick()
    {
        if (timer.getTickCount() % 2 == 0)
        {
            int i = Random.Range(0, coinAmountAtStart);
            coin_pool[i].SetActive(true);

            CoinDestroy();
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < coinAmountAtStart; i++)
        {
            if (!coin_pool[i].activeInHierarchy)
            {
                return coin_pool[i];
            }
        }
        return null;
    }

    public void CoinDestroy()
    {
        int x = Random.Range(-190, 190);
        int y = Random.Range(-100, 100);
        Vector3 new_position = new Vector3(x, y, 500);
        
        if (coin_pool.Count > 0)
        {
            for (int i = coin_pool.Count - 1; i >= 0; i--)
            {
                if (Camera.main.transform.position.z > coin_pool[i].transform.position.z)
                {
                    coin_pool[i].SetActive(false);
                    coin_pool[i].transform.position = new_position;
                }
            }
        }
    }
}
