using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class OurHand : MonoBehaviour
{
    // Public Values to set in Unity, Private use only in script
    public GameObject ourHandPrefab;
    public InputDeviceCharacteristics ourControllerCharacteristics;

    private InputDevice ourDevice;
    //Start is called before the first frame update
    void Start()
    {
        InitializeOurHand();
    }

    // Update is called once per frame
    void InitializeOurHand()
    {
        //check for our controllercharacteristics
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ourControllerCharacteristics, devices);
        
        //If device identified, instantiate a Hand
        if (devices.Count > 0)
        {
            ourDevice = devices[0];

            GameObject newHand = Instantiate(ourHandPrefab, transform);
        }
    }

    void UpdateOurHand()
    {
        if (ourDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            Debug.Log("Trigger Value =" + triggerValue);
        }
        else 
        {
            Debug.Log("Trigger not Active");
        }
        if (ourDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            Debug.Log("grip Value =" + gripValue);
        }
        else
        {
            Debug.Log("grip Value not Active");
        }
    }

}
