using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CursorController : MonoBehaviour
{
    private InteractiveCursorControls controls;

    [SerializeField] private InteractableManager interactableManager;

    [SerializeField] private Texture2D interactiveCursorTexture;

    private Cursor interactiveCursor;

    [SerializeField]
    private Transform newSelectionTransform;
    private Transform currentSelectionTransform;

    public static Action MakeCursorDefault;
    public static Action MakeCursorInteractive;
    private bool cursorIsInteractive = false;

    public float DistanceThreshold;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Awake()
    {
        controls = new InteractiveCursorControls();
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
        MakeCursorDefault += DefaultCursorTexture;
        MakeCursorInteractive += InteractiveCursorTexture;

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        //FindInteractableWithinDistanceThreshold();
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward, Color.blue);
    }

    private void FindInteractableWithinDistanceThreshold()
    {
        newSelectionTransform = null;

        for (int itemIndex = 0;
            itemIndex < interactableManager.Interactables.Count;
            itemIndex++)
        {
            Vector3 fromMouseToInteractableOffset =
                interactableManager.Interactables[itemIndex].position - new Vector3(
                    controls.Mouse.Position.ReadValue<Vector2>().x,
                    controls.Mouse.Position.ReadValue<Vector2>().y,
                    0f);
            float sqrMag = fromMouseToInteractableOffset.sqrMagnitude;

            if (sqrMag < DistanceThreshold * DistanceThreshold)
            {

                newSelectionTransform = interactableManager.Interactables[itemIndex].transform;
                if (cursorIsInteractive == false)
                {
                    InteractiveCursorTexture();
                }
                break;
            }
        }

        if ( currentSelectionTransform != newSelectionTransform)
        {
            currentSelectionTransform = newSelectionTransform;
            DefaultCursorTexture();
        }
    }

    private void InteractiveCursorTexture()
    {
        cursorIsInteractive = true;
        Vector2 hotspot = new Vector2(interactiveCursorTexture.width / 2, 0);
        Cursor.SetCursor(interactiveCursorTexture, hotspot, CursorMode.Auto);
    }

    private void DefaultCursorTexture()
    {
        cursorIsInteractive = false;
        Cursor.SetCursor(default, default, default);
    }

    private void StartedClick()
    {

    }

    private void EndedClick()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 6))
        {
            
            OnClickInteractable();
        }
        
    }

    private void OnClickInteractable()
    {

        if (newSelectionTransform != null)
        {
            IInteractable interactable = newSelectionTransform.gameObject.GetComponent<IInteractable>();
            if (interactable != null) { interactable.OnClickAction(); }
            //sets cursor to default and makes so we can't click on this again
            newSelectionTransform = null;
            
        }
    }

}
