using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    public Image green_warning, red_warning, orange_warning;

    public GameObject warningPanel;

    private void Start()
    {
        green_warning.gameObject.SetActive(true);
        if (warningPanel == null)
        {
            warningPanel = GameObject.FindWithTag("FlashLight");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            warningPanel.SetActive(true);
            GameObject collison_asteroid = other.gameObject;
            float distance = Vector3.Distance(transform.position, collison_asteroid.transform.position);
            if (150 <= distance && distance < 350)
            {
                orange_warning.gameObject.SetActive(true);
                green_warning.gameObject.SetActive(false);
            }
            else if (distance < 150)
            {
                red_warning.gameObject.SetActive(true);
                orange_warning.gameObject.SetActive(false);
                green_warning.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        warningPanel.SetActive(false);
        green_warning.gameObject.SetActive(true);
        red_warning.gameObject.SetActive(false);
        orange_warning.gameObject.SetActive(false);
    }
}
