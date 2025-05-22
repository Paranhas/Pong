using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer01 = Color.white;
    public Color colorPlayer02 = Color.white;

    private static SaveController _instance;

    public string namePlayer;
    public string namePlayer2;

    private string saveWinnerKey = "SavedWinner";

    public static SaveController Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<SaveController>();
                if(_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        // Garanta que apenas uma instância do Singleton exista
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        // Mantenha o Singleton vivo entre as cenas
        DontDestroyOnLoad(this.gameObject);
    }
    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer : namePlayer2;
    }
    public void Reset()
    {
        namePlayer = "";
        namePlayer2 = "";
        colorPlayer01 = Color.white;
        colorPlayer02 = Color.white;    
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(saveWinnerKey, winner);
    }
    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(saveWinnerKey);
    }
    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
