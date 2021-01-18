using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LapManager : MonoBehaviour
{
    public GameObject EndPanel;
    public Text time1,time2,time3,time4;
    public Text pos1,pos2,pos3,pos4;
    public Text m1;
    public Text m2;
    public Text m3;
    public Text m4;
    public static int Lap;
    public static int Lap2;
    public static int Lap3;
    public static int Lap4;
    // Start is called before the first frame update
    void Start()
    {
        Lap=1;
        Lap2=1;
        Lap3=1;
        Lap4=1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Lap<=3)
            m1.text = "Lap : " + Lap + " / 3";
        else
            m1.text = "Finish";
        if (Lap2<=3)
            m2.text = "Lap : " + Lap2 + " / 3";
        else
            m2.text = "Finish"; 
        if (Lap3<=3)
            m3.text = "Lap : " + Lap3 + " / 3";
        else
            m3.text = "Finish";
        if (Lap4<=3)
            m4.text = "Lap : " + Lap4 + " / 3";
        else
            m4.text = "Finish";  
        if(SceneManager.GetActiveScene().name=="2")
        {
            if(Lap>3&&Lap2>3)
            {
                EndPanel.SetActive(true);
            }
        }
        else if(SceneManager.GetActiveScene().name=="3")
        {
            if(Lap>3&&Lap2>3&&Lap3>3)
            {
                EndPanel.SetActive(true);
            }
        }
        else if(SceneManager.GetActiveScene().name=="4")
        {
            if(Lap>3&&Lap2>3&&Lap3>3&&Lap4>3)
            {
                EndPanel.SetActive(true);
            }
        }

        if(TimeManager.TotalTime<TimeManager2.TotalTime&&TimeManager.TotalTime<TimeManager3.TotalTime&&TimeManager.TotalTime<TimeManager4.TotalTime)
        {
            time1.text = TimeManager.TotalTime.ToString("f2");
            pos1.text = "Player 1 ";
            if(TimeManager2.TotalTime<TimeManager3.TotalTime&&TimeManager2.TotalTime<TimeManager4.TotalTime)
            {
                time2.text = TimeManager2.TotalTime.ToString("f2");
                pos2.text = "Player 2 ";
                if(TimeManager3.TotalTime<TimeManager4.TotalTime)
                {
                    time3.text = TimeManager3.TotalTime.ToString("f2");
                    pos3.text = "Player 3 "; 
                    time4.text = TimeManager4.TotalTime.ToString("f2");
                    pos4.text = "Player 4 "; 
                }
                else{
                    time3.text = TimeManager4.TotalTime.ToString("f2");
                    pos3.text = "Player 4 "; 
                    time4.text = TimeManager3.TotalTime.ToString("f2");
                    pos4.text = "Player 3 "; 
                }
            }
            else if(TimeManager3.TotalTime<TimeManager2.TotalTime&&TimeManager3.TotalTime<TimeManager4.TotalTime)
            {
                time2.text = TimeManager3.TotalTime.ToString("f2");
                pos2.text = "Player 3 ";
                if(TimeManager2.TotalTime<TimeManager4.TotalTime)
                {
                    time3.text = TimeManager2.TotalTime.ToString("f2");
                    pos3.text = "Player 2 "; 
                    time4.text = TimeManager4.TotalTime.ToString("f2");
                    pos4.text = "Player 4 "; 
                }
                else{
                    time3.text = TimeManager4.TotalTime.ToString("f2");
                    pos3.text = "Player 4 "; 
                    time4.text = TimeManager2.TotalTime.ToString("f2");
                    pos4.text = "Player 2 "; 
                }
            }
            else if(TimeManager4.TotalTime<TimeManager2.TotalTime&&TimeManager4.TotalTime<TimeManager3.TotalTime)
            {
                time2.text = TimeManager4.TotalTime.ToString("f2");
                pos2.text = "Player 4 ";
                if(TimeManager2.TotalTime<TimeManager3.TotalTime)
                {
                    time3.text = TimeManager2.TotalTime.ToString("f2");
                    pos3.text = "Player 2 "; 
                    time4.text = TimeManager3.TotalTime.ToString("f2");
                    pos4.text = "Player 3 "; 
                }
                else{
                    time3.text = TimeManager3.TotalTime.ToString("f2");
                    pos3.text = "Player 3 "; 
                    time4.text = TimeManager2.TotalTime.ToString("f2");
                    pos4.text = "Player 2 "; 
                }
            }
        }
        else if(TimeManager2.TotalTime<TimeManager.TotalTime&&TimeManager2.TotalTime<TimeManager3.TotalTime&&TimeManager2.TotalTime<TimeManager4.TotalTime)
        {
            time1.text = TimeManager2.TotalTime.ToString("f2");
            pos1.text = "Player 2 ";
            if(TimeManager.TotalTime<TimeManager3.TotalTime&&TimeManager.TotalTime<TimeManager4.TotalTime)
            {
                time2.text = TimeManager.TotalTime.ToString("f2");
                pos2.text = "Player 1 ";
                if(TimeManager3.TotalTime<TimeManager4.TotalTime)
                {
                    time3.text = TimeManager3.TotalTime.ToString("f2");
                    pos3.text = "Player 3 "; 
                    time4.text = TimeManager4.TotalTime.ToString("f2");
                    pos4.text = "Player 4 "; 
                }
                else{
                    time3.text = TimeManager4.TotalTime.ToString("f2");
                    pos3.text = "Player 4 "; 
                    time4.text = TimeManager3.TotalTime.ToString("f2");
                    pos4.text = "Player 3 "; 
                }
            }
            else if(TimeManager3.TotalTime<TimeManager.TotalTime&&TimeManager3.TotalTime<TimeManager4.TotalTime)
            {
                time2.text = TimeManager3.TotalTime.ToString("f2");
                pos2.text = "Player 3 ";
                if(TimeManager.TotalTime<TimeManager4.TotalTime)
                {
                    time3.text = TimeManager.TotalTime.ToString("f2");
                    pos3.text = "Player 1 "; 
                    time4.text = TimeManager4.TotalTime.ToString("f2");
                    pos4.text = "Player 4 "; 
                }
                else{
                    time3.text = TimeManager4.TotalTime.ToString("f2");
                    pos3.text = "Player 4 "; 
                    time4.text = TimeManager.TotalTime.ToString("f2");
                    pos4.text = "Player 1 "; 
                }
            }
            else if(TimeManager4.TotalTime<TimeManager.TotalTime&&TimeManager4.TotalTime<TimeManager3.TotalTime)
            {
                time2.text = TimeManager4.TotalTime.ToString("f2");
                pos2.text = "Player 4 ";
                if(TimeManager.TotalTime<TimeManager3.TotalTime)
                {
                    time3.text = TimeManager.TotalTime.ToString("f2");
                    pos3.text = "Player 1 "; 
                    time4.text = TimeManager3.TotalTime.ToString("f2");
                    pos4.text = "Player 3 "; 
                }
                else{
                    time3.text = TimeManager3.TotalTime.ToString("f2");
                    pos3.text = "Player 3 "; 
                    time4.text = TimeManager.TotalTime.ToString("f2");
                    pos4.text = "Player 1 "; 
                }
            }
        } 
        else if(TimeManager3.TotalTime<TimeManager.TotalTime&&TimeManager3.TotalTime<TimeManager2.TotalTime&&TimeManager3.TotalTime<TimeManager4.TotalTime)
        {
            time1.text = TimeManager3.TotalTime.ToString("f2");
            pos1.text = "Player 3 ";
            if(TimeManager.TotalTime<TimeManager2.TotalTime&&TimeManager.TotalTime<TimeManager4.TotalTime)
            {
                time2.text = TimeManager.TotalTime.ToString("f2");
                pos2.text = "Player 1 ";
                if(TimeManager2.TotalTime<TimeManager4.TotalTime)
                {
                    time3.text = TimeManager2.TotalTime.ToString("f2");
                    pos3.text = "Player 2 "; 
                    time4.text = TimeManager4.TotalTime.ToString("f2");
                    pos4.text = "Player 4 "; 
                }
                else{
                    time3.text = TimeManager4.TotalTime.ToString("f2");
                    pos3.text = "Player 4 "; 
                    time4.text = TimeManager2.TotalTime.ToString("f0");
                    pos4.text = "Player 2 "; 
                }
            }
            else if(TimeManager2.TotalTime<TimeManager.TotalTime&&TimeManager2.TotalTime<TimeManager4.TotalTime)
            {
                time2.text = TimeManager2.TotalTime.ToString("f2");
                pos2.text = "Player 2 ";
                if(TimeManager.TotalTime<TimeManager4.TotalTime)
                {
                    time3.text = TimeManager.TotalTime.ToString("f2");
                    pos3.text = "Player 1 "; 
                    time4.text = TimeManager4.TotalTime.ToString("f2");
                    pos4.text = "Player 4 "; 
                }
                else{
                    time3.text = TimeManager4.TotalTime.ToString("f2");
                    pos3.text = "Player 4 "; 
                    time4.text = TimeManager.TotalTime.ToString("f2");
                    pos4.text = "Player 1 "; 
                }
            }
            else if(TimeManager4.TotalTime<TimeManager.TotalTime&&TimeManager4.TotalTime<TimeManager2.TotalTime)
            {
                time2.text = TimeManager4.TotalTime.ToString("f2");
                pos2.text = "Player 4 ";
                if(TimeManager.TotalTime<TimeManager2.TotalTime)
                {
                    time3.text = TimeManager.TotalTime.ToString("f2");
                    pos3.text = "Player 1 "; 
                    time4.text = TimeManager2.TotalTime.ToString("f2");
                    pos4.text = "Player 2 "; 
                }
                else{
                    time3.text = TimeManager2.TotalTime.ToString("f2");
                    pos3.text = "Player 2 "; 
                    time4.text = TimeManager.TotalTime.ToString("f2");
                    pos4.text = "Player 1 "; 
                }
            }
        }  
        else if(TimeManager4.TotalTime<TimeManager.TotalTime&&TimeManager4.TotalTime<TimeManager3.TotalTime&&TimeManager4.TotalTime<TimeManager2.TotalTime)
        {
            time1.text = TimeManager4.TotalTime.ToString("f2");
            pos1.text = "Player 4 ";
            if(TimeManager.TotalTime<TimeManager2.TotalTime&&TimeManager.TotalTime<TimeManager3.TotalTime)
            {
                time2.text = TimeManager.TotalTime.ToString("f2");
                pos2.text = "Player 1 ";
                if(TimeManager3.TotalTime<TimeManager2.TotalTime)
                {
                    time3.text = TimeManager3.TotalTime.ToString("f2");
                    pos3.text = "Player 3 "; 
                    time4.text = TimeManager2.TotalTime.ToString("f2");
                    pos4.text = "Player 2 "; 
                }
                else{
                    time3.text = TimeManager2.TotalTime.ToString("f2");
                    pos3.text = "Player 2 "; 
                    time4.text = TimeManager3.TotalTime.ToString("f2");
                    pos4.text = "Player 3 "; 
                }
            }
            else if(TimeManager3.TotalTime<TimeManager.TotalTime&&TimeManager3.TotalTime<TimeManager2.TotalTime)
            {
                time2.text = TimeManager3.TotalTime.ToString("f2");
                pos2.text = "Player 3 ";
                if(TimeManager.TotalTime<TimeManager2.TotalTime)
                {
                    time3.text = TimeManager.TotalTime.ToString("f2");
                    pos3.text = "Player 1 "; 
                    time4.text = TimeManager2.TotalTime.ToString("f2");
                    pos4.text = "Player 2 "; 
                }
                else{
                    time3.text = TimeManager2.TotalTime.ToString("f2");
                    pos3.text = "Player 2 "; 
                    time4.text = TimeManager.TotalTime.ToString("f2");
                    pos4.text = "Player 1 "; 
                }
            }
            else if(TimeManager2.TotalTime<TimeManager.TotalTime&&TimeManager2.TotalTime<TimeManager3.TotalTime)
            {
                time2.text = TimeManager2.TotalTime.ToString("f2");
                pos2.text = "Player 2 ";
                if(TimeManager.TotalTime<TimeManager3.TotalTime)
                {
                    time3.text = TimeManager.TotalTime.ToString("f2");
                    pos3.text = "Player 1 "; 
                    time4.text = TimeManager3.TotalTime.ToString("f2");
                    pos4.text = "Player 3 "; 
                }
                else{
                    time3.text = TimeManager3.TotalTime.ToString("f0");
                    pos3.text = "Player 3 "; 
                    time4.text = TimeManager.TotalTime.ToString("f0");
                    pos4.text = "Player 1 "; 
                }
            }
        }      
    }
}
