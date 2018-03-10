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
<<<<<<< 01b0f20275bfcf6982742a2f90c00f6285219b04
            var player = collider.gameObject.GetComponent<PlayerController>();

            player.jumpModifier = this.JumpModifier;
            player.speedModifier = this.SpeedModifier;

=======
>>>>>>> Reconfigured Item pickup code
            Destroy(this.gameObject);

            pickedUp = true;

            var playerController = collider.gameObject.GetComponent<PlayerController>();
            playerController.currentItem = Instantiate(this);

            
        }
    }

}
