using System.Collections.Generic;
using UnityEngine;

public class RandomFunFact : MonoBehaviour
{
    [SerializeField] public List<GameObject> funFactList;
    public void RandomFact()
    {
        //first choose a random fun fact
        int randomIndex = UnityEngine.Random.Range(0, funFactList.Count);
        GameObject randomFact = funFactList[randomIndex];
        //then set that gameobject active
        randomFact.SetActive(true);
    }
}
