using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletBrazier : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private List<GameObject> BrazierLit;

    public void LightBrazier()
    {
        foreach (GameObject gameObject in BrazierLit)
        {
            gameObject.SetActive(true);
        }
    }

}
