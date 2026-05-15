
-- 
CREATE TABLE Roles (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(200)
);

 


-- 
CREATE TABLE Persons (
    PersonId INT  IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(200),
    LastName NVARCHAR(200),
    Gender NVARCHAR(50),
    BirthDate DATE,
    Phone NVARCHAR(100),
    Address NVARCHAR(300),
    CreatedAt DATETIME,
    UpdatedAt DATETIME
);



--
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    PersonId INT,
    RoleId INT,
    Username NVARCHAR(200),
    Password NVARCHAR(200),
    IsActive BIT,

    CONSTRAINT FK_Users_Persons 
        FOREIGN KEY (PersonId) REFERENCES Persons(PersonId),

    CONSTRAINT FK_Users_Roles 
        FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);



--
CREATE TABLE Logs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT,
    Action NVARCHAR(300),
    Timestamp DATETIME,
    RecordID INT,
    Details NVARCHAR(500),
    DateTime DATETIME,

    CONSTRAINT FK_Logs_Users
        FOREIGN KEY (UserId) REFERENCES Users(UserId)
);


--
CREATE TABLE VisitTypes (
    VisitTypeId INT IDENTITY(1,1) PRIMARY KEY,
    TypeName NVARCHAR(200),
    Description NVARCHAR(500)
);



--
CREATE TABLE Appointments (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    PersonId INT,
    VisitTypeId INT,
    AppointmentDate DATETIME,
    Status NVARCHAR(100),
    Notes NVARCHAR(500),

    CONSTRAINT FK_Appointments_Persons
        FOREIGN KEY (PersonId) REFERENCES Persons(PersonId),

    CONSTRAINT FK_Appointments_VisitTypes
        FOREIGN KEY (VisitTypeId) REFERENCES VisitTypes(VisitTypeId)
);




--
CREATE TABLE Visits (
    VisitId INT  IDENTITY(1,1) PRIMARY KEY,
    PersonId INT,
    VisitTypeId INT,
    VisitDate DATETIME,
    Notes NVARCHAR(500),

    CONSTRAINT FK_Visits_Persons
        FOREIGN KEY (PersonId) REFERENCES Persons(PersonId),

    CONSTRAINT FK_Visits_VisitTypes
        FOREIGN KEY (VisitTypeId) REFERENCES VisitTypes(VisitTypeId)
);





--
CREATE TABLE Patients (
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    PersonId INT,
    MedicalNotes NVARCHAR(500),
    FirstVisitDate NVARCHAR(100),
    ChronicDiseases NVARCHAR(500),
    Allergies NVARCHAR(500),
    Notes NVARCHAR(500),
    ComplianceScore INT,

    CONSTRAINT FK_Patients_Persons
        FOREIGN KEY (PersonId) REFERENCES Persons(PersonId)
);

