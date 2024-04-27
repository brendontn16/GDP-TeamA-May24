using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI roundNumberText;
    public TextMeshProUGUI brawlText;

    public TextMeshProUGUI timerText;
    public int timer = 99;

    private int roundNumber;

    private string round = "ROUND";
    //private string fighttext = "fighttext";
    public static bool newRound = false;
    public static bool stopTimer = false;

    void Start()
    {
        roundText.text = "";
        roundNumberText.text = "";
        brawlText.text = "";
        roundNumber = 1;
        timerText.text = "99";
        timer = 99;
        StartCoroutine(showRoundText());
        StartCoroutine(timerCountDown());
    }
    void Update()
    {
        if (newRound)
        {
            //Debug.
            timer = 99;
            stopTimer = false;
            StopAllCoroutines();
            StartCoroutine(showRoundText());
            StartCoroutine(timerCountDown());
            roundNumber++;
            newRound = false;

        }
    }
    public IEnumerator showRoundText()
    {
        foreach(char letter in round.ToCharArray())
        {
            roundText.text += letter;
            yield return new WaitForSeconds(0.2f);
        }
        if (roundNumber == 1)
            roundNumberText.text = "01";
        else if (roundNumber == 2)
            roundNumberText.text = "10";
        else if (roundNumber == 3)
            roundNumberText.text = "11";

        roundNumberText.GetComponent<Animator>().Play("FightStart");
        roundNumberText.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        brawlText.text = "BRAWL";
        brawlText.GetComponent<Animator>().Play("fighttext");
        brawlText.GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(2);
        roundNumberText.text = "";
        brawlText.text = "";
        roundText.text = "";
        brawlText.GetComponent<Animator>().enabled = false;
        roundNumberText.GetComponent<Animator>().enabled = false;
        //StartCoroutine(timerCountDown());
    }

    IEnumerator timerCountDown()
    {
        yield return new WaitForSeconds(4.5f);
        while (timer > -1)
        {
            timerText.text = timer.ToString();
            yield return new WaitForSeconds(1);
            --timer;
            if (stopTimer)
            {
                Debug.Log("New Round");
                //stopTimer = false;
                yield break;
            }
        }
        if (timer <= -1)
        {
            GameManager.roundOver = true;
            yield return new WaitForSeconds(.5f);
            if (GameManager.totalLives1 != 0 && GameManager.totalLives2 != 0)
                newRound = true;
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed())
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
