using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM
{
    public class TranslatedPage : Page
    {
        public string TranslateApplicationString(int languageId, string _stringToTranslate)
        {
            return TranslatorHelper.AppStrings[languageId][_stringToTranslate];
        }

        protected internal string TranslateControlString(int languageId, string _controlToTranslate)
        {
            return "";
        }

        private void TranslatePage(int languageId)
        {
        }

        private ListItemCollection GetListItemsFromEnum(int languageId, Type enumType)
        {
            // container to be returned
            ListItemCollection items = new ListItemCollection();
            // break down the enumerator items into key/value pairs
            string[] names = Enum.GetNames(enumType);
            Array values = Enum.GetValues(enumType);
            // piece together the key/pairs into the listitem collection
            items.Add(new ListItem("Please select", ""));
            for (int i = 1; i <= names.Length - 1; i++)
            {
                items.Add(new ListItem(TranslateApplicationString(languageId, names[i]), i.ToString()));
            }
            // return it
            return items;
        }
    }
}