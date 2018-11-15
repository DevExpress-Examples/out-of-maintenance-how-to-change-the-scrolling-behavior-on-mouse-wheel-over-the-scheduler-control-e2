<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/ChangeScrollValue/Form1.cs) (VB: [Form1.vb](./VB/ChangeScrollValue/Form1.vb))
<!-- default file list end -->
# How to change the scrolling behavior on mouse wheel over the scheduler control


<p>I want to change the scrolling behavior on mouse wheel over the scheduler control. How can I change it?</p>


<h3>Description</h3>

<p>You should handle the <a href="http://www.devexpress.com/Help/?document=xtrascheduler/devexpressxtraschedulerschedulercontrolclasseventstopic.htm">XtraScheduler.MouseWheel</a> event to accomplish and set the <a href="http://www.devexpress.com/Help/?document=xtrascheduler/devexpressxtraschedulerdayview_toprowtimetopic.htm">DayView.TopRowTime</a> property to set corresponding value to accomplish this task.</p>

<br/>


