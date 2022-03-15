using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private int stamina = 100;
    private int health = 100;
    private List<Animal> visibleAgentsList;
    [SerializeField]
    private float maxStepSize;
    [HideInInspector]
    public float StepSize;
    [SerializeField]
    private int staminaCost;

    //string to manage speed caps based on stamina levels
    private string speedBuffer = "max";

    [SerializeField]
    private List<Animal> predatorList;

    [SerializeField]
    private List<Animal> preyList;

    public HealthBarUI healthBarUI;


    // Start is called before the first frame update
    void Start()
    {
        visibleAgentsList = new List<Animal>();
        healthBarUI.UpdateSlider(health);
    }

    private void Update()
    {
        if (Random.Range(0, 100) == 0)
        {
            TakeDamage(5);
        }
    }

    private void SetStepSizeOnStaminaLevel()
    {
        if (stamina > 60 && !speedBuffer.Equals("max"))
        {
            StepSize = maxStepSize;
            speedBuffer = "max";
        }
        else if (stamina < 60 && !speedBuffer.Equals("60"))
        {
            StepSize = maxStepSize * 0.7f;
            speedBuffer = "60";
        }
        else if (stamina < 20 && !speedBuffer.Equals("20"))
        {
            StepSize = maxStepSize * 0.3f;
            speedBuffer = "20";
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            //dead
        }

        healthBarUI.UpdateSlider(health);
    }

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

            SetStepSizeOnStaminaLevel();
        }
    }

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;

            if (health < 0)
            {
                health = 0;
            }
            else if (health > 100)
            {
                health = 100;
            }
        }
    }

    public int StaminaCost
    {
        get
        {
            return staminaCost;
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
