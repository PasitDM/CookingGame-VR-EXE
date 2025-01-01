using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[Header("Renderer Material")]

	public SkinnedMeshRenderer MainRender;
	public SkinnedMeshRenderer MainRender_1;
	public SkinnedMeshRenderer MainRender_2;
	public SkinnedMeshRenderer FaceRender;
	public Material[] CostumeMaterial;
	public Material[] FaceMaterial;

	[Header("GameObject")]

	public GameObject[] WaponObject;
	public GameObject[] AccessoryObject;

	public GameObject WaponPivot;
	public GameObject RightHandPivot;
	public GameObject LeftHandpivot;

	public GameObject EarObject;

	public GameObject Sunglass;
	public GameObject Bag;

	[Header("Animator")]

	public Animator MainAnimator;
	public AnimatorClipInfo[] MainAnimatorInfo;
	private string NowAnimationName;

	[Header("UI")]

	public Dropdown CostumeDropdown;
	public Dropdown WeaponDropdown;
	public Dropdown AnimationDropdown;
	public Dropdown AccessoryDropdown;
	public Dropdown FaceDropdown;

	public Text CostumeText;
	public Text AnimationText;

	//[Header("Weapon Active Bool")]

	//public bool[] Animation_Weapon_Active;


	//private void Start()
	//{
	//	for (int i = 0; i < 15; i++)
	//	{
	//		Animation_Weapon_Active[i] = true;
	//	}
	//}

	private void Update()
	{
		MainAnimatorInfo = MainAnimator.GetCurrentAnimatorClipInfo(0);

		NowAnimationName = MainAnimatorInfo[0].clip.name;

		AnimationText.text = "" + NowAnimationName;

		CostumeText.text = "SD " + CostumeDropdown.value.ToString() + " Costume";

		//Debug.Log(AccessoryDropdown.value);

	//	if (Input.GetKeyDown(KeyCode.Q))
	//	{
	//		CostumeDropdown.value += 1;

	//		if (CostumeDropdown.value == 51)
	//			CostumeDropdown.value = 1;

	//		Costume_Dropdown_Change();
	//	}

	//	if (Input.GetKeyDown(KeyCode.A))
	//	{
	//		AnimationDropdown.value += 1;

	//		if (AnimationDropdown.value == 16)
	//			AnimationDropdown.value = 1;

	//		Aanimation_Dropdown_Change();
	//	}

	//	if (Input.GetKeyDown(KeyCode.Z))
	//	{

	//		FaceDropdown.value += 1;

	//		if (FaceDropdown.value == 71)
	//			FaceDropdown.value = 1;

	//		Face_Dropdown_Change();
	//	}

	//	if (Input.GetKeyDown(KeyCode.W))
	//	{

	//		WeaponDropdown.value += 1;

	//		if (WeaponDropdown.value == 11)
	//			WeaponDropdown.value = 1;


	//		Weapon_Dropdown_Change();
	//	}

	//	if (Input.GetKeyDown(KeyCode.S))
	//	{
	//		AccessoryDropdown.value += 1;

	//		if (AccessoryDropdown.value == 8)
	//			AccessoryDropdown.value = 1;

	//	}

	//	if(Input.GetKeyDown(KeyCode.X))
	//	{
	//		if (Bag.activeInHierarchy)
	//			Bag.SetActive(false);
	//		else
	//			Bag.SetActive(true);
	//	}

	//	if(Input.GetKeyDown(KeyCode.C))
	//	{
	//		if (Sunglass.activeInHierarchy)
	//			Sunglass.SetActive(false);
	//		else
	//			Sunglass.SetActive(true);
	//	}
	}

	public void Costume_Dropdown_Change()
	{
		if (CostumeDropdown.value < 51 && CostumeDropdown.value != 0)
		{
            
			MainRender.material = CostumeMaterial[CostumeDropdown.value - 1];
			MainRender_1.material = CostumeMaterial[CostumeDropdown.value - 1];
			MainRender_2.material = CostumeMaterial[CostumeDropdown.value - 1];
		}
	}

	public void Face_Dropdown_Change()
	{
		if (FaceDropdown.value < 71 && FaceDropdown.value != 0)
			FaceRender.material = FaceMaterial[FaceDropdown.value - 1];
	}

    public void Aanimation_Dropdown_Change()
    {
        if (AnimationDropdown.value < 18 && AnimationDropdown.value != 0)
        {
            if (AnimationDropdown.value == 5)
            {
                WaponPivot.transform.parent = LeftHandpivot.transform;

                WaponPivot.transform.localPosition = new Vector3(-0.176f, -0.032f, -0.01f);
                WaponPivot.transform.localRotation = Quaternion.Euler(-5.695f, 50.875f, 4.199f);
            }
            else
            {
                WaponPivot.transform.parent = RightHandPivot.transform;

                WaponPivot.transform.localPosition = new Vector3(-0.1559592f, -0.03524534f, 0.1734445f);
                WaponPivot.transform.localRotation = Quaternion.Euler(-5.953f, -89.965f, 0.198f);

            }
            int a = AnimationDropdown.value;

            if (a == 1 || a == 6 || a == 7 || a == 11 || a == 12 || a == 13 || a == 14)
            {
                for (int j = 0; j < 10; j++)
                {
                    WaponObject[j].SetActive(false);
                }
            }

            // 1,6,7,11,12,13,14 

            for (int i = 1; i < 16; i++)
            {
                MainAnimator.SetBool(i.ToString(), false);

            //    if (i == 1 || i == 6 || i == 7 || i == 11 || i == 12 || i == 13 || i == 14)
            //    {
            //        for (int j = 0; j < 10; j++)
            //        {
                       // WaponObject[i].SetActive(false);
            //        }
            //    }
            //    //if (Animation_Weapon_Active[i - 1] == false)
            //    //{
            //    //    for (int j = 0; j < 10; j++)
            //    //    {
            //    //        WaponObject[j].SetActive(false);
            //    //    }
            //    //}
            }

            MainAnimator.SetBool(AnimationDropdown.value.ToString(), true);
        }

    }

    public void Weapon_Dropdown_Change()
	{
		if (WeaponDropdown.value < 11 && WeaponDropdown.value != 0)
		{
			for (int i = 0; i < 10; i++)
			{
				WaponObject[i].SetActive(false);
			}

			WaponObject[WeaponDropdown.value - 1].SetActive(true);
		}
	}

	public void Accessory_CapDropdown_Change()
	{
		if (AccessoryDropdown.value < 8 && AccessoryDropdown.value != 0)
		{
			if (AccessoryDropdown.value == 1)
				EarObject.SetActive(false);
			else
				EarObject.SetActive(true);


			for (int i = 0; i < 7; i++)
			{
				AccessoryObject[i].SetActive(false);
			}

			AccessoryObject[AccessoryDropdown.value - 1].SetActive(true);


		}
	}
}