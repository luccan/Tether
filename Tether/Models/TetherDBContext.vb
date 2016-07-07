Imports System.Data.Entity

Public Class TetherDBContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=TetherConnection")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder) 'Do whatever superclass did

        modelBuilder.Entity(Of Schedule)().HasRequired(Function(m) m.AspNetUser).
            WithMany(Function(t) t.Schedules).HasForeignKey(Function(m) m.AspNetUserId).WillCascadeOnDelete(False)

        'modelBuilder.Entity(Of Booking)().HasRequired(Function(m) m.StudentSchedule).
        '    WithRequiredDependent(Function(t) t.Booking).Map(Function(m) m.MapKey()
        '.WillCascadeOnDelete(False)

        'modelBuilder.Entity(Of Booking)().HasRequired(Function(m) m.TutorSchedule).
        '    WithRequiredDependent(Function(t) t.Booking).WillCascadeOnDelete(False)
    End Sub
    Public Property Schedules As System.Data.Entity.DbSet(Of Schedule)
    Public Property AspNetUsers As System.Data.Entity.DbSet(Of AspNetUser)

End Class