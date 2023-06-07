using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crono : MonoBehaviour
{
    public static Crono Instance;

    public Text timerText;
    private float countdownTime = 90f;
    private bool isCountdownActive = false;
    private Coroutine countDownCoroutine;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameObject.SetActive(false);
        timerText.text = "00:00";
    }

    public void StartCountdown(float time)
    {
        countdownTime = time;
        gameObject.SetActive(true);
        isCountdownActive = true;
        SoundManager.Instance.PlayTicTacClip();
        countDownCoroutine = StartCoroutine(Countdown());
    }

    public void StopCountdown()
    {
        isCountdownActive = false;
        SoundManager.Instance.StopTicTacClip();
        StopCoroutine(countDownCoroutine);
    }

    private IEnumerator Countdown()
    {
        while(countdownTime > 0f)
        {
            if (isCountdownActive)
            {
                countdownTime -= Time.deltaTime;
                UpdateTimerDisplay(countdownTime);
            }
            yield return null;
        }
        SoundManager.Instance.StopTicTacClip();
        SoundManager.Instance.PlayAlarmClip();
        GameStateManager.Instance.GameOver();
    }

    private void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
