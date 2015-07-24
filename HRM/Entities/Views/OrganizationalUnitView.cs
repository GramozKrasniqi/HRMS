﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class OrganizationalUnitView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string OrganizationaUnitGroup { get; set; }
        public StatusEnum Status { get; set; }

        public string TitleAndOrganizationaUnitGroup 
        {
            get
            {
                return Title + " (" + OrganizationaUnitGroup + ") ";
            }
        }
    }
}
