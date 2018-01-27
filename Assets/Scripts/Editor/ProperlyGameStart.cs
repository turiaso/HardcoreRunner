using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;

public class ProperlyGameStart
{

    [MenuItem("GGJ2018/Play Game", false, 0)]
    private static void NewMenuOption()
    {
        if (EditorApplication.isPlaying)
            EditorApplication.isPlaying = false;
        // return false if you press cancel in the save dialog
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            EditorSceneManager.OpenScene("Assets/Scenes/0.LoadingScene.unity");
            EditorApplication.isPlaying = true;
        }
    }
}
