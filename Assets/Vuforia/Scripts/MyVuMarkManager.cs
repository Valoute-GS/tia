using UnityEngine;
using Vuforia;
using System.Collections.Generic;

public class MyVuMarkManager : MonoBehaviour
{
    List<VuMarkBehaviour> registeredBehaviours = new List<VuMarkBehaviour>();

    // GameObject associated with each Vumark 
    public GameObject mainBasePrefab;
    GameObject mainBase;

    public GameObject mainBasePrefab2;
    GameObject mainBase2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        //Increase the number of targets that can be detected simulateously
        VuforiaConfiguration.Instance.Vuforia.MaxSimultaneousImageTargets = 10;
        VuMarkManager vumarkManager = TrackerManager.
        Instance.GetStateManager().GetVuMarkManager();
        //Register the method managing the appearance of new VuMarkBehaviours
        vumarkManager.RegisterVuMarkBehaviourDetectedCallback(OnVuMarkBehaviourFound);
    }

    private void OnVuMarkBehaviourFound(VuMarkBehaviour pVuMarkBehaviour)
    {

        //if we hadn't registered yet, we do so now
        registeredBehaviours.Add(pVuMarkBehaviour);

        pVuMarkBehaviour.RegisterVuMarkTargetAssignedCallback(
            () => OnVuMarkTargetAssigned(pVuMarkBehaviour)
        );
        
    }

    private void OnVuMarkTargetAssigned(VuMarkBehaviour pVuMarkBehaviour)
    {
        string myID = GetID(pVuMarkBehaviour.VuMarkTarget.InstanceId);
        
        foreach (Transform child in pVuMarkBehaviour.transform)
        {
            child.gameObject.SetActive(myID.Contains(child.name.Substring(0,1)));
        }
    }

    public int IDLength = 2;

    /**
     * Helper method to sanitize the returned ID's
     */
    private string GetID(InstanceId pInstanceId)
    {
        int inputLength = pInstanceId.StringValue.Length;
        int outputLength = Mathf.Min(IDLength, inputLength);
        string subString = pInstanceId.StringValue.Substring(0, outputLength);
        return subString;
    }

}
