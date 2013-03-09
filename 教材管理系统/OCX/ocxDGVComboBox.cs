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
            newRow["DisplayMember"] = "未审核";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 5;
            newRow["DisplayMember"] = "禁止通过";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 1;
            newRow["DisplayMember"] = "审核通过";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 2;
            newRow["DisplayMember"] = "交涉中";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 3;
            newRow["DisplayMember"] = "发货中";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 3;
            newRow["DisplayMember"] = "发货中";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 4;
            newRow["DisplayMember"] = "已入库";
            newRow.Table.Rows.Add(newRow);
            newRow = SourceTable.NewRow();
            newRow["ValueMember"] = 6;
            newRow["DisplayMember"] = "退货单";
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
            dgvComboBoxColumn.DataSource= SourceTable();//必须在设置dataGridView1的DataSource的属性前设置
            dgvComboBoxColumn.DisplayMember = "DisplayMember";
            dgvComboBoxColumn.ValueMember = "ValueMember";

        }
    }
}
