using GVP.QA.Model;
using GVP.QA.Tools;
using GVP.QA.Core.ConfigReader;
using GVP.QA.MIB3.APIModels.APIInterfaces;

public class ChannelMaps1Factory : IObjectFactory<ChannelMaps1>
{
        public ChannelMaps1 Init(System.Object initParam = null)
        {
            var dataConfig = new DataConfig();

            var channelmaps1 = new ChannelMaps1
            {
                Name = ,
                TvTechnologyId = ,
                RegionId = ,
                Source = ,
                Owner = ,
                Title = ,
            };            

            return channelmaps1;
        }

        public ChannelMaps1 InitEdited(System.Object initParam = null)
        {
            var dataConfig = new DataConfig();

            var channelmaps1 = new ChannelMaps1
            {
                Name = ,
                TvTechnologyId = ,
                RegionId = ,
                Source = ,
                Owner = ,
                Title = ,
            };            

            return channelmaps1;
        }

}

