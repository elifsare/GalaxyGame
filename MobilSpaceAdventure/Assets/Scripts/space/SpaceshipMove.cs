using System.Collections;
using UnityEngine;

public class SpaceshipMove : MonoBehaviour
{
    private readonly float speed = 0.7f;

    private float currentPos_x, currentPos_y, lastPos_x, lastPos_y;

    public int my_score = 0;

    private void Start()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        StartCoroutine((last_enumerator()));
    }

    IEnumerator last_enumerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            LastPos();
        }
    }

    void LastPos()
    {
        lastPos_x = transform.position.x;
        lastPos_y = transform.position.y;
    }

    void CurrentPos()
    {
        currentPos_x = transform.position.x;
        currentPos_y = transform.position.y;
    }

    void FixedUpdate()
    {
        JoystickControl();
        ShipRotation();
        LimitedArea();
    }

    public MyJoystick joystick;
    public GameObject pnl_gameover;

    private void JoystickControl()
    {
        if (!pnl_gameover.activeInHierarchy)
        {
            if (joystick.pressed)
            {
                float _x = joystick.Horizontal * 3;
                float _y = joystick.Vertical * 3;
                transform.position = new Vector3(transform.position.x + _x, transform.position.y + _y, transform.position.z);
            }
            
        }
    }

    float rot_x, rot_y;
    void ShipRotation()
    {
        currentPos_x = transform.position.x;

        if (Mathf.Abs(currentPos_x - lastPos_x) >= 1)
        {
            if (currentPos_x > lastPos_x)
            {
                rot_y = 10;
            }

            else if (currentPos_x < lastPos_x)
            {
                rot_y = -10;
            }

            else
            {
                rot_y = 0;
            }
        }
        else
        {
            rot_y = 0;
        }

        if (Mathf.Abs(currentPos_y - lastPos_y) >= 1)
        {
            currentPos_y = transform.position.y;
            if (currentPos_y > lastPos_y)
            {
                rot_x = -10;
            }

            else if (currentPos_y < lastPos_y)
            {
                rot_x = 10;
            }
            else
            {
                rot_x = 0;
            }
        }
        else
        {

            rot_x = 0;

        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rot_x, rot_y, 0), Time.deltaTime * speed);
    }

    void LimitedArea()
    {
        if (transform.position.x > 224)
        {
            transform.position = new Vector3(224, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -224)
        {
            transform.position = new Vector3(-224, transform.position.y, transform.position.z);
        }

        if (transform.position.y < -134)
        {
            transform.position = new Vector3(transform.position.x, -134, transform.position.z);
        }
        else if (transform.position.y > 134)
        {
            transform.position = new Vector3(transform.position.x, 134, transform.position.z);
        }
    }
}
