using DevExpress.Data;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Orgs.Module.BusinessObjects;
using System;
using System.Linq;
using System.Windows;

namespace Orgs.Module.Win.Controllers
{
    public static class HolderFunctions
    {
        public static class HandyXAFWinFunctions
        {
            public static GridView GetGridView(View view)
            {
                if (!(view is ListView view1)) return null;
                var listView = view1;
                if (listView.Editor is GridListEditor grid) return grid.GridView;
                return null;
            }

            public static WinWindow GetWinIfOpen(XafApplication application, string listViewId)
            {
                if (!(application.ShowViewStrategy is WinShowViewStrategyBase strategy)) return null;
                foreach (var win in strategy.Windows.ToArray())
                {
                    if (win.View == null) continue;
                    if (!win.View.Id.Equals(listViewId)) continue;
                    return win;
                    //win.View.Close();


                }
                return null;
            }

            public static bool CloseViewIfOpen(XafApplication application, string listViewId)
            {
                if (!(application.ShowViewStrategy is WinShowViewStrategyBase strategy)) return false;
                foreach (var win in strategy.Windows.ToArray())
                {
                    if (win.View == null) continue;
                    if (!win.View.Id.Equals(listViewId)) continue;
                    win.View.Close();
                    return true;
                }
                return false;
            }

           

            internal static void RefreshAndWarnMismatchIfNeeded(IFilterHolder holder, CompositeView view)
            {

                var recordCount = holder.ApplyFilter();
                 

                //HandyXAFFunctions.WarnRecordsCountIfNeeded(recordCount);

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

                    var gridEditor = lv.Editor as GridListEditor;
                    gv = gridEditor.GridView;

                    //   lv.RefreshDataSource();
                    lvCount = gv.RowCount;


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


            public static int FindRowHandleByRowObject(GridView view, IToggleRHS row)
            {
                if (row == null) return GridControl.InvalidRowHandle;
                for (var i = 0; i < view.DataRowCount; i++)
                    if (row.Equals(view.GetRow(i)))
                        return i;
                if (row is not IToggleRHS ext) throw new Exception("Cant find row ");
                {
                    for (var i = 0; i < view.DataRowCount; i++)
                    {
                        var rowJ = view.GetRow(i) as IToggleRHS;
                        if (ext.Key == rowJ.Key)
                            return i;
                    }
                }
                throw new Exception("Cant find row ");
            }


            public static void RefreshView(View view)
            {
                view.ObjectSpace.Refresh();
                view.Refresh(true);
            }

            public static void SelectRowInListView(ListView lv, IToggleRHS obj)
            {
                var ed = lv.Editor as GridListEditor;
                var gv = ed.GridView;
                var rowHandle = FindRowHandleByRowObject(gv, obj);
                gv.FocusedRowHandle = rowHandle;
                gv.ClearSelection();
                gv.SelectRow(rowHandle);
            }


            public static void EnsureSortedByColumn(ListView listView, string fieldName)
            {
                var editor = listView.Editor as GridListEditor;
                var gv = editor.GridView;

                var colSort = gv.Columns.SingleOrDefault(x => x.FieldName == fieldName);
                var gcsi = new GridColumnSortInfo(colSort, ColumnSortOrder.Ascending);
                gv.SortInfo.ClearAndAddRange(new[] { gcsi });
                gv.OptionsCustomization.AllowSort = false;
            }
        }
        public static bool OpenFeature(IFilterHolder holder, XafApplication application, SimpleActionExecuteEventArgs e)
        {
            var holderTYpe = holder.GetType();
            var viewId = application.FindDetailViewId(holderTYpe);



            var os = application.CreateObjectSpace(typeof(Customer));  // any valid type would have done
            holder.ObjectSpace = os;
            var recordCount = holder.ApplyFilter();
            var maxCount =1000;
            if (recordCount == maxCount)
            {
                MessageBox.Show(@$"There are more than {maxCount} records available, but only {maxCount} can be shown. 
                    Consider refining your filter or increasing the configuration");
            }


            var win = HandyXAFWinFunctions.GetWinIfOpen(application, viewId);
            if (win != null)
            {
                win.View.CurrentObject = holder;
                win.View.RefreshDataSource();
                e.ShowViewParameters.CreatedView = win.View;
            }
            else
            {
                var detailView = application.CreateDetailView(os, holder);
                e.ShowViewParameters.CreatedView = detailView;
            }

            e.ShowViewParameters.NewWindowTarget = NewWindowTarget.MdiChild;

            e.ShowViewParameters.TargetWindow = TargetWindow.NewWindow;
            return true;


        }



        public static bool SwitchToViewIfOpen(XafApplication application, string viewId)
        {
            if (!(application.ShowViewStrategy is WinShowViewStrategyBase strategy)) return false;
            foreach (var win in strategy.Windows.ToArray())
            {
                if (win.View == null) continue;
                if (!win.View.Id.Equals(viewId)) continue;
                win.Show();
                return true;

            }
            return false;
        }
        public static DevExpress.ExpressApp.View GetOpenView(XafApplication application, string viewId)
        {
            if (!(application.ShowViewStrategy is WinShowViewStrategyBase strategy)) return null;
            foreach (var win in strategy.Windows.ToArray())
            {
                if (win.View == null) continue;

                if (!win.View.Id.Equals(viewId)) continue;

                return win.View;

            }
            return null;
        }


    
}
}