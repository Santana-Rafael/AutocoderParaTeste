using GVP.QA.MIB3.Base;
using MIB.QA.Model;
using GVP.QA.Tools;
using MibSelenium.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class ChannelMaps1EditPage : Mib3BaseEditPage
{
    
    public ChannelMaps1EditPage() : base("gvp_channel_maps_edit", "Channel Maps")
    {
        
    }

    public ChannelMaps1EditPage(Mib3BaseListPage page) : base(page,"gvp_channel_maps_edit", "Channel Maps")
    {
        
    }

       public string Name
   {
      get => Driver.Form.GetFormFieldValue(_name, FieldType.Varchar).ToString();
      set => Driver.Form.SetFormFieldValue(_name, value , FieldType.Varchar);
   }

   public int Tvtechnology
   {
      get => Driver.Form.GetFormFieldValue(_tvtechnology, FieldType.Related).ToInt();
      set => Driver.Form.SetFormFieldValue(_tvtechnology, value , FieldType.Related);
   }

   public int Region
   {
      get => Driver.Form.GetFormFieldValue(_region, FieldType.Related).ToInt();
      set => Driver.Form.SetFormFieldValue(_region, value , FieldType.Related);
   }

   public int Source
   {
      get => Driver.Form.GetFormFieldValue(_source, FieldType.Source).ToInt();
      set => Driver.Form.SetFormFieldValue(_source, value , FieldType.Source);
   }

   public int Owmer
   {
      get => Driver.Form.GetFormFieldValue(_owmer, FieldType.Integer).ToInt();
      set => Driver.Form.SetFormFieldValue(_owmer, value , FieldType.Integer);
   }

   public string Title
   {
      get => Driver.Form.GetFormFieldValue(_title, FieldType.Varchar).ToString();
      set => Driver.Form.SetFormFieldValue(_title, value , FieldType.Varchar);
   }


}