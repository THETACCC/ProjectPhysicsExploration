using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] healthPoints;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.PlayerHealth == playerController.PlayerMaxHealth)
        {
            healthPoints[0].gameObject.SetActive(true);
            healthPoints[1].gameObject.SetActive(true);
            healthPoints[2].gameObject.SetActive(true);
            healthPoints[3].gameObject.SetActive(true);
        }
        else if (playerController.PlayerHealth == 75)
        {
            healthPoints[3].gameObject.SetActive(false);
        }
        else if (playerController.PlayerHealth == 50)
        {
            healthPoints[2].gameObject.SetActive(false);
        }
        else if (playerController.PlayerHealth == 25)
        {
            healthPoints[1].gameObject.SetActive(false);
        }
        else if (playerController.PlayerHealth == 0)
        {
            healthPoints[0].gameObject.SetActive(false);
        }
    }

    public void GetDamaged()
    {

    }

}
