using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InteractableManager : MonoBehaviour
{
    [SerializeField] private List<Transform> interactables;

    public List<Transform> Interactables
    {
        get => interactables;
    }

    private Camera mainCamera;

    public static Action<Transform> AddToInteractablesEvent;
    public static Action<Transform> RemoveFromInteractablesEvent;

    private void Awake()
    {
        AddToInteractablesEvent += AddToListOfInteractables;
        RemoveFromInteractablesEvent += RemoveFromListOfInteractables;
    }

    private void AddToListOfInteractables (Transform transformToAddToList)
    {
        interactables.Add (transformToAddToList);
    }

    private void RemoveFromListOfInteractables (Transform transformToRemoveFromList)
    {
        interactables.Remove (transformToRemoveFromList);
    }

    void Start()
    {
        mainCamera = Camera.main;
        

        AllChildrenWorldToScreenPoint();
    }

    private void AllChildrenWorldToScreenPoint()
    {
       // RaycastHit hit;
        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //if (Physics.Raycast(ray,out hit,6))
            //{
            //    transform.GetChild(i).position = mainCamera.ScreenPointToRay(transform.GetChild(i).position);
            //}
            transform.GetChild(i).position = mainCamera.WorldToScreenPoint(transform.GetChild(i).position);
            //transform.GetChild(i).position = mainCamera.ScreenPointToRay(transform.GetChild(i).position);

            //increases sphere scale to be visible
            //transform.GetChild(i).localScale = Vector3.one * 100;
        }
    }
}
