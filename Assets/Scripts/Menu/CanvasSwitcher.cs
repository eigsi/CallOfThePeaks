using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas canvasToHide; // Le Canvas à désactiver
    public Canvas canvasToShow; // Le Canvas à activer

    public void SwitchCanvas()
    {
        if (canvasToHide != null)
        {
            canvasToHide.gameObject.SetActive(false);
        }

        if (canvasToShow != null)
        {
            canvasToShow.gameObject.SetActive(true);
        }
    }
}
