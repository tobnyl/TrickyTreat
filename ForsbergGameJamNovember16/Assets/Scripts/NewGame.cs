    using UnityEngine;
using System.Collections;
    using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour 
{
	#region Public Fields

    public string SceneToLoad;

	#endregion	
	#region Private Fields	
	
	#endregion
	#region Events

    public void StartGame()
    {
        SceneManager.LoadScene("NewGame");
    }
	
	#endregion
}
