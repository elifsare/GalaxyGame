using UnityEngine;
using UnityEngine.UI;

public class HealtAndEndGame : MonoBehaviour
{
    public float health;

    private int hasar_s, hasar_m, hasar_l;

    public Slider healthBar;

    public GameObject particle_effects;
    public GameObject gameOverPanel,
                      healthbar,
                      temel,
                      pnl_joystick,
                      btn_menu,
                      score, sure, img_target;
                      
    public Text win_status, endgame_txt_score;

    private Warning warning;

    public CoinScoreController scoreController;

    private MyTimer timer;

    private void Start()
    {
        warning = FindObjectOfType<Warning>();
        timer = FindObjectOfType<MyTimer>();
        scoreController = FindObjectOfType<CoinScoreController>();

        health = 100;

        hasar_s = 5;
        hasar_m = 10;
        hasar_l = 20;
    }

    private void Update()
    {
        healthBar.value = health;
        if (particle_effects == null)
        {
            particle_effects = GameObject.FindWithTag("ParticleSystem");
        }

        if(health <= 0 )
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource audio = Camera.main.GetComponent<AudioSource>();

        if (collision.gameObject.name == "Asteroid_S(Clone)")
        {
            health -= hasar_s;
            GameObject particle = Instantiate(particle_effects, transform.position, Quaternion.identity);
            audio.Play();
            collision.other.gameObject.SetActive(false);
            warning.warningPanel.SetActive(false);
            Destroy(particle, 1f);
        }

        if (collision.gameObject.name == "Asteroid_M(Clone)")
        {
            health -= hasar_m;
            healthBar.value = health;
            GameObject particle = Instantiate(particle_effects, transform.position, Quaternion.identity);
            audio.Play();
            collision.other.gameObject.SetActive(false);
            warning.warningPanel.SetActive(false);
            Destroy(particle, 1f);

        }

        if (collision.gameObject.name == "Asteroid_L(Clone)")
        {
            health -= hasar_l;
            healthBar.value = health;
            GameObject particle = Instantiate(particle_effects, transform.position, Quaternion.identity);
            audio.Play();
            collision.other.gameObject.SetActive(false);
            warning.warningPanel.SetActive(false);
            Destroy(particle, 1f);
        }
    }

    public void LevelCompleted()
    {
        Time.timeScale = 0;
        win_status.text = "KAZANDINIZ!";
        gameOverPanel.SetActive(true);
        healthbar.SetActive(false);
        healthbar.SetActive(false);
        temel.SetActive(false);
        pnl_joystick.SetActive(false);
        btn_menu.SetActive(false);
        score.SetActive(false);
        sure.SetActive(false);
        img_target.SetActive(false);
        endgame_txt_score.text = "X" + FindObjectOfType<SpaceshipMove>().my_score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        win_status.text = "KAYBETTİNİZ";
        gameOverPanel.SetActive(true);
        healthbar.SetActive(false);
        temel.SetActive(false);
        pnl_joystick.SetActive(false);
        btn_menu.SetActive(false);
        score.SetActive(false);
        sure.SetActive(false);
        img_target.SetActive(false);
        endgame_txt_score.text = "X" + FindObjectOfType<SpaceshipMove>().my_score.ToString();
    }
}
