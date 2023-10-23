using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FallingLamp : FallingFurniture
{
    // Start is called before the first frame update
    [SerializeField] protected GameObject lightbulb;


    override protected void Fall()
    {
        base.Fall();
        lightbulb.SetActive(false);
    }
}
