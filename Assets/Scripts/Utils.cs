using UnityEngine;
using UnityEditor;

public class Utils
{
    [MenuItem("Custom Tools/Delete All Player Prefs")]
    public static void DeletePlayerPrefs()
    {
        Debug.Log("All PlayerPrefs are deleted!");
        PlayerPrefs.DeleteAll();
    }
}
