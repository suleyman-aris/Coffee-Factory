using UnityEngine;
using UnityEditor;
using UnityEngine.Android;

public class AndroidManifestCreator : MonoBehaviour
{
    private void Start()
    {
        CreateManifest();
        RequestStoragePermission();
        
    }

    //[MenuItem("Custom/Create Android Manifest")]
    private static void CreateManifest()
    {
        string manifestPath = Application.dataPath + "/Plugins/Android/AndroidManifest.xml";
        string manifestContent = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<manifest xmlns:android=\"http://schemas.android.com/apk/res/android\" package=\"com.example.yourpackagename\">\n</manifest>";
        System.IO.File.WriteAllText(manifestPath, manifestContent);
        AssetDatabase.Refresh();
    }
    private void RequestStoragePermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
        }
    }
}
