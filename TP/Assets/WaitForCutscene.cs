using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WaitForCutscene : MonoBehaviour
{

    [SerializeField] private PlayableDirector director;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForCutsceneEnd());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForCutsceneEnd()
    {
        yield return new WaitForSeconds(50.0f);
        Application.Quit();
    }
}
