using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class phone: MonoBehaviour
{
    public Text textnumberPhone;
    public int numberIndex;
    public game game;
    public GameObject phoneSprite;
    public GameObject backPhone;
    private void Awake()
    {
        game = GetComponent<game>();
    }
    private void Start()
    {
        numberIndex = -1;
        textnumberPhone.text = "";
    }
    
    public void OpenPhone()
    {
        phoneSprite.SetActive(true);
        backPhone.SetActive(true);
    }
    public void ClosePhone()
    {
        phoneSprite.SetActive(false);
        backPhone.SetActive(false);
    }
    public void AddText(string number)
    {
        numberIndex++;
        textnumberPhone.text += number;
    }
    public void NumberZero()
    {
        AddText("0");
    }
    public void NumberOne()
    {
        AddText("1");
    }
    public void NumberTwo()
    {
        AddText("2");
    }
    public void NumberThree()
    {
        AddText("3");
    }
    public void NumberFour()
    {
        AddText("4");
    }
    public void NumberFive()
    {
        AddText("5");
    }
    public void NumberSix()
    {
        AddText("6");
    }
    public void NumberSeven()
    {
        AddText("7");
    }
    public void NumberEight()
    {
        AddText("8");
    }
    public void NumberNine()
    {
        AddText("9");
    }
    public void NumberSharp()
    {
        AddText("#");
    }
    public void Clear()
    {
        textnumberPhone.text=textnumberPhone.text.Remove(numberIndex);
        numberIndex--;
    }


}
