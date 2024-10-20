using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletBrazier : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<GameObject> BrazierLit;
    [SerializeField] private string CorrespondingScene;

    public void Start()
    {
        if (PlayerPrefs.GetInt(CorrespondingScene) == 1)
        {
            LightBrazier();
        }
    }

    private void LightBrazier()
    {
        foreach (GameObject gameObject in BrazierLit)
        {
            gameObject.SetActive(true);
        }
    }

}
