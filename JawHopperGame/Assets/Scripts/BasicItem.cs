using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : MonoBehaviour
{
    public float SpeedModifier
    {
        get
        {
            return 0.0f;
        }
    }

    public float JumpModifier
    {
        get
        {
            return 0.0f;
        }
    }

    private bool pickedUp = false;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && pickedUp == false)
        {
            var player = collider.gameObject.GetComponent<PlayerController>();

            player.jumpModifier = this.JumpModifier;
            player.speedModifier = this.SpeedModifier;

            Destroy(this.gameObject);
        }
    }

}
