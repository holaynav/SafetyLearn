using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
public class game : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject staistikFon;
    public GameObject gazButton;
    public GameObject door;
    public GameObject doorPen;
    public GameObject levelOne;
    public GameObject handWindowOpen;
    public GameObject handWindowClose;
    public GameObject backFon;
    public GameObject panelFinelLevelOne;
    public GameObject BacKFonPFLO;

    public phone phone;
    public timer timer;
    private void Awake()
    {
        phone = GetComponent<phone>();
        timer = GetComponent<timer>();
    }

    private void Start()
    {

        staistikFon.SetActive(false);
        levelOne.SetActive(false);
    }
    private void Update()
    {
        if (levelOne.activeSelf==false)
        {
            LevelOneOff();
        }
    }
    public void LevelOneOff()
    {
        timer.timerZakon.SetActive(false);
        backFon.SetActive(false);
        phone.phoneSprite.SetActive(false);
        phone.backPhone.SetActive(false);
        phone.textnumberPhone.text = "";
        phone.numberIndex = -1;
        panelFinelLevelOne.SetActive(false);
        backFon.SetActive(false);
        gazButton.SetActive(true);
        door.SetActive(true);
        doorPen.SetActive(false);
        handWindowOpen.SetActive(true);
        handWindowClose.SetActive(false);
        timer.timerMinuts = 1;
        timer.timerSeconds = 59;
        timer.timerText.text = "2:00";
    }
    public void CloseWindow()
    {
        handWindowOpen.SetActive(false);
        handWindowClose.SetActive(true);
    }
    public void Restart()
    {
        LevelOneOff();
    }
    public void ButtonStatictick ()
    {
        staistikFon.SetActive(!staistikFon.activeSelf);
    }
    public void BackButtonStatictick()
    {
        staistikFon.SetActive(!staistikFon.activeSelf);
    }

    public void ButtonGaz()
    {
        gazButton.SetActive(!gazButton.activeSelf);
    }
    public void DoorOpenOrClose()
    {
        
        if (doorPen.activeSelf==true)
        {
            door.SetActive(!door.activeSelf);
            doorPen.SetActive(!doorPen.activeSelf);
        }
        else
        {
            door.SetActive(!door.activeSelf);
            doorPen.SetActive(!doorPen.activeSelf);
        }
    }

}
