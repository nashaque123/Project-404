using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agents : MonoBehaviour
{

    public float posX;
    public float posY;
    public float velX;
    public float velY;

    public agents(float Posx, float Posy, float velx, float vely)
    {
        (posX, posY, velX, velY) = (Posx, Posy, velx, vely);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
