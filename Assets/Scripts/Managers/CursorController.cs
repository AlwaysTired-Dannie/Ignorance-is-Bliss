using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CursorController : MonoBehaviour
{
    private InteractiveCursorControls controls;

    [SerializeField] private InteractableManager interactableManager;

    [SerializeField] private Texture2D interactiveCursorTexture;

    private Cursor interactiveCursor;

    public static Action MakeCursorDefault;
    public static Action MakeCursorInteractive;
    public static bool cursorIsInteractive = false;

    private Camera mainCamera;
    public LayerMask interactableMask;
    


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

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward, Color.blue);
        FindInteractable();
    }

    private void FindInteractable()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, interactableMask))
        {
            //Debug.Log("hit interactable");
            InteractiveCursorTexture();
            if (cursorIsInteractive && Input.GetMouseButtonDown(0))
            {
                IInteractable interactable = hit.transform.gameObject.GetComponent<IInteractable>();

                Debug.Log("interacted");
                interactable.OnClickAction();

            }
        }
        else DefaultCursorTexture();

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
        
    }

}
