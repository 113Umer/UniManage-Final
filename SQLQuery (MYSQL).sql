-- Create the UniManage Database
CREATE DATABASE UniManage;
USE UniManage;

-- Create the Students table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY AUTO_INCREMENT,  -- Auto-incrementing StudentID
    FullName VARCHAR(100) NOT NULL,            -- Full Name of the student
    Email VARCHAR(100) NOT NULL UNIQUE,        -- Email Address, must be unique
    Password VARCHAR(255) NOT NULL             -- Password (hashed, larger size for security)
);

-- Create the Subjects table
CREATE TABLE Subjects (
    SubjectID INT PRIMARY KEY AUTO_INCREMENT,  -- Auto-incrementing SubjectID
    StudentID INT,                             -- Foreign Key to Students table
    SubjectName VARCHAR(100) NOT NULL,         -- Name of the Subject (including course code if needed)
    Description VARCHAR(255),                  -- Subject description
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE
);

-- Create the Assignments table
CREATE TABLE Assignments (
    AssignmentID INT PRIMARY KEY AUTO_INCREMENT, -- Auto-incrementing AssignmentID
    StudentID INT,                               -- Foreign Key to Students table
    SubjectID INT,                               -- Foreign Key to Subjects table
    Title VARCHAR(100) NOT NULL,                 -- Assignment title
    Description VARCHAR(255),                    -- Assignment description
    AssignmentType VARCHAR(50),                  -- Type of assignment (e.g., Homework, Project)
    DueDate DATE,                                -- Due date for the assignment
    AssignmentValue DECIMAL(5,2),                -- Assignment weight/marks value
    AssignmentResult DECIMAL(5,2),               -- Assignment result/marks obtained
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID) ON DELETE CASCADE
);

-- Insert sample data into Students
INSERT INTO Students (FullName, Email, Password) VALUES
('Oliver Smith', 'oliver.smith@email.com', 'Password123!'),
('Amelia Johnson', 'amelia.j@email.com', 'Password123!'),
('Harry Williams', 'harry.williams@email.com', 'Password123!'),
('Isla Brown', 'isla.brown@email.com', 'Password123!'),
('Jack Jones', 'jack.jones@email.com', 'Password123!'),
('Mia Taylor', 'mia.taylor@email.com', 'Password123!'),
('Noah Davis', 'noah.davis@email.com', 'Password123!'),
('Sophia Wilson', 'sophia.wilson@email.com', 'Password123!'),
('George Moore', 'george.moore@email.com', 'Password123!'),
('Ava White', 'ava.white@email.com', 'Password123!');

-- Insert sample data into Subjects
INSERT INTO Subjects (StudentID, SubjectName, Description) VALUES
(1, 'Math 101', 'Introduction to Algebra'),
(2, 'Physics 201', 'Fundamentals of Physics'),
(3, 'Chemistry 301', 'Organic Chemistry'),
(4, 'Computer Science 101', 'Intro to Programming with C++'),
(5, 'History 101', 'World History'),
(6, 'Biology 101', 'General Biology'),
(7, 'Math 201', 'Advanced Calculus'),
(8, 'Literature 101', 'Introduction to English Literature'),
(9, 'Economics 101', 'Microeconomics'),
(10, 'Statistics 101', 'Introduction to Statistics');

-- Insert sample data into Assignments
INSERT INTO Assignments (StudentID, SubjectID, Title, Description, AssignmentType, DueDate, AssignmentValue, AssignmentResult) VALUES
(1, 1, 'Algebra Assignment 1', 'Solve linear equations', 'Homework', '2024-10-10', 100, 90),
(2, 2, 'Physics Lab 1', 'Study the laws of motion', 'Lab', '2024-10-15', 100, 85),
(3, 3, 'Organic Chemistry Assignment', 'Study functional groups', 'Homework', '2024-10-20', 100, 88),
(4, 4, 'C++ Programming Project', 'Build a simple calculator', 'Project', '2024-11-01', 100, 92),
(5, 5, 'World History Essay', 'Write an essay on WWII', 'Essay', '2024-10-25', 100, 95),
(6, 6, 'Biology Assignment 1', 'Study cell biology', 'Homework', '2024-10-30', 100, 87),
(7, 7, 'Calculus Midterm', 'Integration techniques', 'Exam', '2024-11-05', 100, 80),
(8, 8, 'Literature Analysis', 'Analyze Shakespeare’s works', 'Essay', '2024-11-10', 100, 90),
(9, 9, 'Microeconomics Assignment 1', 'Supply and demand curves', 'Homework', '2024-11-15', 100, 89),
(10, 10, 'Statistics Project', 'Analyze a dataset', 'Project', '2024-11-20', 100, 93);

-- Query tables
SELECT * FROM Students;
SELECT * FROM Subjects;
SELECT * FROM Assignments;

-- Drop tables if needed
-- DROP TABLE IF EXISTS Assignments;
-- DROP TABLE IF EXISTS Subjects;
-- DROP TABLE IF EXISTS Students;
