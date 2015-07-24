using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Views
{
    public class JobDetailsSessionView
    {
        public JobDetailsSessionView()
        {
            ContractsTemplates = new List<ContractTemplateEntity>();
            FunctionalLevel = new FunctionalLevelEntity();
            OrganisationalUnit = new OrganizationalUnitView();
            Grade = new GradeEntity();
            Step = new StepEntity();
            Job = new JobTitleView();
            IsGenerated = false;
        }

        public FunctionalLevelEntity FunctionalLevel { get; set; }
        public OrganizationalUnitView OrganisationalUnit { get; set; }
        public GradeEntity Grade { get; set; }
        public StepEntity Step { get; set; }
        public JobTitleView Job { get; set; }
        public List<ContractTemplateEntity> ContractsTemplates { get; set; }
        public bool IsGenerated { get; set; }
    }
}
