using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCollectItem : MonoBehaviour
{
    public MissionCollect missionCollect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            missionCollect.CollectItem(this);
        }
    }
    // Start is called before the first frame update

}
