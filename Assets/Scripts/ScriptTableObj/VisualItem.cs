using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static NormalItem;

[CreateAssetMenu(menuName = "ScripeTableObject/VisualItem")]
public class VisualItem : ScriptableObject
{

   public List<NormalVisual> normalVisual = new List<NormalVisual>();
   public List<BonusVisual> bonusVisual = new List<BonusVisual>();
 


    public void UpNumber( NormalItem.eNormalType eNormalType)
    {
        for(int i =0;i<normalVisual.Count;i++)
        {
            if (normalVisual[i].eNormalType == eNormalType)
            {
               
                    normalVisual[i].count++;
               
            }
            
        }
    }
    public void DownNumber(Sprite nameSprite)
    {
        for (int i = 0; i < normalVisual.Count; i++)
        {
            if (normalVisual[i].normalSprite == nameSprite)
            {
                if (normalVisual[i].count > 0)
                {
                    normalVisual[i].count--;
                }
            }

        }
    }
    
    public List<NormalVisual> GetMinNormalCount()
    {
        var listmin = normalVisual.OrderBy(x=>x.count).Take(5).ToList();   
        return listmin;

    }
   
    public void CleanCountNormal()
    {
        for (int i = 0; i < normalVisual.Count; i++)
        {
            normalVisual[i].count = 0;

        }
    }

    //public NormalItem.eNormalType GetTypeMinNormal(List<>)
    //{

    //}

    public Sprite  GetSpriteNormalItem(NormalItem.eNormalType normalType)
    {
        for(int i=0; i < normalVisual.Count; i++)
        {
            if (normalVisual[i].eNormalType == normalType)
            {
                if (normalVisual[i].normalSprite != null)
                {
                    return normalVisual[i].normalSprite;
                }
            }
        }
        return null;
    }
    public Sprite GetSpriteBonusItem(BonusItem.eBonusType bonusType)
    {
        for (int i = 0; i < bonusVisual.Count; i++)
        {
            if (bonusVisual[i].eBonusType == bonusType)
            {
                if (bonusVisual[i].bonusSprite != null)
                {
                    return bonusVisual[i].bonusSprite;
                }
            }
        }
        return null;
    }
}
[Serializable]
public class NormalVisual
{
    public  NormalItem.eNormalType eNormalType;
    public Sprite normalSprite;
    [HideInInspector]
    public int count =0;
}
[Serializable]
public class BonusVisual
{
    public BonusItem.eBonusType eBonusType;
    public Sprite bonusSprite;
}
