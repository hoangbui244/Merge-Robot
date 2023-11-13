using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashRobot : MonoBehaviour
{
    public int tier, common_gear, rare_gear, epic_gear, legend_gear;

    bool isDragged, hasDestination;
    Vector3 destination, offset;
    public ParticleSystem evolve_Particles;
    public Gear gear;

    // Start is called before the first frame update
    void Start()
    {
        Set_WashRobot();

        InvokeRepeating("Take_Gear", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * screenAspect;

        float minX = -cameraWidth / 2 + cameraWidth * 0.1f;
        float maxX = cameraWidth / 2 - cameraWidth * 0.1f;
        float minY = -cameraHeight / 2 + cameraHeight * 0.1f;
        float maxY = cameraHeight / 2 - cameraHeight * 0.1f;

        if (!isDragged)
        {
            if (hasDestination)
            {
                if(Vector3.Distance(transform.position, destination) > .3f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, destination, 2 * Time.deltaTime);
                }
                else
                {
                    hasDestination = false;
                }
            }
            else
            {
                destination = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
                hasDestination = true;
            }
        }
    }

    public void Set_WashRobot()
    {
        GetComponent<SpriteRenderer>().sprite = GameManager.gameManager.robot_Sprites[tier];
      

        if (tier < 2) // Nếu tier là 1 hoặc 2
        {
            gear = GameManager.gameManager.gearReward[0];
            common_gear = 1;
            rare_gear = 0;
            epic_gear = 0;
            legend_gear = 0;
        }
        else if (tier == 2) // Nếu tier là 3
        {
            gear = GameManager.gameManager.gearReward[1];
            common_gear = 0;
            rare_gear = 1;
            epic_gear = 0;
            legend_gear = 0;
        }
        else if (tier == 3) // Nếu tier là 4
        {
            gear = GameManager.gameManager.gearReward[2];
            common_gear = 0;
            rare_gear = 0;
            epic_gear = 1;
            legend_gear = 0;
        }
        else if (tier == 4) // Nếu tier là 5
        {
            gear = GameManager.gameManager.gearReward[3];
            common_gear = 0;
            rare_gear = 0;
            epic_gear = 0;
            legend_gear = 1;
        }
    }

    public void Evolve()
    {
        evolve_Particles.Play();
        tier++;

        GameManager.gameManager.Check_Tier(tier);

        Set_WashRobot();
    }

    public void Take_Gear()
    {
        Gear new_Gear = Instantiate(gear, transform.position, Quaternion.identity, null);
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

    private void OnMouseDrag()
    {
        isDragged = true;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)) + offset;
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDragged)
        {
            if (collision.tag == "WashRobot")
            {
                if (collision.gameObject.activeSelf && collision.GetComponent<WashRobot>().tier == tier)
                {
                    Evolve();

                    Destroy(collision.gameObject);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isDragged)
        {
            if (collision.tag == "WashRobot")
            {
                if (collision.gameObject.activeSelf && collision.GetComponent<WashRobot>().tier == tier)
                {
                    Evolve();

                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
