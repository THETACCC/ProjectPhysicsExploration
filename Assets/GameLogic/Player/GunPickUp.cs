using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public GameObject PlayerGun;
    public GameObject PlayerUI;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerGun.SetActive(true);
            PlayerUI.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
