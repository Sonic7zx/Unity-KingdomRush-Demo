using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceLoader : MonoBehaviour
{
    public static SenceLoader instance;
    public string targetSence;
    public void JumpToSence()
    {
        SceneManager.LoadScene(targetSence);
    }
}
