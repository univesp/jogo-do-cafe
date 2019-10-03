using UnityEngine;
using UnityEngine.SceneManagement;
public class CarregaCena : MonoBehaviour
{
    public void LoadScene(int _sceneIndex)
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}
