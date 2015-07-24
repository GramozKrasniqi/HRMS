using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace HRM.CustomValidators
{
    public class RequiredFieldValidatorForCheckBoxLists : System.Web.UI.WebControls.BaseValidator
    {
        private ListControl _listctrl;

        public RequiredFieldValidatorForCheckBoxLists()
        {
            base.EnableClientScript = true;
        }

        protected override bool ControlPropertiesValid()
        {
            Control ctrl = FindControl(ControlToValidate);

            if (ctrl != null)
            {
                _listctrl = (ListControl)ctrl;
                return (_listctrl != null);
            }
            else
                return false;  // raise exception
        }

        protected override bool EvaluateIsValid()
        {
            return _listctrl.SelectedIndex != -1;
        }
    }
}