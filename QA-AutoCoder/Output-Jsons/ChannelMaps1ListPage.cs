using GVP.QA.MIB3.Base;
using System.Collections.Generic;
using OpenQA.Selenium;

public class ChannelMaps1ListPage : Mib3BaseListPage
{

    public ChannelMaps1ListPage() : base("gvp_channel_maps_list", "Channel Maps")
    {
      ColumnsNames = new List<string> () { "NAME", "TVTECHNOLOGY", "REGION", "SOURCE", "OWMER", "TITLE" };
    }


}