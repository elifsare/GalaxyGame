using System.Collections.Generic;
using UnityEngine;

public class BulletManagment : MonoBehaviour
{
    public static BulletManagment SharedInstance;

    private List<GameObject> bullet_pool = new List<GameObject>();

    private int bulletAmountAtStart = 30;

    public GameObject bulletPrefab;
    public GameObject shipMuzzle, spawnBullet;

    public Transform bulletsParent;

    AudioManagment audio;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        shipMuzzle = GameObject.FindWithTag("ShipMuzzle");
        audio = FindObjectOfType<AudioManagment>();

        for (int i = 0; i < bulletAmountAtStart; i++)
        {
            spawnBullet = Instantiate(bulletPrefab, shipMuzzle.transform.position, Quaternion.identity, bulletsParent);
            spawnBullet.SetActive(false);
            bullet_pool.Add(spawnBullet);
        }
    }

    public void Fire()
    {
        GameObject go_bullet = BulletManagment.SharedInstance.GetPooledObject();
        if (go_bullet != null)
        {
            go_bullet.transform.position = shipMuzzle.transform.position;
            go_bullet.transform.rotation = shipMuzzle.transform.rotation;
            go_bullet.SetActive(true);

            audio.Bullet();
        }
    }

    public GameObject GetPooledObject() 
    {
        for (int i = 0; i < bulletAmountAtStart; i++)
        {
            if (!bullet_pool[i].activeInHierarchy)
            {
                return bullet_pool[i];
            }
        }
        return null;
    }
}