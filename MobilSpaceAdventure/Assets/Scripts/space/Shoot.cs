using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float bulletForce = 30, bulletSpeed = 30;
    public GameObject particle_effects;
    private GameObject particle_clone;

    void Update()
    {
        transform.Translate(transform.forward * bulletForce * bulletSpeed * Time.deltaTime, Space.World);
        if (particle_effects == null)
        {
            particle_effects = GameObject.FindWithTag("ParticleSystem");
        }
    }

    private void OnEnable()
    {
        Invoke("EnabledFalse", 2f);
    }

    private void EnabledFalse() 
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroid")
        {
            OnEnable();
            OnDisable();
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            particle_clone = Instantiate(particle_effects, transform.position, Quaternion.identity);
            Destroy(particle_clone, 1f);
            AudioSource audio = Camera.main.GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
