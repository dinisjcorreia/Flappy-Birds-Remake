using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TelaInicialLogic : MonoBehaviour
{

    public GameObject toggle;
    public static bool efeitossonoros = true;
    public static float volume = 0.3f;
    public GameObject slider;
    public GameObject menupersonagens;
    public GameObject menuprincipal;


    // Start is called before the first frame update
    void Start()
    {
       if (efeitossonoros)
        {
            toggle.GetComponent<Toggle>().isOn = true;
        }
       else
        {
            toggle.GetComponent<Toggle>().isOn = false;
        }

        slider.GetComponent<Slider>().value = volume;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IniciarJogo();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menupersonagens.gameObject.SetActive(false);
            menuprincipal.gameObject.SetActive(true);
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("recorde", 0);
        
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("GameScreen", LoadSceneMode.Single);
    }

    public void EfeitosSonoros()
    {
        if (toggle.GetComponent<Toggle>().isOn)
        {
            efeitossonoros = true;
        }
        else
        {
            efeitossonoros = false;
        }


    }

    public void EscolherRed()
    {
        PlayerPrefs.SetString("passaro", "angry");
    }

    public void EscolherBlue()
    {

        PlayerPrefs.SetString("passaro", "passaronormal");
    }

    public void SairTelaEscolher()
    {
        menupersonagens.gameObject.SetActive(false);
        menuprincipal.gameObject.SetActive(true);
    }

    public void EntrarTelaEscolher()
    {
       
        menuprincipal.gameObject.SetActive(false);
        menupersonagens.gameObject.SetActive(true);
    }

    public void alterarvolume()
    {
        volume = slider.GetComponent<Slider>().value;
    }

    
}
