using UnityEngine.SceneManagement;

public class SceneTransition
{
    public string SceneToLoad;
    public void Loadscene()
    {
        SceneManager.LoadSceneAsync(SceneToLoad);
    }
    public void Quit()
    { }
}
