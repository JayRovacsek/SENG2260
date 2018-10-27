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
    public bool isJoiningGroup;
    [SerializeField]
    public bool isInviting;
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
            SetJoiningGroup(false);
            Open();
        }
    }

    public void JoinGroup()
    {
        if (!inGroup)
        {
            Close();
            inGroup = true;
            isAdmin = false;
            SetJoiningGroup(false);
            Open();
        }
    }

    public void Invite()
    {
        if (inGroup)
        {
            Close();
            SetInviting(false);
            Open();
        }
    }

    public void SetJoiningGroup(bool joining)
    {
        isJoiningGroup = joining;
    }

    public void SetInviting(bool inviting)
    {
        isInviting = inviting;
    }
}