
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






-- الاختصاصات
CREATE TABLE Specializations (
    SpecializationId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200)
);


-- الاطباء
CREATE TABLE Doctors (
    DoctorId INT IDENTITY(1,1) PRIMARY KEY,
    PersonId INT NOT NULL,
    SpecializationId INT NOT NULL,
    Notes NVARCHAR(500),

    CONSTRAINT FK_Doctors_Persons
        FOREIGN KEY (PersonId) REFERENCES Persons(PersonId),

    CONSTRAINT FK_Doctors_Specializations
        FOREIGN KEY (SpecializationId) REFERENCES Specializations(SpecializationId)
);


-- ربط المواعيد مع الطبيب
ALTER TABLE Appointments
ADD DoctorId INT;

ALTER TABLE Appointments
ADD CONSTRAINT FK_Appointments_Doctors
FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId);




-- ربط الزيارات مع الطبيب
ALTER TABLE Visits
ADD DoctorId INT;

ALTER TABLE Visits
ADD CONSTRAINT FK_Visits_Doctors
FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId);





-- جدول المدفوعات
CREATE TABLE Payments (
    PaymentId INT IDENTITY(1,1) PRIMARY KEY,          -- رقم الدفع  مفتاح أساسي 

    PersonId INT NOT NULL,                            -- المريض الذي قام بالدفع
    VisitId INT NULL,                                 -- الزيارة المرتبطة بالدفع (اختياري)
    AppointmentId INT NULL,                           -- الموعد المرتبط بالدفع (اختياري)

    Amount DECIMAL(10,2) NOT NULL,                    -- مبلغ الدفع
    Discount DECIMAL(10,2) DEFAULT 0,                 -- الخصم إن وجد
    TotalAmount AS (Amount - Discount) PERSISTED,     -- المبلغ النهائي بعد الخصم (عمود محسوب)

    PaymentMethod NVARCHAR(100),                      -- طريقة الدفع (كاش، بطاقة، تحويل...)
    PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),  -- تاريخ ووقت الدفع

    CreatedBy INT NULL,                               -- المستخدم الذي سجل الدفع
    Notes NVARCHAR(500),                              -- ملاحظات إضافية

    CONSTRAINT FK_Payments_Persons
        FOREIGN KEY (PersonId) REFERENCES Persons(PersonId),

    CONSTRAINT FK_Payments_Visits
        FOREIGN KEY (VisitId) REFERENCES Visits(VisitId),

    CONSTRAINT FK_Payments_Appointments
        FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId),

    CONSTRAINT FK_Payments_Users
        FOREIGN KEY (CreatedBy) REFERENCES Users(UserId)
);





-- الرواتب
CREATE TABLE Salaries (
    SalaryId INT IDENTITY(1,1) PRIMARY KEY,  --  مفتاح أساسي 
    UserId INT NOT NULL, -- الموظف الذي ينتمي له هذا الراتب
    Amount DECIMAL(10,2) NOT NULL,-- قيمة الراتب
    StartDate DATE NOT NULL,-- تاريخ بدء العمل بهذا الراتب
    EndDate DATE NULL,-- تاريخ انتهاء هذا الراتب (NULL يعني الراتب الحالي)
    Notes NVARCHAR(500),-- ملاحظات إضافية (اختياري)
    

    CONSTRAINT FK_Salaries_Users
        FOREIGN KEY (UserId) REFERENCES Users(UserId)
);
