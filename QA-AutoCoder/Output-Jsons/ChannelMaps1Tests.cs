using FluentAssertions;
using GVP.QA.Core.ConfigReader;
using GVP.QA.Core.Jira;
using GVP.QA.MIB3.APIModels;
using GVP.QA.MIB3.APIModels.Factories;
using GVP.QA.MIB3.Execution.Base;
using GVP.QA.MIB3.Live;
using GVP.QA.Model;
using MibClient2.TestLibrary.Selenium;
using NUnit.Framework;
using System.Collections.Generic;

public partial class ChannelMaps1Tests : Mib3BaseExecution
{
        List<string> _allPagesFields = new List<string>() { "Name", "TV Technology", "Region", "Source", "Owner", "Title"};

        private List<RequiredField> _requiredFields = new List<RequiredField>()
		{
             new RequiredField("Name"),
             new RequiredField("TV Technology"),
             new RequiredField("Region"),
             new RequiredField("Source")
		};

		private List<string> _allBlocksList = new List<string>() { "Bundle Packages" };

        ChannelMaps1EditPage _editPage;

        public override void Init()
        {
            ListPage = new ChannelMaps1ListPage();
        }


        [Test]
        [JiraKey("")]
        public void OpenEdit([ValueSource(typeof(MibClient2.TestLibrary.Selenium.MibBrowserDataSource), MibBrowserDataSource.ALL_BROWSER)] BrowserName browser,
            [Values(MibUserType.Administrators,MibUserType.OBAdministrator,MibUserType.AdministratorsReadOnly,MibUserType.OBAdministratorReadOnly,MibUserType.LiveTVReadOnly )] MibUserType userType)
        {
            OpenEditTest<ChannelMaps1EditPage>(_allPagesFields);
        }

        
        [Test]
        [JiraKey("")]
        public void OpenList([ValueSource(typeof(MibClient2.TestLibrary.Selenium.MibBrowserDataSource), MibBrowserDataSource.ALL_BROWSER)] BrowserName browser,
            [Values(MibUserType.Administrators,MibUserType.OBAdministrator,MibUserType.AdministratorsReadOnly,MibUserType.OBAdministratorReadOnly,MibUserType.LiveTVReadOnly)] MibUserType userType)
        {
            OpenListTestCheckingAllButtonsAndColumns();
        }

        [Test]
        [JiraKey("")]
        public void RequiredFields(
        [ValueSource(typeof(MibBrowserDataSource), MibBrowserDataSource.ALL_BROWSER)] BrowserName browser,
        [Values(MibUserType.Administrators,
          MibUserType.OBAdministrator)] MibUserType userType)
        {
            CheckRequiredFields(new ChannelMaps1EditPage(ListPage), _requiredFields);
        }
        
		[Test]
        [JiraKey("")]
        public void CheckAllBlocks(
        [ValueSource(typeof(MibBrowserDataSource), MibBrowserDataSource.ALL_BROWSER)] BrowserName browser,
        [Values(MibUserType.Administrators,MibUserType.OBAdministrator,MibUserType.AdministratorsReadOnly,MibUserType.OBAdministratorReadOnly,MibUserType.LiveTVReadOnly)] MibUserType userType)
        {
			ListPage.NavigateByMenu();
            ListPage.SelectRowInListPage();
			_editPage = new ChannelMaps1EditPage(ListPage);
            CheckPageBlocks(_allBlocksList, _editPage);
        }


        [Test]
        [JiraKey("")]
        public void Edit([ValueSource(typeof(MibBrowserDataSource), MibBrowserDataSource.ALL_BROWSER)] BrowserName browser,
        [Values(MibUserType.Administrators,
          MibUserType.OBAdministrator)] MibUserType userType)
        {
            var apiObject = GetOrCreateThroughAPI();
            var editedModel = new ChannelMaps1Factory().InitEdited();

            _editPage = ChannelMaps1EditPage.InitAndGoToItem<ChannelMaps1EditPage>(ListPage, apiObject.ApiObject.Id);

            Edit(editedModel);
            _editPage.Save();
            AssertFields(editedModel);
        }

		[Test]
        [JiraKey("")]
        public void Delete([ValueSource(typeof(MibBrowserDataSource), MibBrowserDataSource.ALL_BROWSER)] BrowserName browser,
        [Values(MibUserType.Administrators,
          MibUserType.OBAdministrator)] MibUserType userType)
        {
            var apiObject = GetOrCreateThroughAPI();

            _editPage = ChannelMaps1EditPage.InitAndGoToItem<ChannelMaps1EditPage>(ListPage, apiObject.ApiObject.Id);

            DeleteAndAssert(_editPage);

            RemoveObjectToBeDelete(apiObject.ApiObject);
        }

		[Test]
        [JiraKey("")]
		public void Create([ValueSource(typeof(MibBrowserDataSource), MibBrowserDataSource.ALL_BROWSER)] BrowserName browser,
        [Values(MibUserType.Administrators,
          MibUserType.OBAdministrator)] MibUserType userType)
        {
			ListPage.NavigateByMenu();
			ListPage.NewItem();

			_editPage = new ChannelMaps1EditPage(ListPage);
			var createModel = new ChannelMaps1Factory().Init();
			Edit(createModel);
			_editPage.Save();

			AssertFields(createModel);
			_editPage.Delete();
		}

		[Test]
        [JiraKey("")]
		public void BulkEdit([ValueSource(typeof(MibBrowserDataSource), MibBrowserDataSource.ALL_BROWSER)] BrowserName browser,
        [Values(MibUserType.Administrators,
          MibUserType.OBAdministrator)] MibUserType userType)
        {
			ListPage.NavigateByMenu();
			List<int> ids = ListPage.SelectCheckBoxFromMultipleRandomItems(2);
			ListPage.ClickOnEdit();
			_editPage = new ChannelMaps1EditPage(ListPage);

			var bulkEditModel = new ChannelMaps1Factory().InitEdited();
			Edit(bulkEditModel);
			_editPage.Save();

			AssertMultipleChannelMaps1(ids, bulkEditModel);
		}

		public void AssertMultipleChannelMaps1(List<int> idList, ChannelMaps1 Model)
		{
			foreach (int id in idList)
			{
				_editPage.NavigateById(id);
				AssertFields(Model);
			}
		}

        private void Edit(ChannelMaps1 model)
        {
            _editPage.Name = model.Name;
            _editPage.Tvtechnology = model.TvTechnologyId;
            _editPage.Region = model.RegionId;
            _editPage.Source = model.Source;
            _editPage.Owmer = model.Owner;
            _editPage.Title = model.Title;

        }

        private void AssertFields(ChannelMaps1 model)
        {
            _editPage.Name.Should().Be(model.Name);
            _editPage.Tvtechnology.Should().Be(model.TvTechnologyId);
            _editPage.Region.Should().Be(model.RegionId);
            _editPage.Source.Should().Be(model.Source);
            _editPage.Owmer.Should().Be(model.Owner);
            _editPage.Title.Should().Be(model.Title);

        }

        private ObjectForTest GetOrCreateThroughAPI()
        {
            return GetOrCreateObject<ChannelMaps1, ChannelMaps1Factory>()[0];
        }


}