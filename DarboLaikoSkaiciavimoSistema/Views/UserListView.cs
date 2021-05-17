using DarboLaikoSkaiciavimoSistema.Cache;
using DarboLaikoSkaiciavimoSistema.Controllers;
using DarboLaikoSkaiciavimoSistema.Controls;
using System;
using System.Data;
using System.Windows.Forms;

namespace DarboLaikoSkaiciavimoSistema.Views
{
    /// <summary>
    /// Naudotojų sąrašo lango klasė.
    /// </summary>
    public partial class UserListView : FormLocalized
    {
        /// <summary>
        /// Naudotojų sąrašo stulpeliai.
        /// </summary>
        private enum dgvUsersCollumns
        { 
            WorktimeWeek = 9,
            WorktimeMonth = 10,
            Edit = 11,
            Delete = 12
        }

        /// <summary>
        /// Naudotojų sąrašo lango klasės konstruktorius.
        /// </summary>
        public UserListView()
        {
            InitializeComponent();
            SetLocalization();
        }

        /// <summary>
        /// Naudotojų sąrašo lango teksto nustatymas.
        /// </summary>
        public override void SetLocalization()
        {
            backNavigatorControl1.Refresh();
            userInfoControl1.Refresh();
            this.Text = lblUserListLabel.Text = Properties.Strings.userListViewName;
            nameDataGridViewTextBoxColumn.HeaderText = Properties.Strings.lblName;
            surnameDataGridViewTextBoxColumn.HeaderText = Properties.Strings.lblSurname;
            worktimeWeek.HeaderText = Properties.Strings.lblTimeWorkedThisWeek;
            worktimeMonth.HeaderText = Properties.Strings.lblTimeWorkedThisMonth;
            btnEdit.Text = Properties.Strings.btnEdit;
            btnDelete.Text = Properties.Strings.btnDelete;
        }

        /// <summary>
        /// Naudotojų sąrašo duomenų atnaujinimas.
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();
            this.userTableAdapter.Dispose();
            this.userTableAdapter.Fill(this.dbUsers.User);
        }

        /// <summary>
        /// Naudotojų sąrašo lango užkrovimo apdorojimas.
        /// </summary>
        private void UserListView_Load(object sender, EventArgs e)
        {
            this.userTableAdapter.Fill(this.dbUsers.User);
            userWorktimeTimer.Start();
        }

        /// <summary>
        /// Naudotojų sąrašo lango uždarymo apdorojimas.
        /// </summary>
        private void UserListView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (((UserListView)sender).ActiveControl is BackNavigatorControl) return;
            Application.Exit();
        }

        /// <summary>
        /// Naudotojų sąrašo langelio paspaudimo apdorojimas.
        /// </summary>
        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var senderGrid = (DataGridView)sender;
            switch (e.ColumnIndex)
            {
                case (int)dgvUsersCollumns.Edit:
                    this.Hide();
                    UserEditView userEditView = new UserEditView(UserController.GetUserByID((int)((DataRowView)senderGrid.Rows[e.RowIndex].DataBoundItem).Row["id"]));
                    userEditView.ShowDialog(this);
                    userEditView.Dispose();
                    break;
                case (int)dgvUsersCollumns.Delete:
                    if (MessageBox.Show(Properties.Strings.warningDeleteUser, Properties.Strings.warningTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
                    int index = (int)((DataRowView)senderGrid.Rows[e.RowIndex].DataBoundItem).Row["id"];
                    senderGrid.Rows.RemoveAt(e.RowIndex);
                    this.userWorktimeTimer.Stop();
                    bool remove = UserController.RemoveUser(UserController.GetUserByID(index), this.Handle);
                    if (!remove)
                    {
                        MessageBox.Show(Properties.Strings.errAccessController, Properties.Strings.errTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (LocalCache.GetLastUserId() == index) Application.Exit();
                    this.Refresh();
                    this.userWorktimeTimer.Start();
                    break;
            }
        }

        /// <summary>
        /// Naudotojų sąrašo langelio atvaizdavimo apdorojimas.
        /// </summary>
        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            switch (e.ColumnIndex)
            {
                case (int)dgvUsersCollumns.WorktimeWeek:
                    string valueWeek = WorkingTimeController.UserTimeWorkedThisWeek((int)((DataRowView)senderGrid.Rows[e.RowIndex].DataBoundItem).Row["id"]);
                    if (valueWeek.Equals(Properties.Strings.errTitle)) userWorktimeTimer.Stop();
                    e.Value = valueWeek;
                    break;
                case (int)dgvUsersCollumns.WorktimeMonth:
                    string valueMonth = WorkingTimeController.UserTimeWorkedThisMonth((int)((DataRowView)senderGrid.Rows[e.RowIndex].DataBoundItem).Row["id"]);
                    if (valueMonth.Equals(Properties.Strings.errTitle)) userWorktimeTimer.Stop();
                    e.Value = valueMonth;
                    break;
            }
        }

        /// <summary>
        /// Naudotojų darbo laiko apskaičiavimo laikmačio sutiksėjimo apdorojimas.
        /// </summary>
        private void userWorktimeTimer_Tick(object sender, EventArgs e)
        {
            dgvUsers.Refresh();
        }
    }
}
