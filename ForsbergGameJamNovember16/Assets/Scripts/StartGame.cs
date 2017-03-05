using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour 
{
	#region Fields/Properties

	
	
	#endregion
	#region Events
	
	void Awake()
	{
		
	}
	
	void Start() 
	{
	
	}

	void Update() 
	{
	    if (Input.anyKeyDown)
        {
            UIManager.IsGameOver = false;
            SceneManager.LoadScene("01");
        }
	}
	
	#endregion
	#region Methods
	
	
	
	#endregion
	
}