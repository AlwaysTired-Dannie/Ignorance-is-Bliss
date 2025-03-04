using UnityEngine;
using UnityEngine.UI;

public class StressLevelChange : MonoBehaviour
{
    [Header("UI")]
    [Range(0, 50)] public static float stressLevel;
    [SerializeField] Image stressBar;

    private void Start()
    {
        stressLevel = 30f;
        stressBar.fillAmount = stressLevel / 50f;
    }

    public void UpStress()
    {
        if (stressLevel<50)
        {
            stressLevel += 5f;
            stressBar.fillAmount = stressLevel / 50f;
            Debug.Log("Stress is " + stressLevel);
        } 
        
    }

    public void DownStress()
    {
        if (stressLevel>0)
        {
            stressLevel -= 5f;
            stressBar.fillAmount = stressLevel / 50f;
            Debug.Log("Stress is " + stressLevel);
        }
        
    }
}
