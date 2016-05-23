Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity

Public Enum ScheduleStatus As Integer
    Free = 0
    Taken = 1
End Enum

Public Class Schedule
    <Key>
    Public Property Id As Long

    Public Property TutorId As String

    <ForeignKey("TutorId")>
    Public Property Tutor As AspNetUser

    Public Property StudentId As String

    <ForeignKey("StudentId")>
    Public Property Student As AspNetUser

    <Required>
    Public Property StartTime As TimeSpan

    <Required>
    Public Property EndTime As TimeSpan

    <Required>
    Public Property Status As ScheduleStatus

End Class

Public Class ScheduleDBContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=TetherConnection")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Schedule)().HasRequired(Function(m) m.Tutor).
            WithMany(Function(t) t.Tutor_Schedules).HasForeignKey(Function(m) m.TutorId).WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Schedule)().HasRequired(Function(m) m.Student).
            WithMany(Function(t) t.Student_Schedules).HasForeignKey(Function(m) m.StudentId).WillCascadeOnDelete(False)
    End Sub
    Public Property Schedules As System.Data.Entity.DbSet(Of Schedule)
    Public Property AspNetUsers As System.Data.Entity.DbSet(Of AspNetUser)

End Class