using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject[] fireFps = new GameObject[10];
    public GameObject[] smougeFps = new GameObject[6];
    public GameObject[] fireSmallFps = new GameObject[12];
    public GameObject[] fireShirFps = new GameObject[12];
    public GameObject polotPlit;
    public GameObject fire;
    public GameObject fireSmall;
    public GameObject fireShir;
    public GameObject poloten;
    private game game;
    private phone phone;
    private timer timer;
    private bool flag;
    public void Polot()
    {
        poloten.SetActive(false);
        polotPlit.SetActive(true);
        fire.SetActive(false);
        fireSmall.SetActive(true);
        fireShir.SetActive(true);
    }
    private void Awake()
    {
        game = GetComponent<game>();
        phone = GetComponent<phone>();
        timer = GetComponent<timer>();
    }
    private void Start()
    {
        fireFps[0].SetActive(true);
        for (int i = 1; i < fireFps.Length; i++)
        {
            fireFps[i].SetActive(false);
        }
        for (int i = 0; i < smougeFps.Length; i++)
        {
            smougeFps[i].SetActive(false);
        }
        for (int i = 0; i < fireSmallFps.Length; i++)
        {
            fireSmallFps[i].SetActive(false);
        }
        for (int i = 0; i < fireShirFps.Length; i++)
        {
            fireShirFps[i].SetActive(false);
        }
        flag = false;
        poloten.SetActive(true);
        polotPlit.SetActive(false);
        fire.SetActive(true);
        fireSmall.SetActive(false);
        fireShir.SetActive(false);
    }
    private void Update()
    {
        if (timer.timerText.text == "1:20")
        {
            for (int i = 0; i < 4; i++)
            {
                smougeFps[i].SetActive(true);
            }
            StartCoroutine(SmougeFps());
        }
        else if (timer.timerText.text == "0:40")
        {
            for (int i = 4; i < 6; i++)
            {
                smougeFps[i].SetActive(true);
            }
        }
        if (polotPlit.activeSelf && flag == false)
        {
            flag = true;
            StartCoroutine(FireSmallandShirFps());
        }
    }
    IEnumerator FireSmallandShirFps()
    {
        int count = 1;
        while (timer.timerText.text != "0:00")
        {

            fireSmallFps[count - 1].SetActive(false);
            fireShirFps[count - 1].SetActive(false);
            fireSmallFps[count].SetActive(true);
            fireShirFps[count].SetActive(true);
            if (count == 11)
            {
                fireShirFps[count].SetActive(false);
                fireSmallFps[count].SetActive(false);
                fireSmallFps[0].SetActive(true);
                fireShirFps[0].SetActive(true);
                count = 0;
            }
            count++;
            yield return new WaitForSeconds(0.09f);
        }
        for (int i = 1; i < fireSmallFps.Length; i++)
        {
            fireSmallFps[i].SetActive(false);
        }
        for (int i = 1; i < fireShirFps.Length; i++)
        {
            fireShirFps[i].SetActive(false);
        }
        flag = false;
    }
    IEnumerator SmougeFps()
    {
        int flag = 1;
        while (timer.timerText.text != "0:00")
        {
            for (int i = 0; i < 20; i++)
            {
                smougeFps[0].transform.position = smougeFps[0].transform.position + new Vector3(0.05f*flag, 0, 0);
                smougeFps[1].transform.position = smougeFps[1].transform.position + new Vector3(-0.05f * flag, 0, 0);
                smougeFps[2].transform.position = smougeFps[2].transform.position + new Vector3(0.05f * flag, 0, 0);
                smougeFps[3].transform.position = smougeFps[3].transform.position + new Vector3(-0.05f * flag, 0, 0);
                smougeFps[4].transform.position = smougeFps[4].transform.position + new Vector3(0.05f * flag, 0, 0);
                smougeFps[5].transform.position = smougeFps[5].transform.position + new Vector3(-0.05f * flag, 0, 0);
                yield return new WaitForSeconds(0.1f);
            }
            flag*=-1;
        }
        for (int i = 0; i < smougeFps.Length; i++)
        {
            smougeFps[i].SetActive(false);
        }
    }
    public void FpsFire()
    {
        StartCoroutine(FireFps());
    }
    IEnumerator FireFps()
    {
        int count = 1;
        while (timer.timerText.text!="0:00")
        {

            fireFps[count - 1].SetActive(!fireFps[count-1].activeSelf);
            fireFps[count].SetActive(!fireFps[count].activeSelf);
            if (count==9)
            {
                fireFps[count].SetActive(!fireFps[count].activeSelf);
                fireFps[0].SetActive(true);
                count = 0;
            }
            count++;
            yield return new WaitForSeconds(0.09f);
        }
        fireFps[0].SetActive(true);
        for (int i = 1; i < fireFps.Length; i++)
        {
            fireFps[i].SetActive(false);
        }
    }
}
