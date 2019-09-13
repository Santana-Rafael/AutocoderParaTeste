using GVP.QA.MIB3.Execution.Base;
using NUnit.Framework;
using MibClient2.TestLibrary.Selenium;
using GVP.QA.Model;
using GVP.QA.Core.Jira;
using GVP.QA.MIB3.Instances.AgeRatings;
using GVP.QA.Model.Enumerations;

partial class ChannelMaps1Tests : Mib3BaseExecution
{

    [Category(TestCategory.Mib3Permissions)]
    [Test]
    public void ReadOnly(
       [ValueSource(typeof(MibBrowserDataSource), MibBrowserDataSource.ALL_BROWSER)] BrowserName browser,
       [Values(MibUserType.AdministratorsReadOnly,
          MibUserType.OBAdministratorReadOnly,MibUserType.LiveTVReadOnly)] MibUserType userType)
    {
        ReadOnlyTest(new ChannelMaps1EditPage(ListPage));
    }

    [Category(TestCategory.Mib3Permissions)]
    [Test]
    public void NoReadAccess(
        [ValueSource(typeof(MibBrowserDataSource), MibBrowserDataSource.ALL_BROWSER)] BrowserName browser,
        [Values(MibUserType.LiveTV,
          MibUserType.FOGlobal,MibUserType.FOLurin,MibUserType.UserCreator,MibUserType.VODContentManagement,
          MibUserType.EPG,MibUserType.EditorialManagement,MibUserType.Commercial,MibUserType.Notifications,
          MibUserType.CRM,MibUserType.Purge,MibUserType.VODContentManagementReadOnly,MibUserType.EPGReadOnly,
          MibUserType.EditorialManagementReadOnly,MibUserType.CommercialReadOnly,MibUserType.NotificationsReadOnly,MibUserType.CRMReadOnly)] MibUserType userType)
    {
        CheckUserHasNoReadAccess(new ChannelMaps1EditPage(ListPage));
    }
        
}