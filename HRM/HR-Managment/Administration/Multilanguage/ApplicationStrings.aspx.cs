using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Entities;
using DAL.Mapper;
using System.Web.Services;

namespace HRM.HR_Managment.Administration.Multilanguage
{
    public partial class ApplicationStrings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (LanguageEntity lang in new LanguageMapper().List(""))
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlGenericControl label = new HtmlGenericControl("label");
                label.ID = lang + "label";
                label.InnerText = lang.Title;
                TextBox txt = new TextBox();
                txt.ID = lang.Title;
                txt.TextMode = TextBoxMode.MultiLine;

                li.Controls.Add(label);
                li.Controls.Add(txt);

                TranslateLanguages.Controls.Add(li);
            }
        }
    }
}