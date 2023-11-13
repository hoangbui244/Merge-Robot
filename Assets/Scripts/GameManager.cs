using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject robot_Prefab, gift_Prefab;
    public GameObject newRobot_Window;

    public Image newRobot_Image;
    public TextMeshProUGUI newRobot_Name;

    public string[] robot_Name;
    public Sprite[] robot_Sprites, gear_Sprites;
    public Gear[] gearReward;
    public int coins, bought_Robots;
    public int highest_Tier;
   
    void Awake()
    {
        gameManager = this;
    }

    private void Start()
    {
        Spawn_Robot();

        Add_Coins(400);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy_Robot()
    {
        if(coins >= 5 * (bought_Robots + 1))
        {
            Add_Coins(-5 * (bought_Robots + 1));
            bought_Robots++;
            Spawn_Robot();
        }
    }

    public void Spawn_Robot()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * screenAspect;

        float minX = -cameraWidth / 2 + cameraWidth * 0.1f;
        float maxX = cameraWidth / 2 - cameraWidth * 0.1f;
        float minY = -cameraHeight / 2 + cameraHeight * 0.1f;
        float maxY = cameraHeight / 2 - cameraHeight * 0.1f;

        // Tính toán vị trí ngẫu nhiên trong phạm vi màn hình
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 position = new Vector3(randomX, randomY, 0);

        Instantiate(robot_Prefab, position, Quaternion.identity, null);
    }

    public void Spawn_Robot_At(Vector3 position)
    {
        Instantiate(robot_Prefab, position, Quaternion.identity, null);
    }

    public void Spawn_Gift()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * screenAspect;

        float minX = -cameraWidth / 2 + cameraWidth * 0.1f;
        float maxX = cameraWidth / 2 - cameraWidth * 0.1f;
        float minY = -cameraHeight / 2 + cameraHeight * 0.1f;
        float maxY = cameraHeight / 2 - cameraHeight * 0.1f;

        // Tính toán vị trí ngẫu nhiên trong phạm vi màn hình
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 position = new Vector3(randomX, randomY, 0);

        Instantiate(gift_Prefab, position, Quaternion.identity, null);
    }

    public void Start_Gift_Spawn()
    {
        float delay = 1f;
        float repeatRate = 8f;
        InvokeRepeating("Spawn_Gift", delay, repeatRate);
    }

    public void Check_Tier(int tier)
    {
        if(tier > highest_Tier)
        {
            highest_Tier = tier;

            StartCoroutine(New_Tier());
        }
    }

    public void Add_Coins(int amount)
    {
        coins += amount;

        Texts.texts.ChangeText_Coins(coins);
    }

    IEnumerator New_Tier()
    {
        newRobot_Window.SetActive(true);
        newRobot_Name.text = robot_Name[highest_Tier];
        newRobot_Image.sprite = robot_Sprites[highest_Tier];

        yield return new WaitForSeconds(2);
        newRobot_Window.SetActive(false);
    }
}
