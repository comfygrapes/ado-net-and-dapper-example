using ADONETandDapperExample.Data;
using ADONETandDapperExample.Entities;
using ADONETandDapperExample.Repositories;
using System;
using System.ComponentModel;
using System.Reflection;

namespace ADONETandDapperExample
{
    public partial class TodoManagementForm : Form
    {
        public TodoManagementForm()
        {
            InitializeComponent();
        }

        private string _connectionString;
        private long _lastSelectedTodoId;
        private BindingList<Todo> _todos;
        private ITodoRepository _todoRepository;

        private void TodoManagementForm_Load(object sender, EventArgs e)
        {
            _connectionString = DatabaseConfig.GetConnectionString();
            _todoRepository = new AdoTodoRepository(_connectionString);
            ReloadTodos();
        }

        private void ReloadTodos()
        {
            if (todosDataGridView.CurrentRow != null)
            {
                _lastSelectedTodoId = (long)todosDataGridView.CurrentRow.Cells[0].Value;
            }
            else
            {
                _lastSelectedTodoId = 0;
            }

            _todos = new BindingList<Todo>(_todoRepository.GetAll().ToList());
            todosDataGridView.DataSource = _todos;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text) || string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Title or Description is empty.", "Validation Failed");
                return;
            }

            var todo = new Todo
            {
                Title = titleTextBox.Text,
                Description = descriptionTextBox.Text,
            };

            _todoRepository.Create(todo);

            ReloadTodos();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            titleTextBox.Text = string.Empty;
            descriptionTextBox.Text = string.Empty;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (todosDataGridView.CurrentRow == null)
            {
                MessageBox.Show("No Todo Selected.", "No Selection");
                return;
            }

            if (string.IsNullOrWhiteSpace(titleTextBox.Text) || string.IsNullOrWhiteSpace(descriptionTextBox.Text))
            {
                MessageBox.Show("Title or Description is empty.", "Validation Failed");
                return;
            }

            var todo = new Todo
            {
                Id = (long)todosDataGridView.CurrentRow.Cells[0].Value,
                Title = titleTextBox.Text,
                Description = descriptionTextBox.Text,
            };

            _todoRepository.Update(todo);

            ReloadTodos();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (todosDataGridView.CurrentRow == null)
            {
                MessageBox.Show("No Todo Selected.", "No Selection");
                return;
            }

            var id = (long)todosDataGridView.CurrentRow.Cells[0].Value;

            _todoRepository.Delete(id);

            ReloadTodos();
        }

        // Keeps the row selection
        private void todosDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (_lastSelectedTodoId != 0)
            {
                foreach (DataGridViewRow row in todosDataGridView.Rows)
                {
                    if (row.Cells[0].Value is long id && id == _lastSelectedTodoId)
                    {
                        todosDataGridView.CurrentCell = row.Cells[0];
                        row.Selected = true;
                        return;
                    }
                }
            }
        }

        private void todosDataGridView_Click(object sender, EventArgs e)
        {
            if (todosDataGridView.CurrentRow != null)
            {
                var row = todosDataGridView.CurrentRow;

                titleTextBox.Text = (row.Cells["title"]?.Value as string) ?? string.Empty;
                descriptionTextBox.Text = (row.Cells["description"]?.Value as string) ?? string.Empty;
            }
        }
    }
}
