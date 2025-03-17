using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("STRESS")]
    public static float stressLevel;
    [SerializeField]
    public float stressMax = 50f;
    [SerializeField] Image stressBar;
    private float currentChangeAmount;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //sets stress as 30 for story purposes
        stressLevel = 30f;
        stressBar.fillAmount = stressLevel / stressMax;
    }

    #region STRESS
    public void UpdateStress(float changeAmount)
    {
        
        stressLevel += changeAmount;
        // Clamp stressLevel to a reasonable range (0 to the max)
        stressLevel = Mathf.Clamp(stressLevel, 0, stressMax);
        stressBar.fillAmount = stressLevel / stressMax;
    }

    public void StartStressChange(float changeAmount, float interval)
    {
        currentChangeAmount = changeAmount;
        InvokeRepeating("UpdateStressWithAmount", interval, interval);
    }

    public void StopStressChange()
    {
        CancelInvoke("UpdateStressWithAmount");
    }
    private void UpdateStressWithAmount()
    {
        // This is the function that gets called by InvokeRepeating
        UpdateStress(currentChangeAmount);
        Debug.Log("stress is " + stressLevel);
    }

    public void UpStress(float changeAmount)
    {
        stressLevel += changeAmount;
        stressLevel = Mathf.Clamp(stressLevel, 0, stressMax);
        stressBar.fillAmount = stressLevel / stressMax;
        Debug.Log("stress is " + stressLevel);
        /*if (stressLevel < 50)
        {
            stressLevel += 5f;
            stressBar.fillAmount = stressLevel / 50f;
            Debug.Log("Stress is " + stressLevel);
        }*/

    }

    public void DownStress()
    {
        if (stressLevel > 0)
        {
            stressLevel -= 5f;
            stressBar.fillAmount = stressLevel / 50f;
            Debug.Log("Stress is " + stressLevel);
        }

    }
    #endregion
}
