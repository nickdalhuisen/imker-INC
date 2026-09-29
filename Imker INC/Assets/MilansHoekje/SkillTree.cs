using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public List<SkillRoads> skillTypes;
    [SerializeField] private GameObject SkillButton;
    [SerializeField] private float offset = 1.34f; 
    void Start()
    {
        for (int i = 0; i < skillTypes.Count; i++)
        {
            for (int l = 0; l < skillTypes[i].skills.Count; l++)
            {

                GameObject tempSkill = Instantiate(SkillButton, new Vector3(transform.position.x + l * offset, transform.position.y, 0), quaternion.identity, transform);
                if (skillTypes[l + 1] != null)
                {

                    // lineRenderer.SetPosition(0, pointA.position);
                    // lineRenderer.SetPosition(1, pointB.position);
                }
            }
        }
    }
}

[Serializable]
public class SkillRoads
{
    public string name;    
    public List<Skill> skills;
}
