using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    Color32 c;
    Camera cm;
    // Start is called before the first frame update
    void Start()
    {
         
        c = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255),255);
        
        cm = GetComponent<Camera>();
        cm.backgroundColor = c;
    }

    
}
