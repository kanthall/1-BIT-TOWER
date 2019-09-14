using UnityEngine;
using UnityEngine.UI;

public class CrownsTrigger : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] public Text healthValue;

    public GameObject[] healthIndicator;
    
    private void Start()
    {
        health = healthIndicator.Length;
        healthValue.GetComponent<Text>().text = "" + health;
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            // 1
            if (value < health)
            {
                Camera.main.GetComponent<CameraShake>().Shake();
            }
            // 2
            health = value;
            healthValue.text = "HEALTH: " + health;
            // 3
            if (health <= 0)
            {
                //game over scene
            }
            // 4 
            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else
                {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        health -= 1;
    }
}

