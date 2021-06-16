using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
public class game : MonoBehaviour
{
    // Start is called before the first frame update
    bool flagBlic = true;
    public GameObject staistikFon;
    public GameObject gazButton;
    public GameObject door;
    public GameObject doorPen;
    public GameObject levelOne;
    public GameObject handWindowOpen;
    public GameObject handWindowClose;
    public GameObject backFon;
    public GameObject panelFinelLevelOne;
    public GameObject erorFon;
    public GameObject erorPanelBucket;
    public GameObject videoLection;
    public GameObject buttonSkipLection;
    public GameObject interFon;
    public GameObject panelPodscazok;
    public GameObject BeginPlayButton;
    public Text textPodscazok;
    public Text erorText;
    public int assessment=0;
    public GameObject[] blicKryg= new GameObject[6];
    int countBlicKryg;
    private Fire fire;
    private phone phone;
    private timer timer;
    private Map map;
    public bool stopCorout;
    public void OpenLection()
    {
        videoLection.SetActive(!videoLection.activeSelf);
        map.map.SetActive(!map.map.activeSelf);
        interFon.SetActive(!interFon.activeSelf);
        buttonSkipLection.SetActive(!buttonSkipLection.activeSelf);
        
    }

    private void Awake()
    {
        phone = GetComponent<phone>();
        timer = GetComponent<timer>();
        fire = GetComponent<Fire>();
        map = GetComponent<Map>();
    }

    private void Start()
    {
        videoLection.SetActive(false);
        buttonSkipLection.SetActive(false);
        erorPanelBucket.SetActive(false);
        erorFon.SetActive(false);
        staistikFon.SetActive(false);
        levelOne.SetActive(false);
        BeginPlayButton.SetActive(false);
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
        erorPanelBucket.SetActive(false);
        erorFon.SetActive(false);
        timer.timerZakon.SetActive(false);
        timer.bg.SetActive(false);
        fire.fire.SetActive(true);
        fire.fireSmall.SetActive(false);
        fire.fireShir.SetActive(false);
        fire.poloten.SetActive(true);
        fire.polotPlit.SetActive(false);
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
        timer.i = 120;
    }
    public void CloseWindow()
    {
        handWindowOpen.SetActive(false);
        handWindowClose.SetActive(true);
    }
    public void Bucket()
    {
        if (erorPanelBucket.activeSelf==false)
        {
            erorText.text = "Нельзя выливать на горящую плиту воду";
            StartCoroutine(BucketEror());
            stopCorout = true;
        }
    }
    public void BeginPlay()
    {
        BeginPlayButton.SetActive(false);
    }
    public void OpenPanelPodscaz()
    {
        panelPodscazok.SetActive(true);
        switch (countBlicKryg)
        {
            case 0:
                textPodscazok.text = "Это телефон, с его помощью вы можете вызвать пожарных";
                break;
            case 1:
                textPodscazok.text = "Это переключатель газа";
                blicKryg[0].SetActive(false);
                break;
            case 2:
                textPodscazok.text = "Это панель инструментов, вы можете их использовать просто нажав на них, тут есть как правильные, так и неправильные инструменты";
                blicKryg[1].SetActive(false);
                break;
            case 3:
                textPodscazok.text = "Это ручка двери, с ее помощью вы можете выйти из комнаты";
                blicKryg[2].SetActive(false);
                break;
            case 4:
                textPodscazok.text = "Это ручка окна, с ее помощью вы можете закрыть окно";
                blicKryg[3].SetActive(false);
                break;
            case 5:
                textPodscazok.text = "Вам нужно закончить в ограниченное время, по истечении времени уровень начнется заново";
                blicKryg[4].SetActive(false);
                break;
            case 6:
                panelPodscazok.SetActive(false);
                BeginPlayButton.SetActive(true);
                blicKryg[5].SetActive(false);
                break;
        }
    }
    public void CountBlick()
    {
        countBlicKryg++;
    }
    public void Blick()
    {
        StartCoroutine(BlickBang());
    }
    IEnumerator BlickBang()
    {
        while (flagBlic && countBlicKryg<=5)
        {
            blicKryg[countBlicKryg].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            blicKryg[countBlicKryg].SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void BucketOff()
    {
        stopCorout = false;
        erorPanelBucket.SetActive(false);
        timer.Timer();
    }

    IEnumerator BucketEror()
    {
        for (int i = 0; i < 2; i++)
        {
            erorFon.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            erorFon.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }
        if (assessment<2)
        {
            assessment++;
        }
        erorPanelBucket.SetActive(true);
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

        if (!gazButton.activeSelf && !handWindowOpen.activeSelf && fire.polotPlit)
        {
            if (doorPen.activeSelf == true)
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
        else
        {
            erorText.text = "Сначала попробуйте потушить пожар";
            StartCoroutine(BucketEror());
            stopCorout = true;
            if (assessment < 2)
            {
                assessment++;
            }
        }
    }

}
