using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace BookManageSystem.OCX
{
    class ocxDGVComboBox
    {
        private DataTable SourceTable()
        {
            DataTable SourceTable = new DataTable();
            SourceTable.Columns.Add("ValueMember");
            SourceTable.Columns[0].DataType = typeof(int);
            SourceTable.Columns.Add("DisplayMember");
            DataRow newRow = SourceTable.NewRow();            
            newRow["ValueMember"] = 0;
            newRow["DisplayMember"] = "δ���";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 5;
            newRow["DisplayMember"] = "��ֹͨ��";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 1;
            newRow["DisplayMember"] = "���ͨ��";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 2;
            newRow["DisplayMember"] = "������";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 3;
            newRow["DisplayMember"] = "������";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 3;
            newRow["DisplayMember"] = "������";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 4;
            newRow["DisplayMember"] = "�����";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 6;
            newRow["DisplayMember"] = "�˻���";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 5;
            newRow["DisplayMember"] = "���ϵ�";
            newRow.Table.Rows.Add(newRow);
            return SourceTable;
        }
        public void getState(ref DataGridView dataGridView1)
        {
            DataGridViewComboBoxColumn dgvComboBoxColumn;
            if (dataGridView1.Columns["ClmState"]!=null)
            {
                dgvComboBoxColumn = dataGridView1.Columns["ClmState"] as DataGridViewComboBoxColumn;
            }
            else if (dataGridView1.Columns["ClmState2"]!=null)
            { 
                dgvComboBoxColumn = dataGridView1.Columns["ClmState2"] as DataGridViewComboBoxColumn;
            }
            else 
            { 
                dgvComboBoxColumn = dataGridView1.Columns["ClmState8"] as DataGridViewComboBoxColumn;
            }
            dgvComboBoxColumn.DataPropertyName = "state";
            dgvComboBoxColumn.DataSource= SourceTable();//����������dataGridView1��DataSource������ǰ����
            dgvComboBoxColumn.DisplayMember = "DisplayMember";
            dgvComboBoxColumn.ValueMember = "ValueMember";

        }
    }
}
