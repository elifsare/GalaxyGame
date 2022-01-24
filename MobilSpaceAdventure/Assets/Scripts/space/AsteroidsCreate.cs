using System.Collections.Generic;
using UnityEngine;

public class AsteroidsCreate : MonoBehaviour
{
    public GameObject asteroidS, asteroidM, asteroidL, Spaceship, pool;
    private Transform _asteroidS, _asteroidM, _asteroidL, target_s, target_m, target_l;
    public GameObject asteroidParent;
    private List<Transform> objectsCreated = new List<Transform>();

    float distance;

    private MyTimer timer;
    int time;

    public enum asteroidSize
    {
        SMALL,
        MEDIUM,
        LARGE
    }

    private void Start()
    {
        timer = FindObjectOfType<MyTimer>();
        timer.TimerTick += Timer_TimerTick;
        distance = 500f;
    }

    private void Timer_TimerTick()
    {
        if (Spaceship == null)
        {
            Spaceship = GameObject.FindWithTag("Spaceship");
        }

        time++;
        if (time > 0)
        {
            spawn_S();
        }

        if (time > 60)
        {
            spawn_M();
        }

        if (time > 150)
        {
            spawn_L();
        }

        if (time % 5 == 0)
        {
            int rnd = Random.Range(0, 3);
            if (rnd == 0)
            {
                spawn_S(true);
            }
            if (rnd == 1)
            {
                spawn_M(true);
            }
            if (rnd == 2)
            {
                spawn_L(true);
            }
        }
    }

    void spawn_S(bool target_player = false)
    {
        var ship_pos = new Vector3(Spaceship.transform.position.x,
                                 Spaceship.transform.position.y,
                                 Spaceship.transform.position.z + distance);

        if (target_player == true)
        {
            target_s = Instantiate(gameObject.transform.Find("Asteroid_S"), ship_pos, Quaternion.identity);
            target_s.gameObject.SetActive(true);
            objectsCreated.Add(target_s);
            asteroidDestroy();
        }

        var x = Random.Range(-400, 400);
        var y = Random.Range(-200, 200);
        var pos = new Vector3(x, y, 600);
        _asteroidS = Instantiate(gameObject.transform.Find("Asteroid_S"), pos, Quaternion.identity);
        _asteroidS.gameObject.SetActive(true);
        objectsCreated.Add(_asteroidS);
        asteroidDestroy();
    }

    void spawn_M(bool target_player = false)
    {
        var ship_pos = new Vector3(Spaceship.transform.position.x,
                                 Spaceship.transform.position.y,
                                 Spaceship.transform.position.z + distance);

        if (target_player == true)
        {
            target_m = Instantiate(gameObject.transform.Find("Asteroid_M"), ship_pos, Quaternion.identity, asteroidParent.transform);
            target_m.gameObject.SetActive(true);
            objectsCreated.Add(target_m);
            asteroidDestroy();
        }

        var x = Random.Range(-200, 200);
        var y = Random.Range(-200, 200);
        var pos = new Vector3(x, y, 600);
        _asteroidM = Instantiate(gameObject.transform.Find("Asteroid_M"), pos, Quaternion.identity);
        _asteroidM.gameObject.SetActive(true);
        objectsCreated.Add(_asteroidM);
        asteroidDestroy();
    }

    public void spawn_L(bool targer_player = false)
    {
        var ship_pos = new Vector3(Spaceship.transform.position.x,
                                 Spaceship.transform.position.y,
                                 Spaceship.transform.position.z + distance);

        if (targer_player == true)
        {
            target_l = Instantiate(gameObject.transform.Find("Asteroid_L"), ship_pos, Quaternion.identity, asteroidParent.transform);
            target_l.gameObject.SetActive(true);
            objectsCreated.Add(target_l);
            asteroidDestroy();

        }

        var x = Random.Range(-200, 200);
        var y = Random.Range(-200, 200);
        var pos = new Vector3(x, y, 600);
        _asteroidL = Instantiate(gameObject.transform.Find("Asteroid_L"), pos, Quaternion.identity);
        _asteroidL.gameObject.SetActive(true);
        objectsCreated.Add(_asteroidL);
        asteroidDestroy();
    }

    public void spawnAsteroid(asteroidSize size)
    {
        if (size == asteroidSize.LARGE)
        {
            spawn_L();
        }

        else if (size == asteroidSize.MEDIUM)
        {
            spawn_M();
        }

        else if (size == asteroidSize.SMALL)
        {
            spawn_S();
        }
    }

    void asteroidDestroy()
    {
        if (objectsCreated.Count > 0)
        {
            for (int i = objectsCreated.Count - 1; i >= 0; i--)
            {
                if (Camera.main.transform.position.z > objectsCreated[i].transform.position.z)
                {
                    Transform gameObjectToRemove = objectsCreated[i];
                    Destroy(gameObjectToRemove.gameObject);
                    objectsCreated.RemoveAt(i);
                }
            }

        }

    }
}