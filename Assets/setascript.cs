using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setascript : MonoBehaviour
{
    public LogicScript logic;
    public float deadZone = -13;
    public List<float> lista = new List<float>();
   

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deadZone)
        {
            Debug.Log("Seta deleted!");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            float min = System.Math.Abs((GameObject.FindGameObjectsWithTag("cano")[0].transform.position.x) - (gameObject.transform.position.x));
            int minid = 0;
            for (int i = 1; i < GameObject.FindGameObjectsWithTag("cano").Length; i++)
            {

                if (System.Math.Abs((GameObject.FindGameObjectsWithTag("cano")[i].transform.position.x) - (gameObject.transform.position.x)) < min)
                {
                    min = System.Math.Abs((GameObject.FindGameObjectsWithTag("cano")[i].transform.position.x) - (gameObject.transform.position.x));
                    minid = i;
                }
            }

            Destroy(GameObject.FindGameObjectsWithTag("cano")[minid].transform.GetChild(0).gameObject);

            logic.addScore(1);
            logic.setcanodestruido(true);
            Destroy(gameObject);



        }
     
       

    }

  

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 6)
        {
            Destroy(gameObject);
        }

       
    }
}
