using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject shop_Window;

    public Button buyGifts_Button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenClose_Shop()
    {
        shop_Window.SetActive(!shop_Window.activeSelf);
    }

    public void Buy_Gifts()
    {
        if(GameManager.gameManager.coins >= 200)
        {
            GameManager.gameManager.Add_Coins(-200);
            GameManager.gameManager.Start_Gift_Spawn();

            buyGifts_Button.interactable = false;
        }
    }
}
