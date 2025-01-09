using UnityEngine;
using UnityEngine.UI;

public class StressLevelChange : MonoBehaviour
{
    [Header("UI")]
    [Range(0, 20)] public static float stressLevel = 0;
    [SerializeField] Image stressBar;

    private void Start()
    {
        stressBar.fillAmount = stressLevel;
    }

    public void UpStress()
    {
        if (stressLevel<20)
        {
            stressLevel += 5f;
            stressBar.fillAmount = stressLevel / 20f;
            Debug.Log("Stress is " + stressLevel);
        } 
        
    }

    public void DownStress()
    {
        if (stressLevel>0)
        {
            stressLevel -= 5f;
            stressBar.fillAmount = stressLevel / 20f;
            Debug.Log("Stress is " + stressLevel);
        }
        
    }
}
