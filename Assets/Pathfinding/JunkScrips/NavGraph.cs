using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavGraph : MonoBehaviour
{
    public GameObject Cube;
    public uint W = 40;
    public uint H = 40;
    public uint D = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (uint x = 0; x < W; ++x)
        {
            for(uint y = 0; y < H; ++y)
            {
                for (uint z = 0; z < D; ++z)
                {
                    if (x > 0 && x < W - 1 && y > 0 && y < H -1 && z > 0 && z < D -1)
                        continue;

                    Instantiate(Cube, new Vector3(x, y, z), Quaternion.identity);
                }

               
            }
        }
    }

  
}
