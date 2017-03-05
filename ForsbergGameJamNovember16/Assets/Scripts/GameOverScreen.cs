using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour 
{
	#region Fields/Properties

	
	
	#endregion
	#region Events
	
	void Awake()
	{        
	}
	
	void Start() 
	{
        Debug.Log("Invoking LoadStartScreen...");

        Invoke("LoadStartScreen", 8);
    }

	void Update() 
	{
    }
	
	#endregion
	#region Methods
	
	void LoadStartScreen()
    {
        Debug.Log("Loading StartScreen...");
        SceneManager.LoadScene("MainMenu");
    }
	
	#endregion
	
}