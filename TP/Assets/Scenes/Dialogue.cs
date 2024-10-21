using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public List<DialogueLine> lines;
    [Range(0.0f, 1.0f)] public float interval = 0.1f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PlayLinesSequentially());
            GetComponent<Collider>().enabled = false;
        }
    }

    private IEnumerator PlayLinesSequentially()
    {
        foreach (DialogueLine line in lines)
        {
            line.Play();
            yield return new WaitForSeconds(line.clip.length + interval);
        }
    }
}
