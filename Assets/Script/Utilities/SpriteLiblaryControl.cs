using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLiblaryControl : BYSingleton<SpriteLiblaryControl>
{
    [SerializeField]
    private List<Sprite> sprites_ls;
    public Dictionary<string, Sprite> dic_Sprite = new Dictionary<string, Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Sprite sp in sprites_ls)
        {
            dic_Sprite.Add(sp.name, sp);
        }
    }

    // Update is called once per frame
    public Sprite GetSprirteByName(string name_)
    {
        return dic_Sprite[name_];
    }
}
