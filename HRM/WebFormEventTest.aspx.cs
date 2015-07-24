using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using System.DirectoryServices.AccountManagement;
using System.Xml;

namespace HRM
{
    public partial class WebFormEventTest : System.Web.UI.Page
    {

        #warning ChangeFileName and complete this form
        protected void Page_Load(object sender, EventArgs e)
        {
            //RoleEntity role = Authorization.isAuthorized(UserPrincipal.Current.SamAccountName, Request.RawUrl);

            //if (role == null)
            //{
            //    Response.Redirect("~/Authorization.aspx");
            //}

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("events.xml"));
            XmlNode node = xmlDoc.GetElementsByTagName("data")[0];
            node.RemoveAll();
            for (int i = 0; i < 2; i++)
            {
                XmlElement ev = xmlDoc.CreateElement("event");
                XmlAttribute atrXML = xmlDoc.CreateAttribute("id");
                atrXML.Value = new Random().Next().ToString();
                ev.SetAttributeNode(atrXML);
                //element.Attributes.Append(new XmlAttribute());


                XmlElement startDate = xmlDoc.CreateElement("start_date");
                var cdata = xmlDoc.CreateCDataSection("2013-05-23 00:00:00");
                startDate.AppendChild(cdata);

                ev.AppendChild(startDate);

                XmlElement endDate = xmlDoc.CreateElement("end_date");
                cdata = xmlDoc.CreateCDataSection("2013-05-24 00:00:00");
                endDate.AppendChild(cdata);

                ev.AppendChild(endDate);

                XmlElement text = xmlDoc.CreateElement("text");
                cdata = xmlDoc.CreateCDataSection("Test");
                text.AppendChild(cdata);

                ev.AppendChild(text);

                XmlElement details = xmlDoc.CreateElement("details");
                cdata = xmlDoc.CreateCDataSection("details");
                details.AppendChild(cdata);

                ev.AppendChild(details);

                node.AppendChild(ev);
            }

            xmlDoc.Save(Server.MapPath("events.xml"));
        }
    }
}