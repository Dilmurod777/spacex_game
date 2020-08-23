using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public static bool created;
    
    private void Awake()
    {
        if (!created)
        {
            created = true;
            
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }
    }
}
