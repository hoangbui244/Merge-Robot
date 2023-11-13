using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    private void OnMouseDown()
    {
        OpenGift();
    }

    public void OpenGift()
    {
        GameManager.gameManager.Spawn_Robot_At(transform.position);

        Destroy(gameObject);
    }
}
