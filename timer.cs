using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerText;
    public GameObject timerZakon;
    public GameObject bg;
    public int timerSeconds;
    public int timerMinuts;
    bool flag;
    public int i = 120;
    private game game;
    private phone phone;
    private void Start()
    {
        timerMinuts = 1;
        timerSeconds = 60;
        timerText.text = "2:00";
        bg.SetActive(false);
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
        for (; i>0 ; i--)
        {
            if (game.panelFinelLevelOne.activeSelf == false && !game.stopCorout)
            {
                if (timerSeconds > 10)
                {
                    timerSeconds--;
                    timerText.text = timerMinuts + ":" + timerSeconds;
                    yield return new WaitForSeconds(1f);
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
                            bg.SetActive(true);
                            break;
                        }
                        break;
                    }
                    yield return new WaitForSeconds(1f);
                }
            }
            else break;
        }
    }


}
