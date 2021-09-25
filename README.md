# SQLMonitor
SQL Server 2016 and higher session monitor

This is a utility that will show detailed information on the performance of SQL Server 2016 and higher.  

It shows Server/ Database and Session information to help determine what is happening on a database server.

Current work on this application is working on an alerting system to alert when the monitor detects possible issues like locking, server disconnect, high cpu usage and others.

The aim is to enhance this application and seperate out the monitor to a windows service that will store monitored data over a long time period.

I would like to thank the developers of SQLLite and PagerDutyAPI for their packages used in this application.  The licenses for these are found in the main branch.
