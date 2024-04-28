using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticBullet : Bullet
{
    private void Start()
    {
        Invoke("DestroyWhenTooLong", bulletLifetime);

    }




    public override void OnCollisionEnter(Collision collision)
    {

        base.OnCollisionEnter(collision);
        if (collision.gameObject.tag == "interactions")
        {
            SoundSystem.instance.PlaySound("BulletImpact");
            Destroy(gameObject);
        }

    }


}
