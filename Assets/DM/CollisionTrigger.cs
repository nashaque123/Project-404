using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //other agent collides with bubble
    private void OnTriggerEnter(Collider other)
    {
        /*
         * check if agent is visible using line tracer/ ray cast
         * if other agent is visible {
         *      add agent to list
         *      call checkList()
         * }
         */
    }

    //other agent leaves bubble
    private void OnTriggerExit(Collider other)
    {
        /*
         * if agent is in list then remove
         * call checkList()
         */
    }
}
