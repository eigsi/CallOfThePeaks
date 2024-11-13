using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class which handles reading Input for other scripts to reference
/// </summary>
public class InputManager : MonoBehaviour
{
    // A global instance for scripts to reference
    public static InputManager instance;

    /// <summary>
    /// Description:
    /// Standard Unity Function called when the script is loaded
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    private void Awake()
    {
        ResetValuesToDefault();
        // Set up the instance of this
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Description:
    /// Sets all the input variables to their default values so that nothing weird happens in the game if you accidentally
    /// set them in the editor
    /// Input:
    /// none
    /// Return:
    /// void
    /// </summary>
    void ResetValuesToDefault()
    {
        horizontalMovement = default;
        verticalMovement = default;

        horizontalLookAxis = default;
        verticalLookAxis = default;

        jumpStarted = default;
        jumpHeld = default;

        pauseButton = default;
    }

    /*---------------------------------------Movement------------------------------------------------------*/

    [Header("Movement Input")]
    [Tooltip("The horizontal movmeent input of the player.")]
    public float horizontalMovement;
    [Tooltip("The vertical movmeent input of the player.")]
    public float verticalMovement;
    
    public void GetMovementInput(InputAction.CallbackContext callbackContext)
    {
        Vector2 movementVector = callbackContext.ReadValue<Vector2>();
        horizontalMovement = movementVector.x;
        verticalMovement = movementVector.y;
    }

    /*---------------------------------------Jump------------------------------------------------------*/
    
    [Header("Jump Input")]
    [Tooltip("Whether a jump was started this frame.")]
    public bool jumpStarted = false;
    [Tooltip("Whether the jump button is being held.")]
    public bool jumpHeld = false;

    public void GetJumpInput(InputAction.CallbackContext callbackContext)
    {
        jumpStarted = !callbackContext.canceled;
        jumpHeld = !callbackContext.canceled;
        if (InputManager.instance.isActiveAndEnabled)
        {
            StartCoroutine("ResetJumpStart");
        } 
    }


    private IEnumerator ResetJumpStart()
    {
        yield return new WaitForEndOfFrame();
        jumpStarted = false;
    }
    
    /*---------------------------------------Grapple----------------------------------------------------*/

    [Header("Grapple Input")]
    [Tooltip("Whether a grapple was started this frame.")]
    public bool grappleStarted = false;
    [Tooltip("Whether the jump button is being held.")]
    public bool grappleHeld = false;

    public void GetGrappleInput(InputAction.CallbackContext callbackContext)
    {
        grappleStarted = !callbackContext.canceled;
        grappleHeld = !callbackContext.canceled;
        if (InputManager.instance.isActiveAndEnabled)
        {
            StartCoroutine("ResetGrappleStart");
        } 
    }

    private IEnumerator ResetGrappleStart()
    {
        yield return new WaitForEndOfFrame();
        grappleStarted = false;
    }

    /*---------------------------------------Grab----------------------------------------------------*/

    [Header("Grab Input")]
    [Tooltip("Whether a grab was started this frame.")]
    public bool grabStarted = false;
    [Tooltip("Whether the jump button is being held.")]
    public bool grabHeld = false;

    public void GetGrabInput(InputAction.CallbackContext callbackContext)
    {
        grabStarted = !callbackContext.canceled;
        grabHeld = !callbackContext.canceled;
        if (InputManager.instance.isActiveAndEnabled)
        {
            StartCoroutine("ResetGrabStart");
        } 
    }

    private IEnumerator ResetGrabStart()
    {
        yield return new WaitForEndOfFrame();
        grabStarted = false;
    }

    /*-----------------------------------------Pause----------------------------------------------------*/

    [Header("Pause Input")]
    [Tooltip("The state of the pause button")]
    public float pauseButton = 0;


    public void GetPauseInput(InputAction.CallbackContext callbackContext)
    {
        pauseButton = callbackContext.ReadValue<float>();
    }

    /*-----------------------------------------Mouse----------------------------------------------------*/
    
    [Header("Mouse Input")]
    [Tooltip("The horizontal mouse input of the player.")]
    public float horizontalLookAxis;
    [Tooltip("The vertical mouse input of the player.")]
    public float verticalLookAxis;

    public void GetMouseLookInput(InputAction.CallbackContext callbackContext)
    {
        Vector2 mouseLookVector = callbackContext.ReadValue<Vector2>();
        horizontalLookAxis = mouseLookVector.x;
        verticalLookAxis = mouseLookVector.y;
    }   
}