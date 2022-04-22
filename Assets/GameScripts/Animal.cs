using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private float stamina = 100;
    private float health = 100;
    private List<Animal> visibleAgentsList = new List<Animal>();
    [SerializeField]
    private float maxStepSize;
    [HideInInspector]
    public float StepSize;
    [SerializeField]
    private float staminaCost;
    [SerializeField]
    private float attackRange;
    private List<GameObject> visibleHidingSpotList = new List<GameObject>();

    //string to manage speed caps based on stamina levels
    private string speedBuffer = "max";

    [SerializeField]
    private List<Animal> predatorList;

    [SerializeField]
    private List<Animal> preyList;

    public StatusBarUI healthBarUI;
    public StatusBarUI staminaBarUI;

    private void Start()
    {
        StepSize = maxStepSize;
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

    public float Stamina
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
            staminaBarUI.UpdateSlider(stamina);
        }
    }

    public float Health
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
                //dead
            }
            else if (health > 100)
            {
                health = 100;
            }

            healthBarUI.UpdateSlider(health);
        }
    }

    public float StaminaCost
    {
        get
        {
            return staminaCost;
        }
    }

    public float AttackRange
    {
        get
        {
            return attackRange;
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

    public List<GameObject> VisibleHidingSpotList
    {
        get
        {
            return visibleHidingSpotList;
        }
    }
}
