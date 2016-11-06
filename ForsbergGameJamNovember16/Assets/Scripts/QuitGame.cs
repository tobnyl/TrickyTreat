using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour 
{
	#region Public Fields

	#endregion	
	#region Private Fields	
	
	#endregion
	#region Events


    public void Quitgame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }

    #endregion
}
