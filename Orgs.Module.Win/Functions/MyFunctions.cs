using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid.Views.Grid;
using Orgs.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Orgs.Module.Win.Functions
{
    internal static class MyFunctions
    {
        internal static void WarnRecordsCountIfNeeded(int recordCount)
        {
            var maxCount = 1000;
            if (recordCount == maxCount)
            {
                MessageBox.Show(@$"There are more than {maxCount} records available, but only {maxCount} can be shown. 
                    Consider refining your filter or increasing the configuration");
            }
        }
        internal static void RefreshAndWarnMismatchIfNeeded(IFilterHolder holder, CompositeView view)
        {

            int recordCount = holder.ApplyFilter();
            view.CurrentObject = holder;
            view.RefreshDataSource();
            

            WarnRecordsCountIfNeeded(recordCount);

            GridView gv = null;
            var detailView = view as DetailView;
            int lvCount = 0;
            ListView lv;
            var counter = 0;
            foreach (ListPropertyEditor lpe in detailView.GetItems<ListPropertyEditor>())
            {
                counter++;

                lv = lpe.ListView;
                lv.CollectionSource.ResetCollection(true);
                view.Refresh();
                var gridEditor = lv.Editor as GridListEditor;
                gv = gridEditor.GridView;

                lv.RefreshDataSource();
                lvCount = gv.RowCount;
                if (lvCount != recordCount)
                {
                    gv.RefreshData();
                    lvCount = gv.RowCount;
                }




            }
            if (counter != 1)
            {
                throw new Exception("Expected 1 and only 1 lv");
            }
            if (lvCount != recordCount)
            {

                MessageBox.Show($"Record count {recordCount}, lvCount {lvCount} . Work around by closing and reopening.");
                //view.RefreshDataSource();
            }

        }

        
    }
}
