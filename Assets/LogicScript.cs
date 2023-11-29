using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource dingSFX;
    public AudioSource backgroundmusic;
    public Text recorde;
    public int setas;
    public Text Setas;
    public GameObject faltadesetas;


    public bool canodestruido = false;

    public void setcanodestruido(bool mode)
    {
        canodestruido = mode;
    }

    public bool getcanodestruido()
    {
        return canodestruido;
    }

    void Start()
    {
        
        canodestruido = false;
        setas = 0;
        dingSFX.volume = TelaInicialLogic.volume;
        recorde.text = "Recorde: " + PlayerPrefs.GetInt("recorde");

        if (TelaInicialLogic.efeitossonoros)
        {
            backgroundmusic.volume = TelaInicialLogic.volume*0.15f;
        }
    }

    [ContextMenu("+1 ponto")]
    public void addScore(int scoreToAdd)
    {
        if (BirdScript.birdIsAlive)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            playefeitosonoro();
          
            if (playerScore> PlayerPrefs.GetInt("recorde"))
            {
                PlayerPrefs.SetInt("recorde", playerScore);
                recorde.text = "Recorde: " + PlayerPrefs.GetInt("recorde");
            }
        }

       
    }

    public void addSetas(int setasnum)
    {
        if (BirdScript.birdIsAlive)
        {

            setas += setasnum;
            Setas.text = "Setas: " + setas;



        }

        }

    public int getPontos()
    {
        return playerScore;
    }

    public int getSetas()
    {
        return setas;
    }

    public void playefeitosonoro()
    {
        if (TelaInicialLogic.efeitossonoros)
        {
            dingSFX.Play();
        }
    }
    public static void IrParaInicio()
    {
        SceneManager.LoadScene("TelaInicial", LoadSceneMode.Single);
    }

   

    public static void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        backgroundmusic.volume = 0;
        gameOverScreen.SetActive(true);
       

    }

    public void ativarntenssetas()
    {
        StartCoroutine(ntenssetas());
    }
    public IEnumerator ntenssetas()
    {
        faltadesetas.SetActive(true);
        yield return new WaitForSeconds(1f);
        faltadesetas.SetActive(false);

    }
    
}
