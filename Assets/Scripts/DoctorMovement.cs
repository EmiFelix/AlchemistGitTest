using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoctorMovement : Character
{
    // Flask

    public GameObject flask;

    [SerializeField] private Transform flaskSpawn;
    [SerializeField] private KeyCode ability1;

    [SerializeField] private int flaskCooldown;
    [SerializeField] private int nextFlask;


    // Raycast look at Boss

    [SerializeField] private Transform eyesTransform;

    [SerializeField] private float maxDistance;

    [SerializeField] private LayerMask wallLayerMask;


    // HP Doctor

    [SerializeField] private float maxHealth;

    [SerializeField] private float healAmount;

    private float currentHealth;

    [SerializeField] private Image healthBarImage;


    private void Awake()
    {
        currentHealth = maxHealth;
    }


    // Flask
    private void Ability1()
    {
        if (Time.time > nextFlask)
        {
            if (Input.GetKeyDown(ability1))
            {
                Instantiate(flask, flaskSpawn.position, transform.rotation);
                nextFlask = (int)(Time.time + flaskCooldown);


            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    private void ActivateRaycast()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            RaycastDart();
        }

    }


    public void RaycastDart()
    {
        RaycastHit hit;

        var collideSomething = Physics.Raycast(eyesTransform.position, transform.forward, out hit, maxDistance, wallLayerMask);

        if (collideSomething)
        {
            Debug.Log($"Hit {hit.transform.name}");
        }
    }


    // Update is called once per frame
    void Update()
    {
        Move();

        Ability1();


        ActivateRaycast();

        /*
                if (Input.GetKeyDown(KeyCode.O))
                {
                    GetDamage();
                    Debug.Log($"Dano recibido {damageAmount}!! La vida actual es: {currentHealth}");
                }


                if (Input.GetKeyDown(KeyCode.P))
                {
                    HealDamage();
                    Debug.Log($"Nos hemos curado {healAmount}!! La vida actual es: {currentHealth}");
                }
        */
        BossDeath();
    }

    private void BossDeath()
    {
        if (GameObject.FindGameObjectsWithTag("Boss").Length == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("UI");
            }
        }
    }

    public void GoblinDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        var healthPercentage = currentHealth / maxHealth;

        healthBarImage.fillAmount = healthPercentage;

        if(currentHealth == 0)
        {
            Destroy(gameObject);

            SceneManager.LoadScene("MiniRPG Dungeon");
        }
    }


    public void HealDamage(float healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        var healthPercentage = currentHealth / maxHealth;

        healthBarImage.fillAmount = healthPercentage;
    }

}


