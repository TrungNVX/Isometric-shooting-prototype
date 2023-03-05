using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IngameUI : BYSingleton<IngameUI>
{
    private Vector3 delta_Mouse;
    private Vector3 old_Mouse;
    public RectTransform btnFire;
    public Text amo_lb;
    public Image gun_icon;
    private WeaponControl weaponControl;
    private WeaponBehaviour current_WP;
    public Image hpProgress;
    public Text hp_LB;
    public RectTransform parentHub;
    public RectTransform parentMissionInfo;
    // Start is called before the first frame update
    void Start()
    {
        weaponControl = GameObject.FindObjectOfType<WeaponControl>();
        weaponControl.OnchangeGun += WeaponControl_OnchangeGun;
    
    }

   

    private void WeaponControl_OnchangeGun(WeaponBehaviour obj)
    {
        if (current_WP != null)
            current_WP.OnAmoChange -= Current_WP_OnAmoChange;
        current_WP = obj;
        gun_icon.overrideSprite = SpriteLiblaryControl.instance.GetSprirteByName(current_WP.weaponData.cf.Weapon_id);
        SetAmo(current_WP.numberBullet, current_WP.clip_size);
        current_WP.OnAmoChange += Current_WP_OnAmoChange;
    }

    private void Current_WP_OnAmoChange(int arg1, int arg2)
    {
        SetAmo(arg1, arg2);
    }

    private void SetAmo(int num, int total)
    {
        if (num > total * 0.25f)
        {
            amo_lb.text = num.ToString() + "/" + total.ToString();

        }
        else
        {
            amo_lb.text = "<color=red>" + num.ToString() + "</color>/" + total.ToString();
        }

    }
    // Update is called once per frame
    void Update()
    {
        delta_Mouse = Vector3.zero;
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                old_Mouse = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                delta_Mouse = Input.mousePosition - old_Mouse;
                old_Mouse = Input.mousePosition;

            }
            else if (Input.GetMouseButtonUp(0))
            {
                old_Mouse = Vector3.zero;
            }
        }

        FirstControlInput.instance.OnLookInput(delta_Mouse);
    }
    public void OnJump()
    {
        FirstControlInput.instance.OnJumpInput(true);
    }
    public void OnFire(bool isFire)
    {

        btnFire.localScale = isFire ? Vector3.one * 0.8f : Vector3.one;
        FirstControlInput.instance.OnFireInput(isFire);
    }
    public void OnHPChange(int hp,int maxHP)
    {
        hp_LB.text = hp.ToString() + "/" + maxHP.ToString();
        hpProgress.fillAmount = (float)hp / (float)maxHP;
    }
    public void OnPause()
    {
        DialogManager.instance.ShowDialog(DialogIndex.PauseDialog);
    }
}
