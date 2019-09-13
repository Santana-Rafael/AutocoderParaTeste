
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

public partial class ChannelMaps1EditPage
{

    [FindsBy(How = How.Id, Using = "form_gvp_channelmaps_templatemib_default_formcomponent_NAME")]
    private IWebElement _name { get; set; }

    [FindsBy(How = How.Id, Using = "Visible_form_gvp_channelmaps_templatemib_default_formcomponent_TV_TECHNOLOGY_ID")]
    private IWebElement _tvtechnology { get; set; }

    [FindsBy(How = How.Id, Using = "Visible_form_gvp_channelmaps_templatemib_default_formcomponent_REGION_ID")]
    private IWebElement _region { get; set; }

    [FindsBy(How = How.Id, Using = "form_gvp_channelmaps_templatemib_default_formcomponent_SOURCE")]
    private IWebElement _source { get; set; }

    [FindsBy(How = How.Id, Using = "form_gvp_channelmaps_templatemib_default_formcomponent_OWNER")]
    private IWebElement _owmer { get; set; }

    [FindsBy(How = How.Id, Using = "form_gvp_channelmaps_templatemib_default_formcomponent_TITLE")]
    private IWebElement _title { get; set; }


}

