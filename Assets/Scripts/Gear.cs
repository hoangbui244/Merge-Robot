using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public int tier;

    // Start is called before the first frame update
    void Start()
    {
        Set_Gear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Gear()
    {
        //GetComponent<SpriteRenderer>().sprite = GameManager.gameManager.gear_Sprites[tier];

        StartCoroutine(Dissapear());
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(1);

        GameManager.gameManager.Add_Coins((int)Mathf.Pow(3, tier)); 

        Destroy(gameObject);
    }
}
