using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : MonoBehaviour {
    public float SpeedModifier { get; set; }
    public float JumpModifier { get; set; }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
