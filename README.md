# Tether

## Setting up

Clone Project

Open vbproject (tested w/ VS2013 Ultimate)

###### Re-attaching local database
Tools > NuGet Package Manager > Package Manager Console
```
  sqllocaldb.exe stop v11.0
  sqllocaldb.exe delete v11.0
```
  
You can choose to include the newly created .mdf and .ldf file under Tether/App_Data/

Run Project
