using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptHud : MonoBehaviour
{
    //all
    enum bonus
    {
        soju = 0,
        bomb,
        orb,
        turret,
        kimchi
    }

    //bonuses
    public Image bonus1;
    public Image bonus2;
    public Image bonus3;
    public Image bonus4;
    public Image bonus5;
    public Text nbBonus1;
    public Text nbBonus2;
    public Text nbBonus3;
    public Text nbBonus4;
    public Text nbBonus5;

    //Life
    private int life_int = 3;
    public Text life_text;

    //Bullet
    // private int     bullet_int = 10;
    //public Text     bullet_text;

    //Score
    public Text score_text;
    static int score_int = 0;
    //multiplier
    public Text mult_text;
    private int mult_int = 1;

    private void Awake()
    {
    }

    // Use this for initialization
    void Start()
    {

        //bonus
        bonus1 = bonus1.GetComponent<Image>();
        nbBonus1 = nbBonus1.GetComponent<Text>();
        bonus2 = bonus2.GetComponent<Image>();
        nbBonus2 = nbBonus2.GetComponent<Text>();
        bonus3 = bonus3.GetComponent<Image>();
        nbBonus3 = nbBonus3.GetComponent<Text>();
        bonus4 = bonus4.GetComponent<Image>();
        nbBonus4 = nbBonus4.GetComponent<Text>();
        bonus5 = bonus5.GetComponent<Image>();
        nbBonus5 = nbBonus5.GetComponent<Text>();

        nbBonus1.text = "1";
        nbBonus2.text = "1";
        nbBonus3.text = "1";
        nbBonus4.text = "1";
        nbBonus5.text = "1";

        //life
        life_text = life_text.GetComponent<Text>();
        life_text.text = life_int.ToString();

        //bullet
        // bullet_text = bullet_text.GetComponent<Text>();
        // bullet_text.text = bullet_int.ToString();

        //Score
        score_text = score_text.GetComponent<Text>();
        score_text.text = score_int.ToString();

        //Mult
        mult_text = mult_text.GetComponent<Text>();
        mult_text.text = "x" + mult_int.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        life_text.text = life_int.ToString();
        //    bullet_text.text = bullet_int.ToString();
        score_text.text = score_int.ToString();
    }

    public int handle_bonus(int bonus, bool active, int nb)
    {
        if (active)
        {
            mult_int += 1;
            switch (bonus)
            {
                case 0:
                    nbBonus1.text = nb.ToString();
                    break;
                case 1:
                    nbBonus2.text = nb.ToString();
                    break;
                case 2:
                    nbBonus3.text = nb.ToString();
                    break;
                case 3:
                    nbBonus4.text = nb.ToString();
                    break;
                case 4:
                    nbBonus5.text = nb.ToString();
                    break;
                default:
                    break;
            }
        }
        return 0;
    }

    public int handle_score(int plus)
    {
        score_int += plus;
        score_int = score_int * mult_int;
        mult_int = 1;
        mult_text.text = "x" + mult_int.ToString();
        score_text.text = score_int.ToString();
        return 0;
    }

    /* public int handle_ammo()
     {
         bullet_int -= 1;
         if (bullet_int < 0)
             bullet_int = 10;
         bullet_text.text = bullet_int.ToString();
         return 0;
     }*/

    public int reset_life()
    {
        life_int = 5;
        life_text.text = life_int.ToString();
        return 0;
    }

    public int handle_life(int minus)
    {
        if (minus == 0)
            life_int--;
        else
            life_int = life_int - minus;
        if (life_int <= 0)
        {
            PlayerPrefs.SetInt("HighScore", score_int);
            PlayerPrefs.SetString("SceneName", SceneManager.GetActiveScene().name);
            if (NiceSceneTransition.instance != null)
            {
                NiceSceneTransition.instance.LoadScene("Death");
            }
            else
            {
                SceneManager.LoadScene("Death", LoadSceneMode.Single);
            }
            return -1;
        }
        life_text.text = life_int.ToString();
        return 0;
    }
}
