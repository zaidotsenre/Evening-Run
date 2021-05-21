using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] SodasUI sodasUI;
    [SerializeField] Text tomatosUI;
    [SerializeField] Text distanceUI;

    int sodas;
    int tomatos;
    int distance;
    int score;


    void Start()
    {
        tomatos = 0;
        sodas = 0;
        distance = 0;
        score = 0;

        GameManager.instance.onMilestone.AddListener(AddDistance);
        GameManager.instance.onSoda.AddListener(AddSoda);
        GameManager.instance.onTomato.AddListener(AddTomato);
        GameManager.instance.onGameOver.AddListener(SaveScore);
    }

    void AddTomato ()
    {
        tomatos++;
        score = distance + tomatos;
        tomatosUI.text = tomatos.ToString();
    } 

    void AddSoda ()
    {
        sodas++;
        sodasUI.Show(sodas);
        if (sodas >= 3)
        {
            GameManager.instance.EndGame(true);
        }    
        else
            GameManager.instance.ResetVelocity();
    }

    void AddDistance ()
    {
        distance += 10;
        score = distance + tomatos;
        distanceUI.text = distance.ToString();
    }

    void SaveScore ()
    {
        PlayerPrefs.SetInt("latestScore", score);
        PlayerPrefs.Save();
    }

}
