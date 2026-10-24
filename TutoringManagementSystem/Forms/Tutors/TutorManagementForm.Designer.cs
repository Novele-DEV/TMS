namespace Tutoring_Management_System
{
    partial class TutorManagementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TutorManagementForm));
            this.byteBetter_TutoringDataSet = new Tutoring_Management_System.ByteBetter_TutoringDataSet();
            this.tutorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tutorTableAdapter = new Tutoring_Management_System.ByteBetter_TutoringDataSetTableAdapters.TutorTableAdapter();
            this.tableAdapterManager = new Tutoring_Management_System.ByteBetter_TutoringDataSetTableAdapters.TableAdapterManager();
            this.tutorBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tutorBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.tutorDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddTutor = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.byteBetter_TutoringDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tutorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tutorBindingNavigator)).BeginInit();
            this.tutorBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tutorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // byteBetter_TutoringDataSet
            // 
            this.byteBetter_TutoringDataSet.DataSetName = "ByteBetter_TutoringDataSet";
            this.byteBetter_TutoringDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tutorBindingSource
            // 
            this.tutorBindingSource.DataMember = "Tutor";
            this.tutorBindingSource.DataSource = this.byteBetter_TutoringDataSet;
            // 
            // tutorTableAdapter
            // 
            this.tutorTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AdministratorTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CourseTableAdapter = null;
            this.tableAdapterManager.StudentManagementTableAdapter = null;
            this.tableAdapterManager.StudentTableAdapter = null;
            this.tableAdapterManager.TutorAvailabilityTableAdapter = null;
            this.tableAdapterManager.TutoringReportTableAdapter = null;
            this.tableAdapterManager.TutoringRequestTableAdapter = null;
            this.tableAdapterManager.TutoringSessionTableAdapter = null;
            this.tableAdapterManager.TutorManagementTableAdapter = null;
            this.tableAdapterManager.TutorQualificationsTableAdapter = null;
            this.tableAdapterManager.TutorTableAdapter = this.tutorTableAdapter;
            this.tableAdapterManager.UpdateOrder = Tutoring_Management_System.ByteBetter_TutoringDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tutorBindingNavigator
            // 
            this.tutorBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tutorBindingNavigator.BindingSource = this.tutorBindingSource;
            this.tutorBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tutorBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tutorBindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tutorBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tutorBindingNavigatorSaveItem});
            this.tutorBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.tutorBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tutorBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tutorBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tutorBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tutorBindingNavigator.Name = "tutorBindingNavigator";
            this.tutorBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tutorBindingNavigator.Size = new System.Drawing.Size(1179, 27);
            this.tutorBindingNavigator.TabIndex = 0;
            this.tutorBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 24);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tutorBindingNavigatorSaveItem
            // 
            this.tutorBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tutorBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tutorBindingNavigatorSaveItem.Image")));
            this.tutorBindingNavigatorSaveItem.Name = "tutorBindingNavigatorSaveItem";
            this.tutorBindingNavigatorSaveItem.Size = new System.Drawing.Size(29, 24);
            this.tutorBindingNavigatorSaveItem.Text = "Save Data";
            this.tutorBindingNavigatorSaveItem.Click += new System.EventHandler(this.tutorBindingNavigatorSaveItem_Click);
            // 
            // tutorDataGridView
            // 
            this.tutorDataGridView.AutoGenerateColumns = false;
            this.tutorDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.tutorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tutorDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.tutorDataGridView.DataSource = this.tutorBindingSource;
            this.tutorDataGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.tutorDataGridView.Location = new System.Drawing.Point(105, 80);
            this.tutorDataGridView.Name = "tutorDataGridView";
            this.tutorDataGridView.RowHeadersWidth = 51;
            this.tutorDataGridView.RowTemplate.Height = 24;
            this.tutorDataGridView.Size = new System.Drawing.Size(931, 402);
            this.tutorDataGridView.TabIndex = 1;
            this.tutorDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tutorDataGridView_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Tutor_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tutor_ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Tutor_FName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Tutor_FName";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Tutor_LName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Tutor_LName";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Tutor_Email";
            this.dataGridViewTextBoxColumn4.HeaderText = "Tutor_Email";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Tutor_Phone";
            this.dataGridViewTextBoxColumn5.HeaderText = "Tutor_Phone";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Tutor_AcademicAverage";
            this.dataGridViewTextBoxColumn6.HeaderText = "Tutor_AcademicAverage";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Tutor_PreferredMode";
            this.dataGridViewTextBoxColumn7.HeaderText = "Tutor_PreferredMode";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // btnAddTutor
            // 
            this.btnAddTutor.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddTutor.Location = new System.Drawing.Point(218, 532);
            this.btnAddTutor.Name = "btnAddTutor";
            this.btnAddTutor.Size = new System.Drawing.Size(144, 62);
            this.btnAddTutor.TabIndex = 2;
            this.btnAddTutor.Text = "Add Tutor";
            this.btnAddTutor.UseVisualStyleBackColor = false;
            this.btnAddTutor.Click += new System.EventHandler(this.btnAddTutor_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEdit.Location = new System.Drawing.Point(546, 532);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(128, 62);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnBack.Location = new System.Drawing.Point(843, 532);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 62);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // TutorManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1179, 619);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddTutor);
            this.Controls.Add(this.tutorDataGridView);
            this.Controls.Add(this.tutorBindingNavigator);
            this.Name = "TutorManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tutor Management";
            this.Load += new System.EventHandler(this.TutorManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.byteBetter_TutoringDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tutorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tutorBindingNavigator)).EndInit();
            this.tutorBindingNavigator.ResumeLayout(false);
            this.tutorBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tutorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ByteBetter_TutoringDataSet byteBetter_TutoringDataSet;
        private System.Windows.Forms.BindingSource tutorBindingSource;
        private ByteBetter_TutoringDataSetTableAdapters.TutorTableAdapter tutorTableAdapter;
        private ByteBetter_TutoringDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tutorBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tutorBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView tutorDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button btnAddTutor;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnBack;
    }
}