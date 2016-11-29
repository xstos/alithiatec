using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TableDiff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable first=new DataTable(),second=new DataTable();
            DX.LoadData(first, @"C:\Users\aaa\Desktop\tblData_CA_Trace20091016_old.csv",",");
            DX.LoadData(second, @"C:\Users\aaa\Desktop\tblData_CA_Trace20091016_old.csv", ",");
            string[] pkeyCols = "FKMediaServer,FKAgent,FKExtension,FKEmployee,FKTrunk,FKQueue,FKAnsweringAgentGroup,FKDNIS,FKAccountCode,FKANI,ANI".Split(',').ToArray();
            string[] valueCols = first.GetColumnNames().ToHashSet().SetSubtract(pkeyCols.ToHashSet()).ToArray();
            DataTable matches;
            first.DiffWith(second, pkeyCols, valueCols, out matches);
            DataTable diffreport=DX.GenerateDiffReport2(matches, first, pkeyCols, DX.Arr("pkey"), null);
        }
    }
}
