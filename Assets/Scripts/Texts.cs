using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public static Texts texts;
    public TextMeshProUGUI coins_Text;

    private void Awake()
    {
        texts = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeText_Coins(int amount)
    {
        coins_Text.text = amount.ToString();
    }
}
