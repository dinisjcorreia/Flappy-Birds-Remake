using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSetas : MonoBehaviour
{
    public GameObject bird;
    public GameObject seta;
    public Rigidbody2D myRigidbody;
    public float velocidadeseta;
    public LogicScript logic;
    public AudioSource dongSFX;

    public void spawnSeta()
    {

        
        if (logic.getSetas() > 0)
        {
            logic.addSetas(-1);
            Instantiate(seta, new Vector3(transform.position.x, bird.transform.position.y, 0), transform.rotation);
            myRigidbody = GameObject.FindGameObjectsWithTag("seta")[GameObject.FindGameObjectsWithTag("seta").Length - 1].GetComponent<Rigidbody2D>();
            myRigidbody.velocity = Vector2.right * velocidadeseta;
        }
        else
        {
            if (TelaInicialLogic.efeitossonoros)
            {
                logic.ativarntenssetas();
                dongSFX.Play();
            }
        }

      
    }



    // Start is called before the first frame update
    void Start()
    {
        
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        dongSFX.volume = TelaInicialLogic.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            spawnSeta();
        }
        
    }
}
