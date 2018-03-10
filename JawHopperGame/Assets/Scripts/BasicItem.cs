using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : MonoBehaviour {
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

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            var player = collider.gameObject.GetComponent<PlayerController>();
            player.currentItem = Instantiate(this);

            Destroy(this.gameObject);
        }
    }

}
