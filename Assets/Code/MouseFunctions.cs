using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; //Used for Scene Loading/Saving
using UnityEngine.UI; //Used for HUD/UI Widgets
using UnityEngine;

public class MouseFunctions : MonoBehaviour {

    bool bCanDestroy = false; //On overlap of Object with Destroyable Tag, sets to true, on LMB destroys object.
    public Button ResetButton;
    public string SceneID;

    void Start()
    {
        ResetButton.onClick.AddListener(RefreshScene); //Force Reset Button to use the Refresh Scene function (Line 42)
        SceneID = SceneManager.GetActiveScene().name; //Get Scene Name, then set it to SceneID for reloading (Line 44)
    }

	void FixedUpdate()
    {
        RaycastHit hit; //Checks for objects overlapping
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Get Cursor position on Screen

        Physics.Raycast(ray, out hit); //Cast from camera to Cursor Position

        if(hit.transform != null) //If an object was hit
        {
            if(hit.transform.tag == "Destroyable") //If the hit object has the tag "Destroyable"
                bCanDestroy = true; //Can Destroy Hit Object
            else
                bCanDestroy = false; //Else, cannot destroy
        }

        if(Input.GetMouseButtonDown(0)) //When Left Mouse is Pressed Down
            if (bCanDestroy) //If destroy is true
                Destroy(hit.transform.gameObject); //When LMB Held, destroy object
    }

    void RefreshScene()
    {
        SceneManager.LoadScene(SceneID); //Load the SceneID aka current level
    }
}
