﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BasicItem : MonoBehaviour
{
    public abstract float SpeedModifier
    {
        get;
    }

    public abstract float JumpModifier
    {
        get;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            var player = collider.gameObject.GetComponent<PlayerController>();

            player.jumpSpeed = this.JumpModifier;
            player.sideSpeed = this.SpeedModifier;

            Destroy(this.gameObject);
        }
    }

}
