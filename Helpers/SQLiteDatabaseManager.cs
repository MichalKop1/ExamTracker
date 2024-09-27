using System.Data;
using System.Data.SQLite;
using System.Configuration;
using System;
using Dapper;
using System.Runtime.CompilerServices;


namespace DataAcessLayer
{
    public class SQLiteDatabaseManager
    {
        public event Action<string> OnError = delegate { };
        public SQLiteDatabaseManager()
        {
            InitializeDatabase(ConnectionHelper.SQLiteConnectionString);
        }

        private void InitializeDatabase(string connectionString)
        {
            string dbFilePath = new SQLiteConnectionStringBuilder(connectionString).DataSource;
            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
            }
            CreateTables(connectionString);
        }

        private void CreateTables(string connectionString)
        {
            List<string> tables = new List<string>();
            tables.Add(@"CREATE TABLE IF NOT EXISTS Accounts (
                        acc_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        login nvarchar(24) NOT NULL,
                        password nvarchar(30) NOT NULL,
	                    email nvarchar(50) NOT NULL,
	                    contactName nvarchar(100) NOT NULL,
	                    businessName nvarchar(100),
	                    streetAdress nvarchar(120),
	                    city nvarchar(50),
	                    state nvarchar(50),
	                    zipCode nvarchar(20),	
	                    phoneNumber nvarchar(16)
                        );");
            tables.Add(@"CREATE TABLE IF NOT EXISTS Students (
                        student_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        name VARCHAR(50) NOT NULL,
                        surname VARCHAR(50) NOT NULL,
                        age INTEGER,
                        email VARCHAR(70),
                        examType VARCHAR(20) NOT NULL,
                        teacher_id INTEGER
                        );");
            tables.Add(@"CREATE TABLE IF NOT EXISTS Grade8Exams (
                        exam_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        student_id INTEGER NOT NULL,
                        date DATE NOT NULL,
                        exercise1 INTEGER NOT NULL,
                        exercise2 INTEGER NOT NULL,
                        exercise3 INTEGER NOT NULL,
                        exercise4 INTEGER NOT NULL,
                        exercise5 INTEGER NOT NULL,
                        exercise6 INTEGER NOT NULL,
                        exercise7 INTEGER NOT NULL,
                        exercise8 INTEGER NOT NULL,
                        exercise9 INTEGER NOT NULL,
                        exercise10 INTEGER NOT NULL,
	                    exercise11 INTEGER NOT NULL,
	                    exercise12 INTEGER NOT NULL,
	                    exercise13 INTEGER NOT NULL,
	                    exercise14 INTEGER NOT NULL,
                        total_score INTEGER NOT NULL,
                        FOREIGN KEY (student_id) REFERENCES Students(student_id)
                        );");
            tables.Add(@"CREATE TABLE IF NOT EXISTS MaturaExams (
                        exam_id INTEGER PRIMARY KEY AUTOINCREMENT,
                        student_id INTEGER NOT NULL,
                        date DATE NOT NULL,
                        exercise1 INTEGER NOT NULL,
                        exercise2 INTEGER NOT NULL,
                        exercise3 INTEGER NOT NULL,
                        exercise4 INTEGER NOT NULL,
                        exercise5 INTEGER NOT NULL,
                        exercise6 INTEGER NOT NULL,
                        exercise7 INTEGER NOT NULL,
                        exercise8 INTEGER NOT NULL,
                        exercise9 INTEGER NOT NULL,
                        exercise10 INTEGER NOT NULL,
                        total_score INTEGER NOT NULL,
                        FOREIGN KEY (student_id) REFERENCES Students(student_id)
                        );");
            tables.Add(@"CREATE TABLE IF NOT EXISTS Events (
	                    event_id INTEGER PRIMARY KEY AUTOINCREMENT,
	                    event_type INTEGER,
	                    long_desc TEXT,
	                    short_desc NVARCHAR(50),
	                    acc_id INTEGER,
	                    event_date DATE,
	                    FOREIGN KEY (acc_id) REFERENCES Accounts(acc_id)
                        )");
            tables.Add(@"CREATE TABLE IF NOT EXISTS Invoices (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        InvoiceNumber TEXT NOT NULL,
                        DateOfIssue TEXT NOT NULL,
                        DateOfSale TEXT NOT NULL,
                        DateOfPayment TEXT NOT NULL,
                        PaymentMethod TEXT,
                        Buyer TEXT NOT NULL,
                        BuyersAddress TEXT,
                        Seller TEXT NOT NULL,
                        SellersAddress TEXT,
                        NumberOfAccount TEXT,
                        Currency TEXT,
                        Remarks TEXT,
                        TotalGross INTEGER NOT NULL,
                        TotalNet INTEGER NOT NULL,
                        AccountId INTEGER NOT NULL,
                        UniqueIdentifier INTEGER NOT NULL
                        );");
            tables.Add(@"CREATE TABLE IF NOT EXISTS ProductServices (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Description TEXT NOT NULL,
                        NumberOfItems INTEGER NOT NULL,
                        UnitPrice INTEGER NOT NULL,
                        TotalGrossPrice INTEGER NOT NULL,
                        UniqueId INTEGER NOT NULL
                        );");
            try
            {
                using (IDbConnection connection = new SQLiteConnection(connectionString))
                {
                    foreach(string tableQuery in tables)
                    {
                        connection.Execute(tableQuery);
                    }
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message);
            }

        }
    }
}
