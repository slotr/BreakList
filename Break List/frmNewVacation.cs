using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;

namespace Break_List
{
    public partial class frmNewVacation : DevExpress.XtraEditors.XtraForm
    {
        public frmNewVacation()
        {
            InitializeComponent();

            dataLayoutControl1.DataSource = GetDataSource();
            dataLayoutControl1.RetrieveFields();

            List<BaseLayoutItem> flatList = new FlatItemsList().GetItemsList(dataLayoutControl1.Root);
            BaseLayoutItem aboutItem = flatList.First(e => e.Text == "About");
            aboutItem.TextLocation = DevExpress.Utils.Locations.Top;
        }
        static List<Employee> GetDataSource()
        {
            List<Employee> result = new List<Employee>();
            Employee employee = new Employee();

            employee.AddressLine1 = "527 W 7th St, Los Angeles, CA";
            employee.AddressLine2 = "3800 Homer St, Los Angeles, CA";
            employee.BirthDate = new DateTime(1983, 11, 19);
            employee.Email = "ameliah@dx-email.com";
            employee.Skype = "ameliah_DX_skype";
            employee.FirstName = "Amelia";
            employee.Gender = Gender.Female;
            employee.Group = "IT";
            
            employee.HireDate = new DateTime(2011, 10, 2);
            employee.LastName = "Harper";
            employee.Phone = "(213)555-3792";
            employee.Salary = 25400;
            employee.Title = "Manager";
            employee.Description = @"Amelia is on probation for failure to follow-up on tasks.  We hope to see her back at her desk shortly. Please remember negligence of assigned tasks is not something we tolerate.";

            result.Add(employee);
            return result;
        }
        
        public enum Gender { Male, Female }
        public class Employee
        {
            const string RootGroup = "<Root>";
            const string Photo = RootGroup + "/" + "<Photo->";
            const string FirstNameAndLastName = Photo + "/" + "<FirstAndLastName>";
            const string TabbedGroup = FirstNameAndLastName + "/" + "{Tabs}";
            const string ContactGroup = TabbedGroup + "/" + "Contact";
            const string BDateAndGender = ContactGroup + "/" + "<BDateAndGender->";
            const string HomeAddressAndPhone = ContactGroup + "/" + "<HomeAddressAndPhone->";
            const string JobGroup = TabbedGroup + "/" + "Job";
            const string HDateAndSalary = JobGroup + "/" + "<HDateAndSalary->";
            const string EmailAndSkype = JobGroup + "/" + "<EmailAndSkype->";
            const string GroupAndTitle = JobGroup + "/" + "<GroupAndTitle->";

            [Key, Display(AutoGenerateField = false)]
            public int ID { get; set; }
            [Display(Name = "Last name", GroupName = FirstNameAndLastName, Order = 2)]
            public string LastName { get; set; }
            [Display(Name = "First name", GroupName = FirstNameAndLastName, Order = 1)]
            public string FirstName { get; set; }
            [Display(Name = "", GroupName = Photo, Order = 0)]
            public Image Image { get; set; }
            [Display(Name = "Phone", GroupName = HomeAddressAndPhone)]
            public string Phone { get; set; }
            [Display(Name = "E-Mail", GroupName = EmailAndSkype, Order = 5)]
            public string Email { get; set; }
            [Display(Name = "Skype", GroupName = EmailAndSkype)]
            public string Skype { get; set; }
            [Display(Name = "Home address", GroupName = HomeAddressAndPhone)]
            public string AddressLine1 { get; set; }
            [Display(Name = "Work address", GroupName = JobGroup)]
            public string AddressLine2 { get; set; }
            [Display(Name = "About", GroupName = RootGroup), DataType(DataType.MultilineText)]
            public string Description { get; set; }
            [Range(typeof(DateTime), "1/1/1900", "1/1/2000", ErrorMessage = "Birthday is out of Range")]
            [Display(Name = "Birthday", GroupName = BDateAndGender, Order = 3)]
            public DateTime BirthDate { get; set; }
            [Display(Name = "Gender", GroupName = BDateAndGender)]
            public Gender Gender { get; set; }
            [Display(Name = "Group", GroupName = GroupAndTitle, Order = 6)]
            public string Group { get; set; }
            [Display(Name = "Hire date", GroupName = HDateAndSalary, Order = 4)]
            public DateTime HireDate { get; set; }
            [Display(Name = "Salary", GroupName = HDateAndSalary)]
            public decimal Salary { get; set; }
            [Display(Name = "Title", GroupName = GroupAndTitle)]
            public string Title { get; set; }
        }
       
    }
}