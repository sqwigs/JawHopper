﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class JumpItem : BasicItem  {
    public override float SpeedModifier
    {
        get
        {
            return 1.0f;
        }
    }

    public override float JumpModifier {
        get
        {
            return 2.0f;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
