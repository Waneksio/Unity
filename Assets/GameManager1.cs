using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    // Start is called before the first frame update

    public bool player;
    public int turnCount;
    public Button[] spaces;
    public Text[] texts;
    public Text information;
    public Dictionary<string, int> map = new Dictionary<string, int>();
    float xScore;
    float oScore;
    int[] winningScores;
    bool game;

    public void ClickLoL(int WhichNumber, Text text)
    {
        if (player)
        {
            text.text = "X";
            spaces[WhichNumber].interactable = false;
            player = false;
        }
        else
        {
            text.text = "O";
            spaces[WhichNumber].interactable = false;
            player = true;
        }
    }

    void GameSetup()
    {
        game = true;
        xScore = 1.0f;
        oScore = 1.0f;
        map.Add("UL", 2);
        map.Add("U", 3);
        map.Add("UR", 5);
        map.Add("L", 7);
        map.Add("M", 11);
        map.Add("R", 13);
        map.Add("DL", 17);
        map.Add("D", 19);
        map.Add("DR", 23);
        player = true;
        turnCount = 0;
        information.text = "Current player: X";
        information.fontSize = 15;
        for ( int  i = 0; i < spaces.Length; i++)
        {
            spaces[i].interactable = true;
        }
    }

    public void Czysc()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].fontSize = 60;
            texts[i].text = "";
        }
    }

    public void Zaznacz(Text text)
    {
        if (game)
        {
            if (text.text == "")
            {
                if (player)
                {
                    text.text = "X";
                    player = false;
                    information.text = "Current player: O";
                    xScore *= map[text.name];
                }
                else
                {
                    text.text = "O";
                    player = true;
                    information.text = "Current player: X";
                    oScore *= map[text.name];
                }
                turnCount += 1;
            }
            if (xScore % 30 == 0 || xScore % 1001 == 0 || xScore % 7429 == 0 || xScore % 238 == 0 || xScore % 627 == 0 || xScore % 1495 == 0 || xScore % 506 == 0 || xScore % 935 == 0)
            {
                information.text = "X won!";
                StopGame();
            }
            if (oScore % 30 == 0 || oScore % 1001 == 0 || oScore % 7429 == 0 || oScore % 238 == 0 || oScore % 627 == 0 || oScore % 1495 == 0 || oScore % 506 == 0 || oScore % 935 == 0)
            {
                information.text = "O won!";
                StopGame();
            }
        }
    }

    public void Pisz(Text text)
    {
        text.text = "Nowy";
    }

    void StopGame()
    {
        game = false;
    }

    void Start()
    {
        Czysc();
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
