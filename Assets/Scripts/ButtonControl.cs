using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject exitPanel;
    public GameObject menuPanel;

    private GameObject player1, player2, player3, player4;
    private GameObject playButton;

    void Start(){
        menuPanel.SetActive(false);
        exitPanel.SetActive(false);        

        if (SceneManager.GetActiveScene().name == "Menu")
        {
            playButton = GameObject.Find("Play");

            playButton.SetActive(true);

            player1 = GameObject.Find("1P");
            player2 = GameObject.Find("2P");
            player3 = GameObject.Find("3P");
            player4 = GameObject.Find("4P");            

            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
        }
        else
        {
            
        }
  
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(SceneManager.GetActiveScene().name == "Menu"){
                exitPanel.SetActive(true);
            }
            else{
                menuPanel.SetActive(true);
            }
        }
    }

    public void EscapeMenu(){
        if (SceneManager.GetActiveScene().name == "Menu"){
            exitPanel.SetActive(true);
        }
        else {
            menuPanel.SetActive(true);
        }
    }

    public void CancelBtn(){
        menuPanel.SetActive(false);
        exitPanel.SetActive(false);
    }

    public void PlayBtn()
    {
        menuPanel.SetActive(false);
        exitPanel.SetActive(false);
        playButton.GetComponent<Image>().enabled = false;
        playButton.GetComponentInChildren<Text>().enabled = false;

        player1.SetActive(true);
        player2.SetActive(true);
        player3.SetActive(true);
        player4.SetActive(true);


    }

    public void ResetBtn()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void oneP()
    {
        GameControl.nofPlayers = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void twoP()
    {
        GameControl.nofPlayers = 2;
        SceneManager.LoadScene("MainScene");
    }

    public void threeP()
    {
        GameControl.nofPlayers = 3;
        SceneManager.LoadScene("MainScene");
    }

    public void fourP()
    {
        GameControl.nofPlayers = 4;
        SceneManager.LoadScene("MainScene");
    }

    public void OpenUrl()
    {
        Application.OpenURL("https://github.com/rakharamadhana/zakat-game-next-version");
    }
    public void OpenZakatpedia()
    {
        Application.OpenURL("https://zakatpedia.com/");
    }

    public void OpenIZI()
    {
        Application.OpenURL("https://izi.or.id");
    }

}
