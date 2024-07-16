# Exam Tracker
## All-in-one tool for examiners
![icon](https://github.com/user-attachments/assets/ef3b21f6-e2ab-4aeb-a0b5-64471ca849a8)

ExamTracker is an application created using Windows Forms and .NET core. It uses  
both SQLite and SQL Server to store data (the user can choose which one to use).  
It contains almost full localization for English and Polish that can be changed using a  
drop-down menu (ComboBox).

![login_page](https://github.com/user-attachments/assets/fd57e102-d023-446d-88b1-2f75f5ff3e29)

## Structure
Dependency injection is used to connect different repositories and databases.

![program_file](https://github.com/user-attachments/assets/f1bf800d-4a7d-4a47-a1c2-7e86373675a2)  

Data Access Layer structure was used to provide both interfaces and implementations  
(That also is for SQLite and SQL Server)  

![DAL_file](https://github.com/user-attachments/assets/baace92a-e069-4d79-8278-2072d6db9e0d)  

Here, we can see a part of an implementation, in this case, a custom event when the application  
encounters an error and retrieval of data from a database with the use of Dapper

![Matura_repo](https://github.com/user-attachments/assets/2d73639b-1bc0-4734-82b6-d76ea65f92ca)  

Next on the list is the main project and the files inside. They are categorized in folders in accordance to their function  

![examtracker_files](https://github.com/user-attachments/assets/e7148537-3e07-4f68-b3e1-9009735e95e0)

Below is a view from an example part of the file  

![ex1_file](https://github.com/user-attachments/assets/6980c925-986f-4af6-8706-492692b131a6)  
![ex2_file](https://github.com/user-attachments/assets/1dc7dacb-924e-4b95-8b35-4f8bfa59c8d2)

## Features
#### (Examples below)


- Creation and use of the account with data validation
- Account-assigned functionality and data (ex. students, invoices, etc.)
- Option to edit your profile
- Option to add and edit students
- Option to add events to your schedule (in the Schedule tab)
- Option to see, create and download invoices


## Account creation
### Just put in your information and click register. In case of some invalid data, a box will appear.
![register_page](https://github.com/user-attachments/assets/efe078da-dcbd-456f-a4ca-52c4637eaf7e)

## Profile edition
### Put the information you want to add / edit and skip the rest if desired.
![profil_page](https://github.com/user-attachments/assets/3b7d2b9c-0f84-4445-b7e3-2df66b6957b7)

## Adding student
### Provide information about the student. Some information is optional and can be provided / edited later.
![dashboard_panel](https://github.com/user-attachments/assets/7f4b82f5-ccc6-4ce4-81e2-6b23e97642b1)

## Adding events to your schedule  
#### Pick a date from the calendar, name and describe your event, and then click the button to add the event.  
### (Red means that the date has passed)  
![schedule_page](https://github.com/user-attachments/assets/93405b03-d4af-430d-bf66-8e694059090b)

## Invoice manipulation
### Added invoices are in the table ready to be downloaded when clicked on the pdf icon 
### If you desire to add an invoice you can add new items, provide data for them and click "Add invoice"
![invoices_page](https://github.com/user-attachments/assets/0e42337e-c48c-411b-929f-bd359b5ac832)

### Examplary invoice below
### (The looks of it can be change depending of ones needs)
![invoice_ex](https://github.com/user-attachments/assets/0e99a3c6-af57-4683-9993-3e01009de3c6)

