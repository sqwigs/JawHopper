using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : BasicItem  {
    public override float SpeedModifier
    {
        get
        {
            return -5.0f;
        }
    }

    public override float JumpModifier {
        get
        {
            return 0.0f;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
