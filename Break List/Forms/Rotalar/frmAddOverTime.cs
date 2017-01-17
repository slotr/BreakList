using System;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler.UI;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Native;
using DevExpress.Utils.Internal;
using System.Collections.Generic;

namespace Break_List.Forms.Rotalar
{
    public sealed partial class FrmAddOverTime : XtraForm, IDXManagerPopupMenu
    {
        #region Fields

        #endregion
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FrmAddOverTime()
        {
            
            InitializeComponent();
        }
        public FrmAddOverTime(SchedulerControl control, Appointment apt)
            : this(control, apt, false)
        {
        }
        public FrmAddOverTime(SchedulerControl control, 
            Appointment apt, 
            bool openRecurrenceForm)
        {
            Guard.ArgumentNotNull(control, "control");
            Guard.ArgumentNotNull(control.Storage, "control.Storage");
            Guard.ArgumentNotNull(apt, "apt");

            OpenRecurrenceForm = openRecurrenceForm;
            Controller = CreateController(control, apt);
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            SetupPredefinedConstraints();
            LoadIcons();

            Control = control;
            Storage = control.Storage;

            edtShowTimeAs.Storage = Storage;
            edtLabel.Storage = Storage;
            edtResource.SchedulerControl = control;
            edtResource.Storage = Storage;
            edtResources.SchedulerControl = control;

            SubscribeControllerEvents(Controller);
            SubscribeEditorsEvents();
            BindControllerToControls();

        }
        #region Properties
        protected override FormShowMode ShowMode => FormShowMode.AfterInitialization;
        public IDXMenuManager MenuManager { get; private set; }
        internal AppointmentFormController Controller { get; }

        internal SchedulerControl Control { get; }

        internal ISchedulerStorage Storage { get; }

        internal bool IsNewAppointment => Controller?.IsNewAppointment ?? true;
        internal Icon RecurringIcon { get; private set; }

        internal Icon NormalIcon { get; private set; }

        internal bool OpenRecurrenceForm { get; private set; }

        public bool ReadOnly
        {
            get { return Controller != null && Controller.ReadOnly; }
            set
            {
                if (Controller.ReadOnly == value)
                    return;
                Controller.ReadOnly = value;
            }
        }
        #endregion
        
        public void LoadFormData(Appointment appointment)
        {
            try
            {
                txtOverTime.Text = appointment.CustomFields["OverTime"].ToString();
                txtErkenGonderim.Text = appointment.CustomFields["ErkenGonderim"].ToString();
                txtSicCall.Text = appointment.CustomFields["SickCall"].ToString();
                txtNoCall.Text = appointment.CustomFields["NoCall"].ToString();
                txtSickSent.Text = appointment.CustomFields["SickSentHome"].ToString();
                txtRapor.Text = appointment.CustomFields["Rapor"].ToString();
                txtSentHome.Text = appointment.CustomFields["SentHome"].ToString();
                txtLate.Text = appointment.CustomFields["Late"].ToString();
                txtSuspend.Text = appointment.CustomFields["Suspend"].ToString();
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), @"Bir Hata Oluþtu.");
            }

            
            
        }
        public bool SaveFormData(Appointment appointment)
        {
            
            appointment.CustomFields["OverTime"] = txtOverTime.Text;
            appointment.CustomFields["ErkenGonderim"] = txtErkenGonderim.Text;
            appointment.CustomFields["SickCall"] = txtSicCall.Text;
            appointment.CustomFields["NoCall"] = txtNoCall.Text;
            appointment.CustomFields["SickSentHome"] = txtSickSent.Text;
            appointment.CustomFields["Rapor"] = txtRapor.Text;
            appointment.CustomFields["SentHome"] = txtSentHome.Text;
            appointment.CustomFields["Late"] = txtLate.Text;
            appointment.CustomFields["Suspend"] = txtSuspend.Text;
            appointment.CustomFields["Updatedby"] = labelControl2.Text;
            appointment.CustomFields["UpdatedAt"] = DateTime.Now;

            return true;
        }
        public bool IsAppointmentChanged(Appointment appointment)
        {
            appointment.CustomFields["OverTime"] = txtOverTime.Text;
            appointment.CustomFields["ErkenGonderim"] = txtErkenGonderim.Text;
            appointment.CustomFields["SickCall"] = txtSicCall.Text;
            appointment.CustomFields["NoCall"] = txtNoCall.Text;
            appointment.CustomFields["SickSentHome"] = txtSickSent.Text;
            appointment.CustomFields["Rapor"] = txtRapor.Text;
            appointment.CustomFields["SentHome"] = txtSentHome.Text;
            appointment.CustomFields["Late"] = txtLate.Text;
            appointment.CustomFields["Suspend"] = txtSuspend.Text;
            appointment.CustomFields["Updatedy"] = labelControl2.Text;
            appointment.CustomFields["UpdateAt"] = DateTime.Now;
            return true;
        }
        public void SetMenuManager(IDXMenuManager menuManager)
        {
            MenuManagerUtils.SetMenuManager(Controls, menuManager);
            MenuManager = menuManager;
        }

        internal void SetupPredefinedConstraints()
        {
            tbProgress.Properties.Minimum = AppointmentProcessValues.Min;
            tbProgress.Properties.Maximum = AppointmentProcessValues.Max;
            tbProgress.Properties.SmallChange = AppointmentProcessValues.Step;
            edtResources.Visible = true;
        }

        private void BindControllerToControls()
        {
            BindControllerToIcon();
            BindProperties(tbSubject, "Text", "Subject");
            BindProperties(tbLocation, "Text", "Location");
            BindProperties(tbDescription, "Text", "Description");
            BindProperties(edtShowTimeAs, "Status", "Status");
            BindProperties(edtStartDate, "EditValue", "DisplayStartDate");
            BindProperties(edtStartDate, "Enabled", "IsDateTimeEditable");
            BindProperties(edtStartTime, "EditValue", "DisplayStartTime");
            BindProperties(edtStartTime, "Visible", "IsTimeVisible");
            BindProperties(edtStartTime, "Enabled", "IsTimeVisible");
            BindProperties(edtEndDate, "EditValue", "DisplayEndDate", DataSourceUpdateMode.Never);
            BindProperties(edtEndDate, "Enabled", "IsDateTimeEditable", DataSourceUpdateMode.Never);
            BindProperties(edtEndTime, "EditValue", "DisplayEndTime", DataSourceUpdateMode.Never);
            BindProperties(edtEndTime, "Visible", "IsTimeVisible", DataSourceUpdateMode.Never);
            BindProperties(edtEndTime, "Enabled", "IsTimeVisible", DataSourceUpdateMode.Never);
            BindProperties(chkAllDay, "Checked", "AllDay");
            BindProperties(chkAllDay, "Enabled", "IsDateTimeEditable");

            BindProperties(edtResource, "ResourceId", "ResourceId");
            BindProperties(edtResource, "Enabled", "CanEditResource");
            BindToBoolPropertyAndInvert(edtResource, "Visible", "ResourceSharing");

            BindProperties(edtResources, "ResourceIds", "ResourceIds");
            BindProperties(edtResources, "Visible", "ResourceSharing");
            BindProperties(edtResources, "Enabled", "CanEditResource");
            BindProperties(lblResource, "Enabled", "CanEditResource");

            BindProperties(edtLabel, "Label", "Label");
            BindProperties(chkReminder, "Enabled", "ReminderVisible");
            BindProperties(chkReminder, "Visible", "ReminderVisible");
            BindProperties(chkReminder, "Checked", "HasReminder");
            BindProperties(cbReminder, "Enabled", "HasReminder");
            BindProperties(cbReminder, "Visible", "ReminderVisible");
            BindProperties(cbReminder, "Duration", "ReminderTimeBeforeStart");

            BindProperties(tbProgress, "Value", "PercentComplete");
            BindProperties(lblPercentCompleteValue, "Text", "PercentComplete", ObjectToStringConverter);
            BindProperties(progressPanel, "Visible", "ShouldEditTaskProgress");
            BindToBoolPropertyAndInvert(btnOk, "Enabled", "ReadOnly");
            BindToBoolPropertyAndInvert(btnRecurrence, "Enabled", "ReadOnly");
            BindProperties(btnDelete, "Enabled", "CanDeleteAppointment");
            BindProperties(btnRecurrence, "Visible", "ShouldShowRecurrenceButton");
        }

        private void BindControllerToIcon()
        {
            Binding binding = new Binding("Icon", Controller, "AppointmentType");
            binding.Format += AppointmentTypeToIconConverter;
            DataBindings.Add(binding);
        }

        private void ObjectToStringConverter(object o, ConvertEventArgs e)
        {
            e.Value = e.Value.ToString();
        }

        private void AppointmentTypeToIconConverter(object o, ConvertEventArgs e)
        {
            AppointmentType type = (AppointmentType)e.Value;
            e.Value = type == AppointmentType.Pattern ? RecurringIcon : NormalIcon;
        }

        private void BindProperties(Control target, string targetProperty, string sourceProperty, DataSourceUpdateMode updateMode = DataSourceUpdateMode.OnPropertyChanged)
        {
            target.DataBindings.Add(targetProperty, Controller, sourceProperty, true, updateMode);
        }

        private void BindProperties(Control target, string targetProperty, string sourceProperty, ConvertEventHandler objectToStringConverter)
        {
            Binding binding = new Binding(targetProperty, Controller, sourceProperty, true);
            binding.Format += objectToStringConverter;
            target.DataBindings.Add(binding);
        }

        private void BindToBoolPropertyAndInvert(Control target, string targetProperty, string sourceProperty)
        {
            target.DataBindings.Add(new BoolInvertBinding(targetProperty, Controller, sourceProperty));
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Controller == null)
                return;
            DataBindings.Add("Text", Controller, "Caption");
            SubscribeControlsEvents();
            LoadFormData(Controller.EditedAppointmentCopy);
            RecalculateLayoutOfControlsAffectedByProgressPanel();
        }

        private AppointmentFormController CreateController(SchedulerControl control, Appointment apt)
        {
            return new AppointmentFormController(control, apt);
        }
        void SubscribeEditorsEvents()
        {
            cbReminder.EditValueChanging += OnCbReminderEditValueChanging;
        }
        void SubscribeControllerEvents(AppointmentFormController controller)
        {
            if (controller == null)
                return;
            controller.PropertyChanged += OnControllerPropertyChanged;
        }
        void OnControllerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ReadOnly")
                UpdateReadonly();
        }

        private void UpdateReadonly()
        {
            if (Controller == null)
                return;
            IList<Control> controls = GetAllControls(this);
            foreach (Control control in controls)
            {
                BaseEdit editor = control as BaseEdit;
                if (editor == null)
                    continue;
                editor.ReadOnly = Controller.ReadOnly;
            }
            btnOk.Enabled = !Controller.ReadOnly;
            btnRecurrence.Enabled = !Controller.ReadOnly;
        }

        static List<Control> GetAllControls(Control rootControl)
        {
            List<Control> result = new List<Control>();
            foreach (Control control in rootControl.Controls)
            {
                result.Add(control);
                IList<Control> childControls = GetAllControls(control);
                result.AddRange(childControls);
            }
            return result;
        }

        internal void LoadIcons()
        {
            Assembly asm = typeof(SchedulerControl).Assembly;
            RecurringIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.RecurringAppointment, asm);
            NormalIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.Appointment, asm);
        }

        internal void SubscribeControlsEvents()
        {
            edtEndDate.Validating += OnEdtEndDateValidating;
            edtEndDate.InvalidValue += OnEdtEndDateInvalidValue;
            edtEndTime.Validating += OnEdtEndTimeValidating;
            edtEndTime.InvalidValue += OnEdtEndTimeInvalidValue;
            cbReminder.InvalidValue += OnCbReminderInvalidValue;
            cbReminder.Validating += OnCbReminderValidating;
            edtStartDate.Validating += OnEdtStartDateValidating;
            edtStartDate.InvalidValue += OnEdtStartDateInvalidValue;
            edtStartTime.Validating += OnEdtStartTimeValidating;
            edtStartTime.InvalidValue += OnEdtStartTimeInvalidValue;
        }

        internal void UnsubscribeControlsEvents()
        {
            edtEndDate.Validating -= OnEdtEndDateValidating;
            edtEndDate.InvalidValue -= OnEdtEndDateInvalidValue;
            edtEndTime.Validating -= OnEdtEndTimeValidating;
            edtEndTime.InvalidValue -= OnEdtEndTimeInvalidValue;
            cbReminder.InvalidValue -= OnCbReminderInvalidValue;
            cbReminder.Validating -= OnCbReminderValidating;
            edtStartDate.Validating -= OnEdtStartDateValidating;
            edtStartDate.InvalidValue -= OnEdtStartDateInvalidValue;
            edtStartTime.Validating -= OnEdtStartTimeValidating;
            edtStartTime.InvalidValue -= OnEdtStartTimeInvalidValue;
        }
        void OnBtnOkClick(object sender, EventArgs e)
        {
            OnOkButton();
        }

        internal void OnEdtStartTimeInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }

        internal void OnEdtStartTimeValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !Controller.ValidateLimitInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay);
        }

        internal void OnEdtStartDateInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }

        internal void OnEdtStartDateValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !Controller.ValidateLimitInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay);
        }

        internal void OnEdtEndDateValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsValidInterval();
            if (!e.Cancel)
            {
                var dataBinding = edtEndDate.DataBindings["EditValue"];
                dataBinding?.WriteValue();
            }
        }

        internal void OnEdtEndDateInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(!AppointmentFormControllerBase.ValidateInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay) ? SchedulerStringId.Msg_InvalidEndDate : SchedulerStringId.Msg_DateOutsideLimitInterval);
        }

        internal void OnEdtEndTimeValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsValidInterval();
            if (!e.Cancel)
            {
                var dataBinding = edtEndTime.DataBindings["EditValue"];
                dataBinding?.WriteValue();
            }
        }

        internal void OnEdtEndTimeInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(!AppointmentFormControllerBase.ValidateInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay) ? SchedulerStringId.Msg_InvalidEndDate : SchedulerStringId.Msg_DateOutsideLimitInterval);
        }

        internal bool IsValidInterval()
        {
            return AppointmentFormControllerBase.ValidateInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay) &&
                Controller.ValidateLimitInterval(edtStartDate.DateTime.Date, edtStartTime.Time.TimeOfDay, edtEndDate.DateTime.Date, edtEndTime.Time.TimeOfDay);
        }

        internal void OnOkButton()
        {
            if (!ValidateDateAndTime())
                return;
            if (!SaveFormData(Controller.EditedAppointmentCopy))
                return;
            if (!Controller.IsConflictResolved())
            {
                ShowMessageBox(SchedulerLocalizer.GetString(SchedulerStringId.Msg_Conflict), Controller.GetMessageBoxCaption(SchedulerStringId.Msg_Conflict), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Controller.IsAppointmentChanged() || Controller.IsNewAppointment || IsAppointmentChanged(Controller.EditedAppointmentCopy))
                Controller.ApplyChanges();

            DialogResult = DialogResult.OK;
        }
        private bool ValidateDateAndTime()
        {
            edtEndDate.DoValidate();
            edtEndTime.DoValidate();
            edtStartDate.DoValidate();
            edtStartTime.DoValidate();

            return String.IsNullOrEmpty(edtEndTime.ErrorText) && String.IsNullOrEmpty(edtEndDate.ErrorText) && String.IsNullOrEmpty(edtStartDate.ErrorText) && String.IsNullOrEmpty(edtStartTime.ErrorText);
        }

        internal DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return XtraMessageBox.Show(this, text, caption, buttons, icon);
        }
        void OnBtnDeleteClick(object sender, EventArgs e)
        {
            OnDeleteButton();
        }

        internal void OnDeleteButton()
        {
            if (IsNewAppointment)
                return;

            Controller.DeleteAppointment();

            DialogResult = DialogResult.Abort;
            Close();
        }
        void OnBtnRecurrenceClick(object sender, EventArgs e)
        {
            OnRecurrenceButton();
        }

        internal void OnRecurrenceButton()
        {
            if (!Controller.ShouldShowRecurrenceButton)
                return;

            Appointment patternCopy = Controller.PrepareToRecurrenceEdit();

            DialogResult result;
            using (Form form = CreateAppointmentRecurrenceForm(patternCopy, Control.OptionsView.FirstDayOfWeek))
            {
                result = ShowRecurrenceForm(form);
            }

            if (result == DialogResult.Abort)
            {
                Controller.RemoveRecurrence();
            }
            else if (result == DialogResult.OK)
            {
                Controller.ApplyRecurrence(patternCopy);
            }
        }

        private DialogResult ShowRecurrenceForm(Form form)
        {
            return FormTouchUIAdapter.ShowDialog(form, this);
        }

        internal Form CreateAppointmentRecurrenceForm(Appointment patternCopy, FirstDayOfWeek firstDayOfWeek)
        {
            AppointmentRecurrenceForm form = new AppointmentRecurrenceForm(patternCopy, firstDayOfWeek, Controller);
            form.SetMenuManager(MenuManager);
            form.LookAndFeel.ParentLookAndFeel = LookAndFeel;
            form.ShowExceptionsRemoveMsgBox = Controller.AreExceptionsPresent();
            return form;
        }
        internal void OnAppointmentFormActivated(object sender, EventArgs e)
        {
            if (OpenRecurrenceForm)
            {
                OpenRecurrenceForm = false;
                OnRecurrenceButton();
            }
        }

        internal void OnCbReminderValidating(object sender, CancelEventArgs e)
        {
            TimeSpan span = cbReminder.Duration;
            e.Cancel = (span == TimeSpan.MinValue) || (span.Ticks < 0);
            if (!e.Cancel)
            {
                var cbReminderDataBinding = cbReminder.DataBindings["Duration"];
                cbReminderDataBinding?.WriteValue();
            }
        }

        internal void OnCbReminderInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidReminderTimeBeforeStart);
        }

        internal void RecalculateLayoutOfControlsAffectedByProgressPanel()
        {
            if (progressPanel.Visible)
                return;
            int intDeltaY = progressPanel.Height;
            tbDescription.Location = new Point(tbDescription.Location.X, tbDescription.Location.Y - intDeltaY);
            tbDescription.Size = new Size(tbDescription.Size.Width, tbDescription.Size.Height + intDeltaY);
        }
        void OnCbReminderEditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue is TimeSpan)
                return;
            string stringValue = e.NewValue as String;
            TimeSpan duration = HumanReadableTimeSpanHelper.Parse(stringValue);
            if (duration.Ticks < 0)
                e.NewValue = TimeSpan.FromTicks(0);
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSicCall.Text = radioGroup1.EditValue.ToString();
        }

        private void radioGroup2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNoCall.Text = radioGroup2.EditValue.ToString();
        }

        private void radioGroup3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSickSent.Text = radioGroup3.EditValue.ToString();
        }

        private void radioGroup4_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSentHome.Text = radioGroup4.EditValue.ToString();
        }

        private void radioGroup5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLate.Text = radioGroup5.EditValue.ToString();
        }

        private void radioGroup6_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSuspend.Text = radioGroup6.EditValue.ToString();
        }

        private void radioGroup7_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRapor.Text = radioGroup7.EditValue.ToString();
        }

        private void frmAddOverTime_Shown(object sender, EventArgs e)
        {
            Text = @"Kesinti Ekleme";
        }
    }
}