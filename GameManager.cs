using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using TMPro;


public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   
   private void Awake()
   { 
    if(GameManager.instance != null)
    {
        Destroy(gameObject);
        return;
    }
        instance = this;
        //SceneManager.sceneLoaded += SaveState;
        SceneManager.sceneLoaded+=LoadState;

        DontDestroyOnLoad(gameObject);

   }
   //Resources
   public List<Sprite> playerSprites;
   public List<Sprite> weaponSprites;
   public List<int> xpTable;

   //References
   public Player player;

    public FloatingText floatingText;
    
   //logic
   public int points;
   //public int waterPoints;
   //public int paperPoints;
   public int experience;

    public FloatingTextManager floatingTextManager;
    //floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);

    }
/*
int preferredSkin;
int points;
int experience;
int weaponLevel;

*/
    public void SaveState()
    {
        string s ="";
        s+="0"+"|";
        s+=points.ToString()+"|";
        s+=experience.ToString()+"|";
        s+="0";
        
        PlayerPrefs.SetString("SaveState", s);

    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        //SceneManager.sceneLoaded -= LoadState;
        
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        //change player skin
        points=int.Parse(data[1]);
        experience=int.Parse(data[2]);
        //change the weapon level

        Debug.Log("LoadState");
    }
}
