using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerText;
    public GameObject timerZakon;
    public int timerSeconds;
    public int timerMinuts;
    private game game;
    private phone phone;
    private void Start()
    {
        timerMinuts = 1;
        timerSeconds = 60;
        timerText.text = "2:00";
    }
    private void Awake()
    {
        game = GetComponent<game>();
        phone = GetComponent<phone>();
    }
    public void Timer()
    {
        if (game.levelOne.activeSelf)
        {
            StartCoroutine(TimerforSeconds());
        }
    }
    IEnumerator TimerforSeconds()
    {
        for (int i = 0; i < 120; i++)
        {
            if (game.panelFinelLevelOne.activeSelf == false)
            {
                if (timerSeconds > 10)
                {
                    timerSeconds--;
                    timerText.text = timerMinuts + ":" + timerSeconds;
                    yield return new WaitForSeconds(0.01f);
                }
                else
                {
                    timerSeconds--;
                    timerText.text = timerMinuts + ":0" + timerSeconds;
                    if (timerSeconds == 0 && timerMinuts == 1)
                    {
                        timerSeconds = 60;
                        timerMinuts--;
                    }
                    if (timerSeconds == 0 && timerMinuts == 0)
                    {
                        if (game.panelFinelLevelOne.activeSelf == false)
                        {
                            timerZakon.SetActive(true);
                            game.backFon.SetActive(true);
                            break;
                        }
                        break;
                    }
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else break;
        }
    }


}
