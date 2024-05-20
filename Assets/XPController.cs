using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class XPController : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI LevelText;
    [SerializeField]private TextMeshProUGUI ExpercienceText;
    [SerializeField]private int Level;
    private float CurrentXp;
    [SerializeField]private float TargetXP;
    [SerializeField]private Image XpProgressBar;

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CurrentXp += 12;
        }

        ExpercienceText.text = CurrentXp + " / " + TargetXP;

        ExperienceController();
    }

    public void ExperienceController()
    {
        LevelText.text = "Level : " + Level.ToString();
        XpProgressBar.fillAmount = (CurrentXp / TargetXP );

        if(CurrentXp >= TargetXP)
        {
            CurrentXp = CurrentXp - TargetXP;
            Level++;
            TargetXP += 50;
        }
    }

}
