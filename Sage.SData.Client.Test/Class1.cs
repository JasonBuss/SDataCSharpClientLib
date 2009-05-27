﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using NUnit.Framework;
using Sage.SData.Client.Core;
using Sage.SData.Client.Atom;
using Sage.SData.Client.Common;
using Sage.SData.Client.Extensions;
using NUnit.Framework.SyntaxHelpers;

namespace Sage.SData.Client.Test
{
    [TestFixture]
    public class Class1 : NUnit.Framework.AssertionHelper
    {
        private bool bUseTestSerivce = true;
        [Test]
        public void verify_canconstruct_SDataService()
        {
            var a = new SDataService();
            Expect(a, Is.Not.Null);
        }
        [Test]
        public void verify_canconstructwithurl_SDataService()
        {
            var a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/employees", "lee", "");
            Expect(a, Is.Not.Null);
        }
        [Test]
        public void verity_caninitialize_SDataService()
        {
            var a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/employees", "lee", "");
            
            Expect(a.UserName, Is.Not.Null);
            Expect(a.UserName == "lee");
            
            Expect(a.Password, Is.Not.Null);
            Expect(a.Password == "");
            
            Expect(a.Protocol, Is.Not.Null);
            Expect(a.Protocol == "http");
            
            Expect(a.ServerName, Is.Not.Null);
            Expect(a.ServerName == "localhost:59213");
            
            Expect(a.VirtualDirectory, Is.Not.Null);
            Expect(a.VirtualDirectory == "sdata");
            
            Expect(a.ApplicationName, Is.Not.Null);
            Expect(a.ApplicationName == "aw");

            Expect(a.ContractName, Is.Not.Null);
            Expect(a.ContractName == "dynamic");

            Expect(a.DataSet, Is.Not.Null);
            Expect(a.DataSet == "-");
        }
        [Test]
        public void verify_canreadatomfeed_SDataService()
        {
            ISDataService a;
            if(bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourceCollectionRequest(a);
            b.ResourceKind = "employees";

            AtomFeed feed = a.ReadFeed(b);
            Expect(feed, Is.Not.Null);
        }
        [Test]
        public void verify_canread_SDataResourceSchemaRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourceSchemaRequest(a);
            b.ResourceKind = "employees";

            XmlSchema schema = b.Read();

            Expect(schema, Is.Not.Null);

        }
        

        [Test]
        public void verify_cancontruct_IntermediateApplicationsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateApplicationsRequest(a);
            Expect(b, Is.Not.Null);
            
        }

        [Test]
        public void verify_tostring_IntermediateApplicationsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateApplicationsRequest(a);
            string url = b.ToString();


            Expect(url == "http://localhost:59213/sdata");
        }

        [Test]
        public void verify_canread_IntermediateApplicationsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateApplicationsRequest(a);
            AtomFeed feed = b.Read();
           
        }

        [Test]
        public void verify_canconstruct_IntermediateContractsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateContractsRequest(a);
            Expect(b, Is.Not.Null);
        }
        [Test]
        public void verify_tostring_IntermediateContractsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateContractsRequest(a);
            b.Application = "aw";
            string url = b.ToString();
            Expect(url == "http://localhost:59213/sdata/aw");
        }
        [Test]
        public void verify_canread_IntermediateContractsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateContractsRequest(a);
            b.Application = "aw";
            AtomFeed feed = b.Read();
            Expect(feed,  Is.Not.Null);
        }

        [Test]
        public void verify_canconstruct_IntermediateDataSetsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateDataSetsRequest(a);
        }

        [Test]
        public void verify_tostring_IntermediateDataSetsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateDataSetsRequest(a);
            b.ContractName = "dynamic";

            string url = b.ToString();
            Expect(url == "http://localhost:59213/sdata/aw/dynamic");
        }
        [Test]
        public void verify_canread_IntermediateDataSetsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateDataSetsRequest(a);
            b.ContractName = "dynamic";

            AtomFeed feed = b.Read();
            Expect(feed, Is.Not.Null);
        }

        [Test]
        public void verify_canconstruct_IntermediateResourceCollectionsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateResourceCollectionsRequest(a);
           
            Expect(b, Is.Not.Null);
        }
        [Test]
        public void verify_tostring_IntermediateResourceCollectionsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateResourceCollectionsRequest(a);
            b.DataSet = "-";

            string url = b.ToString();

            Expect(url == "http://localhost:59213/sdata/aw/dynamic/-");
        }
        [Test]
        public void verify_canread_IntermediateResourceCollectionsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateResourceCollectionsRequest(a);
            b.DataSet = "-";

            AtomFeed feed = b.Read();

            Expect(feed, Is.Not.Null);
        }

        [Test]
        public void verify_canconstruct_IntermediateServicesRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateServicesRequest(a);
            
            Expect(b, Is.Not.Null);
        }

        [Test]
        public void verify_tostring_IntermediateServicesRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateServicesRequest(a);
            b.ResourceKind = "employees";

            string url = b.ToString();
            Expect(url == "http://localhost:59213/sdata/aw/dynamic/-/employees/$service");
        }

        [Test]
        public void verify_canread_IntermediateServicesRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new IntermediateServicesRequest(a);
            b.ResourceKind = "employees";

            AtomFeed feed = b.Read();
            Expect(feed, Is.Not.Null);
        }

        [Test]
        public void verify_canconstruct_SDataResourceCollectionsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourceCollectionRequest(a);
            
            Expect(b, Is.Not.Null);
        }
        [Test]
        public void verify_tostringwithpageing_SDataResourceCollectionsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourceCollectionRequest(a);
            b.ResourceKind = "employees";
            b.StartIndex = 1;
            b.Count = 100;

            string url = b.ToString();
            Expect(url == "http://localhost:59213/sdata/aw/dynamic/-/employees?count=100&startIndex=1");
        }

        [Test]
        public void verify_tostringwithquery_SDataResourceCollectionsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourceCollectionRequest(a);
            b.ResourceKind = "employees";
            b.QueryValues.Add("where", "gender eq m");

            string url = b.ToString();
            Expect(url == "http://localhost:59213/sdata/aw/dynamic/-/employees?where=gender eq m");
        }

        [Test]
        public void verify_tostringwithquery_multiplevalues_SDataResourceCollectionsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourceCollectionRequest(a);
            b.ResourceKind = "employees";
            b.QueryValues.Add("where", "gender eq m");
            b.QueryValues.Add("orderBy", "orderDate DESC");

            string url = b.ToString();
            Expect(url == "http://localhost:59213/sdata/aw/dynamic/-/employees?where=gender eq m&orderBy=orderDate DESC");
        }

        [Test]
        public void verify_canread_SDataResourceCollectionsRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourceCollectionRequest(a);
            b.ResourceKind = "employees";
            //b.QueryValues.Add("where", "gender eq m");
            //b.QueryValues.Add("orderBy", "HireDate DESC");

            AtomFeed feed = b.Read();
            
            Expect(b, Is.Not.Null);
        }

        [Test]
        public void verify_canread_SDataResourceCollectionsRequest_Reader()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:49327/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:49327/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourceCollectionRequest(a);
            b.ResourceKind = "employees";

            b.Count = 10;
            b.StartIndex = 1;
            
            AtomFeed feed = b.Read();

            
            Expect(b.Reader, Is.Null);

            
        }

        [Test]
        public void verify_canconstruct_SDataSingleResourceRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataSingleResourceRequest(a);

            Expect(b, Is.Not.Null);
        }

        [Test]
        public void verify_canconstructwithtemplateEntry_SDataSingleResourceRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            //var b = new SDataSingleResourceRequest(a, atomfeed);

            //Expect(b, Is.Not.Null);
        }


        [Test]
        public void verify_tostringwithresourcekind_SDataSingleResourceRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataSingleResourceRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(id = '1234')";

            string result = b.ToString();

            Expect(result == "http://localhost:59213/sdata/aw/dynamic/-/employees(id = '1234')");
        }

        [Test]
        public void verify_tostringwithresourcekindandinclude_SDataSingleResourceRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataSingleResourceRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(1)";
            b.Include = "contact";

            string result = b.ToString();

            Expect(result == "http://localhost:59213/sdata/aw/dynamic/-/employees(1)?include=contact");
        }

        



        [Test]
        public void verify_canprocess_SDataBatchRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:49327/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataSingleResourceRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(1)";
            
            var c = new SDataSingleResourceRequest(a);
            c.ResourceKind = "employees";
            c.ResourceSelector = "(2)";

            AtomEntry entry1 = c.Read();

            XPathNavigator payload = entry1.GetSDataPayload();
            if (payload != null)
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(payload.OuterXml);
                XPathNavigator employee = doc.DocumentElement.CreateNavigator();
                XmlNamespaceManager manager = new XmlNamespaceManager(payload.NameTable);
                manager.AddNamespace("aw", "http://schemas.sage.com/dynamic/2007");
                employee.MoveToFirst();
                XPathNavigator title = employee.SelectSingleNode(".//aw:MaritalStatus", manager);
                title.SetValue("Married");
                entry1.SetSDataPayload(payload);

            }

            c.Entry = entry1;
            
            
            var d = new SDataSingleResourceRequest(a);
            d.ResourceKind = "employees";
            d.ResourceSelector = "(3)";

            AtomEntry entry2 = d.Read();
            d.Entry = entry2;

            AtomFeed batchfeed = null;
            using (SDataBatchRequest batch = new SDataBatchRequest(a))
            {
                batch.ResourceKind = "employees";
                b.Read();
                c.Update();
                d.Delete();

                batch.Dispose();
                batchfeed = batch.Feed;
            }


            Expect(batchfeed, Is.Not.Null);
        }


        [Test]
        public void verify_canread_SDataSingleResourceRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataSingleResourceRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(1)";

            AtomEntry entry = b.Read();

            Expect(entry, Is.Not.Null);
            
        }

        [Test]
        public void verify_cancreate_SDataSingleResourceRequest()
        {

            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataTemplateResourceRequest(a);
            b.ResourceKind = "employees";
            
            AtomEntry templateentry = b.Read();

            SDataSingleResourceRequest c = new SDataSingleResourceRequest(a);
            c.ResourceKind = "employees";

            XPathNavigator payload = templateentry.GetSDataPayload();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(payload.OuterXml);
            XPathNavigator employee = doc.DocumentElement.CreateNavigator();
            XmlNamespaceManager manager = new XmlNamespaceManager(payload.NameTable);
            manager.AddNamespace("a", "http://schemas.sage.com/dynamic/2007");
            employee.MoveToFirst();
            
            
            XPathNavigator title = employee.SelectSingleNode(".//a:Title", manager);
            title.SetValue("create 1");

            XPathNavigator nationalid = employee.SelectSingleNode(".//a:NationalIdNumber", manager);
            nationalid.SetValue("44444");

            XPathNavigator loginid = employee.SelectSingleNode(".//a:LoginId", manager);
            loginid.SetValue("create 4");

            XPathNavigator contactid = employee.SelectSingleNode(".//a:ContactId", manager);
            contactid.SetValue("9999");

            XPathNavigator birthdate = employee.SelectSingleNode(".//a:BirthDate", manager);
            birthdate.SetValue(SyndicationDateTimeUtility.ToRfc3339DateTime(new DateTime(1970, 8, 2)));
           

            XPathNavigator hiredate = employee.SelectSingleNode(".//a:HireDate", manager);
            
            hiredate.SetValue(SyndicationDateTimeUtility.ToRfc3339DateTime(DateTime.Now));

            XPathNavigator modifieddate = employee.SelectSingleNode(".//a:ModifiedDate", manager);
            modifieddate.SetValue(SyndicationDateTimeUtility.ToRfc3339DateTime(DateTime.Now));


            XPathNavigator maritalstatus = employee.SelectSingleNode(".//a:MaritalStatus", manager);
            maritalstatus.SetValue("Single");


            XPathNavigator salariedflag = employee.SelectSingleNode(".//a:SalariedFlag", manager);
            salariedflag.SetValue(XmlConvert.ToString(true));

            XPathNavigator currentflag = employee.SelectSingleNode(".//a:CurrentFlag", manager);
            currentflag.SetValue(XmlConvert.ToString(true));
            
            XPathNavigator gender = employee.SelectSingleNode(".//a:Gender", manager);
            gender.SetValue("Male");

            XPathNavigator guid = employee.SelectSingleNode(".//a:RowGuid", manager);
            guid.SetValue(System.Guid.NewGuid().ToString());

            templateentry.SetSDataPayload(employee);

            c.Entry = templateentry;
            templateentry.UpdatedOn = DateTime.Now;
            templateentry.PublishedOn = DateTime.Now;

            AtomEntry newentry = c.Create();

            Expect(newentry, Is.Not.Null);
           
        }

        [Test]
        public void verify_canupdate_SDataSingleResourceRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataSingleResourceRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(1)";

            AtomEntry entry = b.Read();

            XPathNavigator payload = entry.GetSDataPayload();
            if (payload != null)
            {

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(payload.OuterXml);
                XPathNavigator employee = doc.DocumentElement.CreateNavigator();
                XmlNamespaceManager manager = new XmlNamespaceManager(payload.NameTable);
                manager.AddNamespace("a", "http://schemas.sage.com/dynamic/2007");
                employee.MoveToFirst();
                XPathNavigator title = employee.SelectSingleNode(".//a:Title", manager);
                title.SetValue("test update");
                entry.SetSDataPayload(payload);
                
            }
            
            b.Entry = entry;
            AtomEntry updateentry = b.Update();

            Expect(updateentry, Is.Not.Null);
        }

        [Test]
        public void verify_candelete_SDataSingleResourceRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataSingleResourceRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(1)";

            AtomEntry entry = b.Read();
            b.Entry = entry;

            bool result  = b.Delete();

            Expect(result);
        }

        [Test]
        public void verify_canconstruct_SDataResourcePropertyRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourcePropertyRequest(a);
            

            Expect(b, Is.Not.Null);
        }

        [Test]
        public void verify_tostringwithsingleresourceproperty_SDataResourcePropertyRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourcePropertyRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(1)";

            b.ResourceProperties.Add(0, "LoginID");

            string result = b.ToString();
            
            Expect(result == "http://localhost:59213/sdata/aw/dynamic/-/employees(1)/LoginID");
        }

        [Test]
        public void verify_tostringwithmultipleresourceproperties_SDataResourcePropertyRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourcePropertyRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(1)";

            b.ResourceProperties.Add(0, "Address");
            b.ResourceProperties.Add(1, "City");

            string result = b.ToString();

            Expect(result == "http://localhost:59213/sdata/aw/dynamic/-/employees(1)/Address/City");
        }
        [Test]
        public void verify_canreadfeed_SDataResourcePropertyRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:51129/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourcePropertyRequest(a);
            b.ResourceKind = "employee";
            b.ResourceSelector = "(1)";

            b.ResourceProperties.Add(0, "Contacts");

            AtomFeed feed = b.ReadFeed();


            Expect(feed, Is.Not.Null);
        }

        [Test]
        public void verify_canreadentry_SDataResourcePropertyRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourcePropertyRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(1)";

            b.ResourceProperties.Add(0, "LoginID");
            
            AtomEntry entry = b.Read();


            Expect(entry, Is.Not.Null);
        }
        [Test]
        public void verify_canreadcreate_SDataResourcePropertyRequest()
        {
            var a = new SDataServiceTest("http://localhost:8001/sdata/aw/dynamic/-", "lee", "");
            a.Initialize();

            var b = new SDataResourcePropertyRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(id = '1234')";

            b.ResourceProperties.Add(0, "Address");
            b.ResourceProperties.Add(1, "City");

            AtomEntry entry = b.Create();


            Expect(entry, Is.Not.Null);
        }

        [Test]
        public void verify_canupdate_SDataResourcePropertyRequest()
        {
            var a = new SDataServiceTest("http://localhost:8001/sdata/aw/dynamic/-", "lee", "");
            a.Initialize();

            var b = new SDataResourcePropertyRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(id = '1234')";

            b.ResourceProperties.Add(0, "Address");
            b.ResourceProperties.Add(1, "City");

            AtomEntry entry = b.Update();


            Expect(entry, Is.Not.Null);
        }

        [Test]
        public void verify_candelete_SDataResourcePropertyRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataResourcePropertyRequest(a);
            b.ResourceKind = "employees";
            b.ResourceSelector = "(1)";

            b.ResourceProperties.Add(0, "Address");
            b.ResourceProperties.Add(1, "City");

            bool result = b.Delete();


            Expect(result);
        }

        [Test]
        public void verify_canconstruct_SDataTemplateResourceRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataTemplateResourceRequest(a);

            
            Expect(b, Is.Not.Null);
        }
        [Test]
        public void verify_tostring_SDataTemplateResourceRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataTemplateResourceRequest(a);
            b.ResourceKind = "employees";

            string result = b.ToString();

            Expect(result == "http://localhost:59213/sdata/aw/dynamic/-/employees/$template?format=atomentry");
        }

        [Test]
        public void verify_canread_SDataTemplateResourceRequest()
        {
            ISDataService a;
            if (bUseTestSerivce)
                a = new SDataServiceTest("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            else
                a = new SDataService("http://localhost:59213/sdata/aw/dynamic/-/", "lee", "");
            a.Initialize();

            var b = new SDataTemplateResourceRequest(a);
            b.ResourceKind = "employees";

            AtomEntry entry = b.Read();

            Expect(b, Is.Not.Null);
        }

    }

}