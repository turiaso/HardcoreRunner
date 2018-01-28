using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    [SerializeField]
    public Skill[] skillsList;
    private List<GUISkillMarcadorScriptInfo> skillMarquers;
    [SerializeField]
    private GUISkillMarcadorScript marcador;

    // Use this for initialization

    void Start()
    {
        skillMarquers = marcador.skillIndicator;

        skillMarquers[0].list[2].SetActive(false);
        skillMarquers[1].list[2].SetActive(false);
        skillMarquers[2].list[2].SetActive(false);

        /*
        Transform[] ts = marcador.GetComponentsInChildren<Transform>();
        if (ts != null)
        {
            int i = 0;
            foreach (Transform t in ts)
            {
                if (t != null && t.parent.GetComponentInChildren<Image>() != null && i > 0)
                    skillMarquers.Add(t);
                i++;
            }
        }
        */

    }


    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        skillsList[2].Active(deltaTime);
        //reactivamos los controles
        if (skillsList[0].isActive())
        {
            if (skillsList[0].getPlayerID() == 1)
            {
                skillMarquers[0].list[0].SetActive(true);
                skillMarquers[0].list[1].SetActive(false);
            }
            else
            {
                skillMarquers[0].list[0].SetActive(false);
                skillMarquers[0].list[1].SetActive(true);
            }
        }

        if (skillsList[1].isActive())
        {
            if (skillsList[1].getPlayerID() == 1)
            {
                skillMarquers[1].list[0].SetActive(true);
                skillMarquers[1].list[1].SetActive(false);
            }
            else
            {
                skillMarquers[1].list[0].SetActive(false);
                skillMarquers[1].list[1].SetActive(true);
            }
        }

        if (skillsList[2].isActive())
        {
            if (skillsList[2].getPlayerID() == 1)
            {
                skillMarquers[2].list[0].SetActive(true);
                skillMarquers[2].list[1].SetActive(false);
            }
            else
            {
                skillMarquers[2].list[0].SetActive(false);
                skillMarquers[2].list[1].SetActive(true);
            }
        }
        else
        {

        }

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
                skillMarquers[0].list[0].SetActive(false);
                skillMarquers[0].list[1].SetActive(true);
            }
            if (skill02P1 == 1 && skillsList[1].isActive() && skillsList[1].getPlayerID() == 1)
            {
                skillsList[1].setPlayerID(2);
                skillMarquers[2].list[0].SetActive(false);
                skillMarquers[2].list[1].SetActive(true);
            }

            if (skill03P1 == 1 && skillsList[2].isActive() && skillsList[2].getPlayerID() == 1)
            {
                skillsList[2].setPlayerID(2);
                skillMarquers[2].list[0].SetActive(false);
                skillMarquers[2].list[1].SetActive(true);
            }
        }

        else
        {//usar
            if (skill01P1 == 1)
            {
                if (skillsList[0].isActive() && skillsList[0].getPlayerID() == 1)
                {
                    skillsList[0].Execute(deltaTime);
                    StartCoroutine(FadeOutIn(skillMarquers[0].list[2], skillsList[0].coolDown));
                }
            }
            if (skill02P1 == 1 && skillsList[1].isActive() && skillsList[1].getPlayerID() == 1)
            {
                if (skillsList[1].isActive() && skillsList[0].getPlayerID() == 1)
                {
                    skillsList[1].Execute(deltaTime);
                    StartCoroutine(FadeOutIn(skillMarquers[1].list[2], skillsList[1].coolDown));
                }
            }
            if (skill03P1 == 1 && skillsList[2].isActive() && skillsList[2].getPlayerID() == 1)
            {
                skillsList[2].Execute(deltaTime);
                StartCoroutine(FadeOutIn(skillMarquers[2].list[2], skillsList[2].coolDown));


            }
        }

        if (switchP2 == 1)
        {//transferir
            if (skill01P2 == 1 && skillsList[0].isActive() && skillsList[0].getPlayerID() == 2)
            {
                skillsList[0].setPlayerID(1);
                skillMarquers[0].list[0].SetActive(true);
                skillMarquers[0].list[1].SetActive(false);
            }
            if (skill02P2 == 1 && skillsList[1].isActive() && skillsList[1].getPlayerID() == 2)
            {
                skillsList[1].setPlayerID(1);
                skillMarquers[1].list[0].SetActive(true);
                skillMarquers[1].list[1].SetActive(false);
            }
            if (skill03P2 == 1 && skillsList[2].isActive() && skillsList[2].getPlayerID() == 2)
            {
                skillsList[2].setPlayerID(2);
                skillMarquers[2].list[0].SetActive(true);
                skillMarquers[2].list[1].SetActive(false);
            }
        }
        else
        {//usar
            if (skill01P2 == 1 && skillsList[0].isActive() && skillsList[0].getPlayerID() == 2)
            {
                skillsList[0].Execute(deltaTime);
                StartCoroutine(FadeOutIn(skillMarquers[0].list[2], skillsList[0].coolDown));
            }
            if (skill02P2 == 1 && skillsList[1].isActive() && skillsList[1].getPlayerID() == 2)
            {
                skillsList[1].Execute(deltaTime);
                StartCoroutine(FadeOutIn(skillMarquers[1].list[2], skillsList[1].coolDown));
            }
            if (skill03P2 == 1 && skillsList[2].isActive() && skillsList[2].getPlayerID() == 2)
            {

                skillsList[2].Execute(deltaTime);
                StartCoroutine(FadeOutIn(skillMarquers[2].list[2], skillsList[2].coolDown));
            }
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

    private IEnumerator FadeOutIn(GameObject gameObject, float coolDown)
    {
        gameObject.SetActive(true);

        Image image = gameObject.GetComponent<Image>();
        float timestamp = 0;
        while (timestamp < coolDown)
        {
            timestamp += Time.deltaTime;

            image.fillAmount = Mathf.Lerp(1, 0, timestamp / coolDown);
            yield return 0;
        }
    }
}
