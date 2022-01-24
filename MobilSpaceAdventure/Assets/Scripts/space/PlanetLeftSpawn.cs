using System.Collections.Generic;
using UnityEngine;

public class PlanetLeftSpawn : MonoBehaviour
{
    public List<GameObject> planetPrefabs = new List<GameObject>();

    private MyTimer timer;

    private int time;

    void Start()
    {
        timer = FindObjectOfType<MyTimer>();
        timer.TimerTick += Timer_TimerTick;
    }

    void Timer_TimerTick()
    {
        time++;
        if (time % 29 == 0)
        {
            var position_y = Random.Range(43, -133);
            var position_x = transform.position.x;
            var position_z = transform.position.z;
            Vector3 pos = new Vector3(position_x, position_y, position_z);
            GameObject spawnedPlanet = (GameObject)Instantiate(planetPrefabs[Random.Range(0, planetPrefabs.Count)], pos, Quaternion.identity);
        }
    }
}
