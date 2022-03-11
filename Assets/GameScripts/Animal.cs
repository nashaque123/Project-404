using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private int stamina, health;
    private List<Animal> visibleAgentsList;

    [SerializeField]
    private List<Animal> predatorList;

    [SerializeField]
    private List<Animal> preyList;


    // Start is called before the first frame update
    void Start()
    {
        visibleAgentsList = new List<Animal>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //TODO: move to agent movement script
    /* void Move()
     {
         gameObject.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(-0.5f, 0.5f), gameObject.transform.position.y, gameObject.transform.position.z + Random.Range(-0.5f, 0.5f));
         //change position;
         //reduce stamina;
         //change state to rest when stamina is low

         //updateAction();
     }*/

    public int Stamina
    {
        get
        {
            return stamina;
        }

        set
        {
            stamina = value;

            if (stamina < 0)
            {
                stamina = 0;
            }
            else if (stamina > 100)
            {
                stamina = 100;
            }
        }
    }

    public List<Animal> VisibleAgentsList
    {
        get
        {
            return visibleAgentsList;
        }
    }

    public List<Animal> PredatorList
    {
        get
        {
            return predatorList;
        }
    }

    public List<Animal> PreyList
    {
        get
        {
            return preyList;
        }
    }
}
