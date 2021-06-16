using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class ExitLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private game game;
    private phone phone;
    private timer timer;
    public Text textAssessment;
    public Text textStatAss;
    public Text textStatTime;
    private void Awake()
    {
        game = GetComponent<game>();
        phone = GetComponent<phone>();
        timer = GetComponent<timer>();
    }
    private void Start()
    {
        game.panelFinelLevelOne.SetActive(false);
        game.backFon.SetActive(false);
    }
    public void FinelLeveOne()
    {
        if (phone.textnumberPhone.text == "101")
        {
            textAssessment.text = "Ваша оценка: " + (5 - game.assessment).ToString();
            game.panelFinelLevelOne.SetActive(true);
            game.backFon.SetActive(true);
            textStatAss.text = (5 - game.assessment).ToString();
            textStatTime.text = timer.timerText.text;
        }
    }
    public void ExitLeveOne()
    {
        game.panelFinelLevelOne.SetActive(false);
        game.backFon.SetActive(false);
        game.levelOne.SetActive(false);
    }
}
