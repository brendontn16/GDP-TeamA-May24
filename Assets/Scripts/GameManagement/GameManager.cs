using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Fighters")]
    public GameObject player1;
    public GameObject player2;

    [Header("Fighter Spawn Positions")]
    public Transform player1Pos;
    public Transform player2Pos;

    private PlayerInput player1Controls;
    private PlayerInput player2Controls;

    public CharacterDataLoader Data;

    private Slider healthBar1;
    private Slider healthBar2;

    [Header("Health Bars")]
    public GameObject heathPrefab1;
    public GameObject heathPrefab2;
    public Gradient healthColor1;
    public Gradient healthColor2;
    private Image fill1;
    private Image fill2;

    [Header("Super Bars")]
    public GameObject superPrefab1;
    public GameObject superPrefab2;
    private Slider superBar1;
    private Slider superBar2;
    private Image superFill1;
    private Image superFill2;
    public Gradient superColor;
    public static float super1 = 0;
    public static float super2 = 0;

    const float maxhealth = 3;
    public static float health1 = 3;
    public static float health2 = 3;

    public TextMeshProUGUI winnerText;
    public static bool roundOver;

    [Header("Player 1 Icon and Name")]
    public TextMeshProUGUI player1Text;
    public Image player1Icon;
    public List<Image> player1Lives;

    [Header("Player 2 Icon and Name")]
    public TextMeshProUGUI player2Text;
    public Image player2Icon;
    public List<Image> player2Lives;

    private int roundNumber;
    bool onlyOnce = true;

    bool super1Filled = false;
    bool super2Filled = false;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Awake()
    {
        if (GamepadJoin.playerControllers.ContainsKey(1))
        {
            player1 = CSSManager.player1Object;
            player1Controls = PlayerInput.Instantiate(player1, 1, "Controller", -1, GamepadJoin.playerControllers[1]);
            player1Controls.transform.position = player1Pos.position;
            var inputUser = player1Controls.user;
            player1Controls.SwitchCurrentControlScheme("Controller");
            InputUser.PerformPairingWithDevice(GamepadJoin.playerControllers[1], inputUser, InputUserPairingOptions.UnpairCurrentDevicesFromUser);

            player2 = CSSManager.player2Object;
            player2Controls = PlayerInput.Instantiate(player2, 2, "Controller", -1, GamepadJoin.playerControllers[2]);
            player2Controls.transform.position = player2Pos.position;
            var inputUser2 = player2Controls.user;
            player2Controls.SwitchCurrentControlScheme("Controller");
            InputUser.PerformPairingWithDevice(GamepadJoin.playerControllers[2], inputUser2, InputUserPairingOptions.UnpairCurrentDevicesFromUser);

            GameObject bar1 = Instantiate(heathPrefab1, GameObject.FindGameObjectWithTag("HealthBar").transform.parent);
            healthBar1 = bar1.GetComponent<Slider>();

            GameObject bar2 = Instantiate(heathPrefab2, GameObject.FindGameObjectWithTag("HealthBar").transform.parent);
            healthBar2 = bar2.GetComponent<Slider>();

            fill1 = bar1.GetComponentInChildren<Image>();
            fill2 = bar2.GetComponentInChildren<Image>();

            GameObject sbar1 = Instantiate(superPrefab1, GameObject.FindGameObjectWithTag("HealthBar").transform.parent);
            superBar1 = sbar1.GetComponent<Slider>();

            GameObject sbar2 = Instantiate(superPrefab2, GameObject.FindGameObjectWithTag("HealthBar").transform.parent);
            superBar2 = sbar2.GetComponent<Slider>();

            superFill1 = sbar1.GetComponentInChildren<Image>();
            superFill2 = sbar2.GetComponentInChildren<Image>();

            winnerText.text = "";

            player1Text.text = CSSManager.player1FighterName;
            player2Text.text = CSSManager.player2FighterName;

            player1Icon.sprite = CSSManager.player1Fighter;
            player2Icon.sprite = CSSManager.player2Fighter;

            GameObject.Find("StageBackground").GetComponent<Image>().sprite = CSSManager.stage;

            roundNumber = 1;
            onlyOnce = true;
        } 
        else
        {
            Instantiate(player1, player1Pos);
            Instantiate(player2, player2Pos);
            player1Controls = player1.GetComponent<PlayerInput>();
            player2Controls = player2.GetComponent<PlayerInput>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Controls.transform.position.x < player2Controls.transform.position.x)
        {
            player1Controls.GetComponent<CharacterMovement>().facingRight = true;
            player2Controls.GetComponent<CharacterMovement>().facingRight = false;
        }
        else
        {
            player1Controls.GetComponent<CharacterMovement>().facingRight = false;
            player2Controls.GetComponent<CharacterMovement>().facingRight = true;
        }
        if (SceneManager.GetActiveScene().name == "BrawlScene")
        {
            healthBar1.value = health1;
            healthBar2.value = health2;
            fill1.color = healthColor1.Evaluate(healthBar1.normalizedValue);
            fill2.color = healthColor2.Evaluate(healthBar2.normalizedValue);

            if (superBar1.value != superBar1.maxValue)
            {
                super1 += .5f;
                superBar1.value = super1;
            }
            else
            {
                //if (!super1Filled)
                //{
                    superFill1.color = superColor.Evaluate(Time.deltaTime);
                    //super1Filled = true;
                //}
            }

            if (superBar2.value != superBar2.maxValue)
            {
                super2 += .5f;
                superBar2.value = super2;
            }
            else
            {
                //if (!super2Filled)
                //{
                superFill2.color = superColor.Evaluate(Time.deltaTime);
                // super2Filled = true;
                //}
            }

            if (roundOver)
            {
                if (health1 <= 0 && health2 > 0)
                {
                    winnerText.color = new Color(1f, 0, 0, 1f);
                    winnerText.text = CSSManager.player2FighterName + " Wins!";

                    if (player1Lives.Count == 2)
                    {
                        player1Lives[0].enabled = false;
                        player1Lives.RemoveAt(0);
                    }
                    else if (player1Lives.Count == 1)
                    {
                        player1Lives[0].enabled = false;
                        player1Lives.RemoveAt(0);
                    }

                }
                else if (health2 <= 0 && health1 > 0)
                {
                    winnerText.color = new Color(0, 0, 1f, 1f);
                    winnerText.text = CSSManager.player1FighterName + " Wins!";
                    if (player2Lives.Count == 2)
                    {
                        player2Lives[0].enabled = false;
                        player2Lives.RemoveAt(0);
                    }
                    else if (player2Lives.Count == 1)
                    {
                        player2Lives[0].enabled = false;
                        player2Lives.RemoveAt(0);
                    }
                }
                else
                {
                    winnerText.text = "Draw";
                }

                health1 = maxhealth;
                health2 = maxhealth;
                roundOver = false;
                ++roundNumber;

                if (player1Lives.Count == 0 && onlyOnce)
                {
                    StartCoroutine(EndGame(CSSManager.player2FighterName));
                    onlyOnce = false;
                }
                else if (player2Lives.Count == 0 && onlyOnce)
                {
                    StartCoroutine(EndGame(CSSManager.player1FighterName));
                    onlyOnce = false;
                }
                else
                {
                    StartCoroutine(WaitBetweenRounds());
                }
            }
        }
    }
    IEnumerator WaitBetweenRounds()
    {
        player1Controls.enabled = false;
        player2Controls.enabled = false;
        yield return new WaitForSeconds(5f);
        GameUIManager.newRound = true;
        winnerText.text = "";
        player1Controls.transform.position = player1Pos.position;
        player2Controls.transform.position = player2Pos.position;
        StartCoroutine(DisableControls());
    }
    IEnumerator DisableControls()
    {
        yield return new WaitForSeconds(5f);
        //player1Controls.enabled = true;
        //player2Controls.enabled = true;
    }
    IEnumerator EndGame(string playerWhoWon)
    {
        //player1Controls.enabled = false;
        //player2Controls.enabled = false;
        winnerText.text = playerWhoWon + " Is The Binary Camp!";
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("TitleScreen");
    }
}
