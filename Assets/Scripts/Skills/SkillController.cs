using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {
    [SerializeField]
    private Skill[] skillsList;

    [SerializeField]
    private GameObject marcador;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        float skill01P1 = Input.GetAxisRaw("Skill01P1");
        float skill02P1 = Input.GetAxisRaw("Skill02P1");
        float skill03P1 = Input.GetAxisRaw("Skill03P1");

        float skill01P2 = Input.GetAxisRaw("Skill01P2");
        float skill02P2 = Input.GetAxisRaw("Skill02P2");
        float skill03P2 = Input.GetAxisRaw("Skill03P2");

        float switchP1 = Input.GetAxisRaw("SwitchP1");
        float switchP2 = Input.GetAxisRaw("SwitchP2");

        skill01P1 = skill01P1 != 0.0f ? skill01P1 : Input.GetAxisRaw("Skill01P1PC");
        skill02P1 = skill02P1 != 0.0f ? skill02P1 : Input.GetAxisRaw("Skill02P1PC");
        skill03P1 = skill03P1 != 0.0f ? skill03P1 : Input.GetAxisRaw("Skill03P1PC");
        skill01P2 = skill01P2 != 0.0f ? skill01P2 : Input.GetAxisRaw("Skill01P2PC");
        skill02P2 = skill02P2 != 0.0f ? skill02P2 : Input.GetAxisRaw("Skill02P2PC");
        skill03P2 = skill03P2 != 0.0f ? skill03P2 : Input.GetAxisRaw("Skill03P2PC");

        switchP1 = Input.GetAxisRaw("SwitchP1") != 0.0f ? switchP1 : Input.GetAxisRaw("SwitchP1PC");
        switchP2 = Input.GetAxisRaw("SwitchP2") != 0.0f ? switchP2 : Input.GetAxisRaw("SwitchP2PC");

        if (switchP1 == 1)
        {//transferir
            if (skill01P1 == 1 && skillsList[0].isActive() && skillsList[0].getPlayerID() == 1)
            {
                skillsList[0].setPlayerID(2);
            }
            if (skill02P1 == 1 && skillsList[1].isActive() && skillsList[1].getPlayerID() == 1)
            {
                skillsList[1].setPlayerID(2);
            }
          //  if (skill03P1 == 1 && skillsList[2].isActive() && skillsList[2].getPlayerID() == 1)
          //  {
          //      skillsList[2].setPlayerID(2);
          //  }
        }
        else
        {//usar
            if (skill01P1 == 1)
            {
                Debug.Log("Active "+skillsList[0].isActive());
                Debug.Log("ID " + skillsList[0].getPlayerID());
                Debug.Log("Time " + skillsList[0].elapseTime);
                if (skillsList[0].isActive() && skillsList[0].getPlayerID() == 1)
                {
                    skillsList[0].Execute();
                }               
            }
            if (skill02P1 == 1 && skillsList[1].isActive() && skillsList[1].getPlayerID() == 1)
            {
                skillsList[1].Execute();
            }
      //  if (skill03P1 == 1 && skillsList[2].isActive() && skillsList[2].getPlayerID() == 1)
      //  {
      //      skillsList[2].Execute(Time.deltaTime);
      //  }
        }

        if (switchP2 == 1)
        {//pasar
            if (skill01P2 == 1 && skillsList[0].isActive() && skillsList[0].getPlayerID() == 2)
            {
                skillsList[0].setPlayerID(1);
            } 
            if (skill02P2 == 1 && skillsList[1].isActive() && skillsList[1].getPlayerID() == 2)
            {
                skillsList[1].setPlayerID(1);
            }
           //if (skill03P2 == 1 && skillsList[2].isActive() && skillsList[2].getPlayerID() == 2)
           //{
           //    skillsList[2].setPlayerID(2);
           //}
        }
        else
        {//usar
            if (skill01P2 == 1 && skillsList[0].isActive() && skillsList[0].getPlayerID() == 2)
            {
                skillsList[0].Execute();
            }
            if (skill02P2 == 1 && skillsList[1].isActive() && skillsList[1].getPlayerID() == 2)
            {
                skillsList[1].Execute();
            }
          //  if (skill03P2 == 1 && skillsList[2].isActive() && skillsList[2].getPlayerID() == 2)
          //  {
          //      skillsList[2].Execute(Time.deltaTime);
          //  }
        }

       //Debug.Log("skill01P1 " + skill01P1);
       //Debug.Log("skill02P1 " + skill02P1);
       //Debug.Log("skill03P1 " + skill03P1);
       //Debug.Log("skill01P2 " + skill01P2);
       //Debug.Log("skill02P2 " + skill02P2);
       //Debug.Log("skill03P2 " + skill03P2);
       //Debug.Log("switchP1 " + switchP1);
       //Debug.Log("switchP2 " + switchP2);
    }
}
