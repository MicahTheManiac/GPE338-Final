using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LayerManager : MonoBehaviour
{
    public GameObject layerMainMenu;
    public GameObject layerLevelSelect;
    public GameObject layerCredits; // OPTIONS LAYER
    public GameObject sublayerLevelSelectWarning;
    public GameObject sublayerOptionsMouseSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        LayerActivateMainMenu();
    }

    public void LayerDeactivateAll()
    {
        layerMainMenu.SetActive(false);
        layerLevelSelect.SetActive(false);
        layerCredits.SetActive(false);
    }

    public void LayerActivateMainMenu()
    {
        LayerDeactivateAll();
        layerMainMenu.SetActive(true);
    }

    public void LayerActivateLevelSelect()
    {
        LayerDeactivateAll();
        layerLevelSelect.SetActive(true);
        sublayerLevelSelectWarning.SetActive(false);
    }

    // OPTIONS LAYER
    public void LayerActivateCredits()
    {
        LayerDeactivateAll();
        layerCredits.SetActive(true);
        sublayerOptionsMouseSensitivity.SetActive(false);
    }

    public void SublayerActivateLevelSelectWarning()
    {
        sublayerLevelSelectWarning.SetActive(true);
    }

    public void SublayerActivateOptionsMouseSensitivity()
    {
        sublayerOptionsMouseSensitivity.SetActive(true);
    }
}
