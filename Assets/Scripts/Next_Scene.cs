using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Scene : MonoBehaviour
{
    float time;
    public float Zeit;
    public string Szene;

    public void NSzene()
    {
        SceneManager.LoadScene(Szene, LoadSceneMode.Single);
    }


    void Update()
    {
        time = Time.deltaTime + time;
        if (time > Zeit)
        {
            NSzene();
        }
    }
}