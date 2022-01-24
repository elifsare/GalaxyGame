using UnityEngine.UI;
using UnityEngine;

public class CoinScoreController : MonoBehaviour
{
    SpaceshipMove spaceship;

    HealtAndEndGame endgame;

    [SerializeField]
    private Text txt_score, txt_target_score;

    public int  min_time;
    public int target_score;

    MyTimer timer;

    private void Start()
    {
        spaceship = FindObjectOfType<SpaceshipMove>();
        endgame = FindObjectOfType<HealtAndEndGame>();
        timer = FindObjectOfType<MyTimer>();

        timer.TimerTick += Timer_TimerTick;
        min_time = Random.Range(40, 100);
        

        target_score = Random.Range(250, 850);
        txt_target_score.text = "Hedef: " + target_score.ToString();        
    }

    private void Update()
    {
        txt_score.text = "       X" + spaceship.my_score.ToString();
        if (timer.getTickCount() == min_time)
        {
            endgame.GameOver();
        }

        if (spaceship.my_score >= target_score)
        {
            endgame.LevelCompleted();
        }
    }

    [SerializeField]
    private Text txt_timer;

    void Timer_TimerTick()
    {
        int sure = min_time - timer.getTickCount();
        txt_timer.text = "Süre: " + sure.ToString();
    }
}
