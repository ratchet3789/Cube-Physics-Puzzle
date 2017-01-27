using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; //Used for Scene Loading/Saving
using UnityEngine.UI; //Used for HUD/UI Widgets
using UnityEngine;

public class MouseFunctions : MonoBehaviour {

    bool bCanDestroy = false; //On overlap of Object with Destroyable Tag, sets to true, on Left Mouse destroys object.
    public Button ResetButton; //The UI Reset Button
    public string SceneID; //The Level Name

    void Start()
    {
        ResetButton.onClick.AddListener(RefreshScene); //Force Reset Button to use the Refresh Scene function (Line 42)
        SceneID = SceneManager.GetActiveScene().name; //Get Scene Name, then set it to SceneID for reloading (Line 44)
    }

	void FixedUpdate() //Runs at a fixed interveal. Update() runs per-frame. FixedUpdate will not change, whereas Update changed based on your current Framerate
    {
        RaycastHit hit; //Creates a list of hit objects
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Get Cursor position on Screen

        Physics.Raycast(ray, out hit); //Cast from the Camera to the cursor position

        if(hit.transform != null) //If an object was hit
        {
            if(hit.transform.tag == "Destroyable") //If the hit object has the tag "Destroyable"
                bCanDestroy = true; //Can Destroy Hit Object
            else
                bCanDestroy = false; //Else, cannot destroy
        }

        if(Input.GetMouseButtonDown(0)) //When Left Mouse is Pressed Down
            if (bCanDestroy) //If destroy is true
                Destroy(hit.transform.gameObject); //When LMB pressed, destroy object
    }

    void RefreshScene()
    {
        SceneManager.LoadScene(SceneID); //Load the SceneID aka current level when Refresh button pressed
    }
}
