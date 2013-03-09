using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace BookManageSystem.OCX
{
    class ocxDGVComboBox2
    {
        public DataTable SourceTable()//领书单的下拉框的选择
        {
            DataTable SourceTable = new DataTable();
            SourceTable.Columns.Add("ValueMember");
            SourceTable.Columns[0].DataType = typeof(int);
            SourceTable.Columns.Add("DisplayMember");
            DataRow newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 0;
            newRow["DisplayMember"] = "未审核";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 1;
            newRow["DisplayMember"] = "库存不足";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 2;
            newRow["DisplayMember"] = "班费不足";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 3;
            newRow["DisplayMember"] = "等待领书";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 4;
            newRow["DisplayMember"] = "确认收货";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 5;
            newRow["DisplayMember"] = "作废单";
            newRow.Table.Rows.Add(newRow);
            return SourceTable;
        }
        public void getState(ref DataGridView dataGridView1)
        {
            DataGridViewComboBoxColumn dgvComboBoxColumn;
            if (dataGridView1.Columns["ClmState3"] != null)
            {
                dgvComboBoxColumn = dataGridView1.Columns["ClmState3"] as DataGridViewComboBoxColumn;
            }
            else if (dataGridView1.Columns["ClmState2"] != null)
            {
                dgvComboBoxColumn = dataGridView1.Columns["ClmState2"] as DataGridViewComboBoxColumn;
            }
            else
            {
                dgvComboBoxColumn = dataGridView1.Columns["ClmState8"] as DataGridViewComboBoxColumn;
            }
            dgvComboBoxColumn.DataPropertyName = "state";
            dgvComboBoxColumn.DataSource = SourceTable();//必须在设置dataGridView1的DataSource的属性前设置
            dgvComboBoxColumn.DisplayMember = "DisplayMember";
            dgvComboBoxColumn.ValueMember = "ValueMember";

        }
    }
}
