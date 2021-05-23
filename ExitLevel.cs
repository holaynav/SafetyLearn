using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private game game;
    private phone phone;
    private void Awake()
    {
        game = GetComponent<game>();
        phone = GetComponent<phone>();
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
            game.panelFinelLevelOne.SetActive(true);
            game.backFon.SetActive(true);
        }
    }
    public void ExitLeveOne()
    {
        game.panelFinelLevelOne.SetActive(false);
        game.backFon.SetActive(false);
        game.levelOne.SetActive(false);
    }
}
