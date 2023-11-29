using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrenght;
    public LogicScript logic;
    public static bool birdIsAlive = true;
    public Animator BirdWing;
    public AudioSource morteSFX;
    public SpriteRenderer spriteRenderer;
    public Sprite passaronormal;
    public Sprite angrybird;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdIsAlive = true;
        morteSFX.volume = 0;

        //   PlayerPrefs.SetString("passaro", "passaronormal");
        // PlayerPrefs.SetString("passaro", "angry");

        if (PlayerPrefs.GetString("passaro")=="angry")
        {
            spriteRenderer.sprite = angrybird;
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
            if (PlayerPrefs.GetString("passaro") == "passaronormal")
        {
            spriteRenderer.sprite = passaronormal;
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrenght;

            BirdWing.SetBool("anim", true);
            
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive == false)
        {
            LogicScript.restartGame();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            BirdWing.SetBool("anim", false);
        }

        if (transform.position.y > 17 || transform.position.y < -17)
        {
            if (TelaInicialLogic.efeitossonoros && birdIsAlive)
            {
                morteSFX.volume = TelaInicialLogic.volume;
                morteSFX.Play();
            }
            killBird();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LogicScript.IrParaInicio();
        }
    }

    private void killBird()
    {
        logic.gameOver();
        birdIsAlive = false;
       
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (TelaInicialLogic.efeitossonoros && birdIsAlive)
        {
            morteSFX.volume = TelaInicialLogic.volume;
            morteSFX.Play();
        }
        killBird();
       

    }
}
