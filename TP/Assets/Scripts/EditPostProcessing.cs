using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EditPostProcessing : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postVol;
    [SerializeField] private PlayerStatManager stats;
    private ChromaticAberration chromAbb;

    // Start is called before the first frame update
    void Start()
    {
        postVol.profile.TryGetSettings(out chromAbb);
    }

    // Update is called once per frame
    void Update()
    {
        chromAbb.intensity.value = stats.GetPoop();
    }
}
