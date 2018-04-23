using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace ChangeScrollValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            schedulerControl1.MouseWheel += new MouseEventHandler(schedulerControl1_MouseWheel);
        }

        void schedulerControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            TimeSpan topRowTime = schedulerControl1.DayView.TopRowTime;
            TimeInterval ti = new TimeInterval(schedulerControl1.ActiveView.SelectedInterval.Start.Date, topRowTime);
            if ((e.Delta > 0 && ti.Duration.TotalSeconds == 0) || (e.Delta < 0 && ti.Duration.TotalHours == 24))
                return;
            TimeSpan delta = TimeSpan.FromMinutes(schedulerControl1.DayView.TimeScale.TotalMinutes * 2);
            if (e.Delta > 0)
            {
                if (topRowTime.TotalMinutes < delta.TotalMinutes)
                    schedulerControl1.DayView.TopRowTime = delta;
                else
                    schedulerControl1.DayView.TopRowTime = topRowTime - delta;
            }
            else { 
                TimeSpan day = TimeSpan.FromDays(1);
                if ((day - topRowTime).TotalMinutes < delta.TotalMinutes)
                    schedulerControl1.DayView.TopRowTime = day;
                else
                    schedulerControl1.DayView.TopRowTime = topRowTime + delta;
            }            
        }        
    }
}
