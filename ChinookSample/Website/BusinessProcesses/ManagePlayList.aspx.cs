﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ChinookSystem.BLL;
using ChinookSystem.Data.POCOs;
using Chinook.UI;
#endregion

public partial class BusinessProcesses_ManagePlayList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            TrackSearchList.DataSource = null;
        }
    }

    protected void AddToPlayList_Click(object sender, EventArgs e)
    {
       
      
    }

    protected void ArtistFetch_Click(object sender, EventArgs e)
    {
        MessageUserControl.TryRun((ProcessRequest)FetchTracksForArtist);
    }
    public void FetchTracksForArtist()
    {
        int id = int.Parse(ArtistList.SelectedValue);
        TrackController sysmgr = new TrackController();
        List<TracksForPlaylistSelection> results = sysmgr.Get_TracksForPlaylistSelection(id, "Artist");
        TrackSearchList.DataSource = results;
        TrackSearchList.DataBind();
        TracksBy.Text = "Artist";
    }


    protected void TrackSearchList_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        
        TrackSearchList.SelectedIndex = e.NewSelectedIndex;
    }

    protected void TrackSearchList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        switch (TracksBy.Text)
        {
            case "Artist":
                {
                    (TrackSearchList.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
                    this.FetchTracksForArtist();
                    break;
                }
        }
    }

    protected void TrackSearchList_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        //MessageUserControl.ShowInfo("row selected with id of " + e.CommandArgument);
        ListViewDataItem rowcontents = e.Item as ListViewDataItem;
        MessageUserControl.ShowInfo("row selected with id of " + e.CommandArgument + " title is " + (rowcontents.FindControl("Label2") as Label).Text.ToString());
    }

    protected void PlayListFetch_Click(object sender, EventArgs e)
    {

    }
}