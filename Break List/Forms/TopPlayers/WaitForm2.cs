using DevExpress.XtraWaitForm;

namespace Break_List.Forms.TopPlayers
{
    public partial class WaitForm2 : WaitForm
    {
        public WaitForm2()
        {
            InitializeComponent();
            progressPanel1.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            progressPanel1.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            progressPanel1.Description = description;
        }

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}