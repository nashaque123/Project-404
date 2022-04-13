using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{

    public LayerMask hitLayers;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) // if left click is pressed
        {
            Vector3 mouse = Input.mousePosition; // mouse position
            Ray castLocation = Camera.main.ScreenPointToRay(mouse); // cast a ray to the Location the mouse points to.
            RaycastHit hit; // storing the position where the ray hit
            if (Physics.Raycast(castLocation, out hit, Mathf.Infinity, hitLayers)) // checking that the raycast isnt hitting an obstruction
            {
                this.transform.position = hit.point; // move the target to the mouse location.
            }
        }
    }
}
