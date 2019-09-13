using GVP.QA.Model;
using GVP.QA.Tools;
using MIB.QA.Model;
using MibSelenium.APIClient;
using System;

public class ChannelMaps1 : Mib3BaseApiObject
{
        public ChannelMaps1(): base("GVP_CHANNEL_MAPS"){ }


                   [Mib3BaseApiObjectNotation("NAME")]
           public string Name { get; set; }


           [Mib3BaseApiObjectNotation("TV_TECHNOLOGY_ID")]
           public int TvTechnologyId { get; set; }


           [Mib3BaseApiObjectNotation("REGION_ID")]
           public int RegionId { get; set; }


           [Mib3BaseApiObjectNotation("SOURCE")]
           public int Source { get; set; }


           [Mib3BaseApiObjectNotation("OWNER")]
           public int Owner { get; set; }


           [Mib3BaseApiObjectNotation("TITLE")]
           public string Title { get; set; }


}