using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    public GameObject layerMainMenu;
    public GameObject layerLevelSelect;
    public GameObject layerCredits;
    public GameObject sublayerLevelSelectWarning;

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

    public void LayerActivateCredits()
    {
        LayerDeactivateAll();
        layerCredits.SetActive(true);
    }

    public void SublayerActivateLevelSelectWarning()
    {
        sublayerLevelSelectWarning.SetActive(true);
    }
}
