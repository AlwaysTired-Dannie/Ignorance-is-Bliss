using UnityEngine;
using System.Collections;

public class LucyTexts01 : MonoBehaviour
{
    public float waitTime = 5;

    private void Start()
    {
        TutorialEnd.onTutorialEnd += StartCountdown;
    }

    private void StartCountdown()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        
            yield return new WaitForSeconds(5f);
            AddTextToChat textScript = GetComponent<AddTextToChat>();
            textScript.AddTextChild();
            yield return null;
        

    }
}
