using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneConfig : BYSingleton<SceneConfig>
{
    public List<Transform> ES_points;
    // Start is called before the first frame update
   public Transform GetRandomPointES()
    {
        return ES_points[0];
        //return ES_points.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
    }
}
