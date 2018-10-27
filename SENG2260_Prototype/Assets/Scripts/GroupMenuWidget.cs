using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupMenuWidget : MenuWidget
{
    [SerializeField]
    public bool inGroup;
    [SerializeField]
    public bool isAdmin;
    [SerializeField]
    private MenuWidget inGroupWidget;
    [SerializeField]
    private MenuWidget adminGroupWidget;
    [SerializeField]
    private MenuWidget noGroupWidget;

    public override MenuWidget GetWidget()
    {
        if (inGroup && isAdmin)
        {
            return adminGroupWidget;
        }
        else if (inGroup)
        {
            return inGroupWidget;
        }
        else
        {
            return noGroupWidget;
        }
    }

    public void DisbandGroup()
    {
        if (isAdmin)
        {
            LeaveGroup();
        }
    }

    public void LeaveGroup()
    {
        if (inGroup)
        {
            Close();
            inGroup = false;
            isAdmin = false;
        }
    }   

    public void CreateGroup()
    {
        if (!inGroup)
        {
            Close();
            inGroup = true;
            isAdmin = true;
            Open();
        }
    }
}