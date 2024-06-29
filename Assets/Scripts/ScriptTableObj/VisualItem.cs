using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ScripeTableObject/VisualItem")]
public class VisualItem : ScriptableObject
{

   public List<NormalVisual> normalVisual = new List<NormalVisual>();
   public List<BonusVisual> bonusVisual = new List<BonusVisual>();


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
}
[Serializable]
public class BonusVisual
{
    public BonusItem.eBonusType eBonusType;
    public Sprite bonusSprite;
}
