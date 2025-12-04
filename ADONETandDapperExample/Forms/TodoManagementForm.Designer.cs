namespace ADONETandDapperExample
{
    partial class TodoManagementForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            todosDataGridView = new DataGridView();
            titleTextBox = new TextBox();
            titleLabel = new Label();
            descriptionLabel = new Label();
            descriptionTextBox = new TextBox();
            createButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            clearButton = new Button();
            ((System.ComponentModel.ISupportInitialize)todosDataGridView).BeginInit();
            SuspendLayout();
            // 
            // todosDataGridView
            // 
            todosDataGridView.AllowUserToAddRows = false;
            todosDataGridView.AllowUserToDeleteRows = false;
            todosDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            todosDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            todosDataGridView.BackgroundColor = SystemColors.Control;
            todosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            todosDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            todosDataGridView.Location = new Point(12, 12);
            todosDataGridView.MultiSelect = false;
            todosDataGridView.Name = "todosDataGridView";
            todosDataGridView.ReadOnly = true;
            todosDataGridView.RowHeadersVisible = false;
            todosDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            todosDataGridView.Size = new Size(776, 309);
            todosDataGridView.TabIndex = 0;
            todosDataGridView.DataBindingComplete += todosDataGridView_DataBindingComplete;
            todosDataGridView.Click += todosDataGridView_Click;
            // 
            // titleTextBox
            // 
            titleTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleTextBox.Location = new Point(12, 349);
            titleTextBox.MaxLength = 128;
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(776, 25);
            titleTextBox.TabIndex = 1;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(12, 324);
            titleLabel.Margin = new Padding(0, 0, 3, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(338, 22);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Title";
            // 
            // descriptionLabel
            // 
            descriptionLabel.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            descriptionLabel.Location = new Point(12, 376);
            descriptionLabel.Margin = new Padding(0, 0, 3, 0);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(338, 22);
            descriptionLabel.TabIndex = 3;
            descriptionLabel.Text = "Description";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            descriptionTextBox.Location = new Point(12, 401);
            descriptionTextBox.MaxLength = 425;
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.ScrollBars = ScrollBars.Vertical;
            descriptionTextBox.Size = new Size(426, 136);
            descriptionTextBox.TabIndex = 4;
            // 
            // createButton
            // 
            createButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            createButton.ForeColor = Color.Green;
            createButton.Location = new Point(444, 401);
            createButton.Name = "createButton";
            createButton.Size = new Size(169, 34);
            createButton.TabIndex = 5;
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // updateButton
            // 
            updateButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            updateButton.ForeColor = Color.FromArgb(255, 128, 0);
            updateButton.Location = new Point(444, 441);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(169, 34);
            updateButton.TabIndex = 6;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = SystemColors.ControlLightLight;
            deleteButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            deleteButton.ForeColor = Color.Red;
            deleteButton.Location = new Point(619, 441);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(169, 34);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // clearButton
            // 
            clearButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            clearButton.Location = new Point(619, 401);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(169, 34);
            clearButton.TabIndex = 8;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // TodoManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(clearButton);
            Controls.Add(deleteButton);
            Controls.Add(updateButton);
            Controls.Add(createButton);
            Controls.Add(descriptionTextBox);
            Controls.Add(descriptionLabel);
            Controls.Add(titleLabel);
            Controls.Add(titleTextBox);
            Controls.Add(todosDataGridView);
            Name = "TodoManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Todos";
            Load += TodoManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)todosDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView todosDataGridView;
        private TextBox titleTextBox;
        private Label titleLabel;
        private Label descriptionLabel;
        private TextBox descriptionTextBox;
        private Button createButton;
        private Button updateButton;
        private Button deleteButton;
        private Button clearButton;
    }
}
