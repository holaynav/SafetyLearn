using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] fireFps=new GameObject[11];
    private void Start()
    {
        fireFps[0].SetActive(true);
        for (int i = 1; i < fireFps.Length; i++)
        {
            fireFps[i].SetActive(false);
        }
    }
    public void FpsFire()
    {
        StartCoroutine(FireFps());
    }
    IEnumerator FireFps()
    {
        int count = 1;
        while (true)
        {

            fireFps[count - 1].SetActive(!fireFps[count-1].activeSelf);
            fireFps[count].SetActive(!fireFps[count].activeSelf);
            if (count==10)
            {
                fireFps[count].SetActive(!fireFps[count].activeSelf);
                fireFps[0].SetActive(true);
                count = 0;
            }
            count++;
            yield return new WaitForSeconds(0.09f);
        }
    }
}
