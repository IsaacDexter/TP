using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoopBarUI : MonoBehaviour
{
    public Slider PoopBar;

    private PlayerStatManager stats;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStatManager>();
        PoopBar.value = 0;
        PoopBar.maxValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.GetPoop() < PoopBar.maxValue)
        {
            PoopBar.value = stats.GetPoop();
        }
    }
}
