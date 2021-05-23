using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scrolBar;
    public GameObject backMapButton;
    public GameObject panelGameOne;
    public GameObject map;
    private game game;
    private phone phone;
    void Start()
    {
        map.SetActive(false);
    }
    private void Awake()
    {
        game = GetComponent<game>();
        phone = GetComponent<phone>();
    }
    public void ButtonMap()
    {
        map.SetActive(!map.activeSelf);
    }
    public void ButtonOpenOneLevel()
    {
        game.levelOne.SetActive(!game.levelOne.activeSelf);
        panelGameOne.SetActive(false);
        backMapButton.SetActive(false);
    }
    public void PanelGameOneOpen()
    {
        panelGameOne.SetActive(true);
        backMapButton.SetActive(true);
    }
    public void PanelGameOneClose()
    {
        panelGameOne.SetActive(false);
        backMapButton.SetActive(false);
    }
    public void MouveScrolBarLeft()
    {
        StartCoroutine(MouveScrolLeft());
    }
    IEnumerator MouveScrolLeft()
    {
        for (int i = 0; i < 20; i++)
        {
            scrolBar.transform.position = scrolBar.transform.position + new Vector3(-0.3f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void MouveScrolBarRight()
    {
        StartCoroutine(MouveScrolRight());
    }
    IEnumerator MouveScrolRight()
    {
        for (int i = 0; i < 20; i++)
        {
            scrolBar.transform.position = scrolBar.transform.position + new Vector3(0.3f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
