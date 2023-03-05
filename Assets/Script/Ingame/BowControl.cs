using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowControl : MonoBehaviour
{
    private bool isFire;
    private bool isFireAim;
    public CharacterDataBinding dataBinding;
    // Start is called before the first frame update
    void Start()
    {
        FirstControlInput.instance.OnFireEvent += OnFireEvent;
    }

    private void OnFireEvent(bool isFire)
    {
        if (isFireAim)
        {
            // fire 
            isFireAim = false;
            dataBinding.Isfire = true;
        }
        else
        {
            if (this.isFire == false)
            {
                isFireAim = true;
            }

        }

        this.isFire = isFire;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
