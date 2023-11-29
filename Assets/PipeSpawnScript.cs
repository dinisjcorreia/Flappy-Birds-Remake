using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public GameObject pipefechado;
    public float spawnRate = 1.35f;
    private float timer = 0;
    public float heightOffset = 10;
    public float movespeed = 10f;
    public LogicScript logic;
    bool aumentou = false;
    public AudioSource upgradeSFX;
    bool passou50 = false;
    bool passou100 = false;

    // Start is called before the first frame update
    void Start()
    {
        upgradeSFX.volume = TelaInicialLogic.volume;

        spawnPipe(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer<spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (logic.getPontos() >= 50 && passou50 == false)
            {
                movespeed = 20f;
                spawnRate = 0.675f;
                aumentou = true;
                if (TelaInicialLogic.efeitossonoros)
                {
                    upgradeSFX.Play();
                }
              
                passou50 = true;
            }
            if (logic.getPontos() >= 100 && passou100 == false)
            {
                movespeed = 40f;
                spawnRate = 0.3375f;
                aumentou = true;
                if (TelaInicialLogic.efeitossonoros)
                {
                    upgradeSFX.Play();
                }
                passou100 = true;
            }
            spawnPipe(false);
            timer = 0;
        }

       
    }

    

    void spawnPipe(bool first)
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        int rdm = Random.Range(0, 11);

        if (first ==false)
        {
            if (rdm == 9)
            {
                Instantiate(pipefechado, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
            }
            else
            {
                Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
            }
        }
        else
        {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }

       

       

      
        if (aumentou)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("cano").Length; i++)
            {

                GameObject.FindGameObjectsWithTag("cano")[i].GetComponent<PipeMoveScript>().moveSpeed = movespeed;
            }
        }

       

        
    }

}
