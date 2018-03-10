using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicItem : MonoBehaviour {
    public float SpeedModifier { get; }
    public float JumpModifier { get; }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
