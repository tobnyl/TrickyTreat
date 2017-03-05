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
        Invoke("LoadStartScreen", 8);
    }

	void Update() 
	{
    }
	
	#endregion
	#region Methods
	
	void LoadStartScreen()
    {        
        SceneManager.LoadScene("MainMenu");
    }
	
	#endregion
	
}