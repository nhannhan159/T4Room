Room Management
==================================

Requirements
------------
* Visual Studio 12 or greater
* SQL Server 2008 or greater

Development
-----------
* Step 1: open RoomM.sln in folder RoomM by Visual Studio 2012 (minimum version).
* Step 2: build whole solution to restore nuget packages. (click F6).
* Step 4: create db "room_mgr" in your sql server.
* Step 5: change your db source in connection string "Data Source=TIENTQ" -> "Data Source=[your source]" in:
    - RoomM.WebApp / Web.config: 2 places.
    - RoomM.DeskApp / App.config: 1 place.
    - RoomM.Repositories / App.config: 1 place.
* Step 6: Set "RoomM.Repositories" to "startup project" by right click to this and select "Set as StartUp Project" then run project (clicking Start). It will generate all table in "room_mgr" add seed data.
* Step 7: Finally, you can run "RoomM.WebApp" or ""RoomM.DeskApp" by "Set as StartUp Project" and "Start".
