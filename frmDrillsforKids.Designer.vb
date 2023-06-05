<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDrillsforKids
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtAnswer = New TextBox()
        btnNext = New Button()
        Label1 = New Label()
        lblAnswer = New Label()
        lblproblem = New Label()
        SuspendLayout()
        ' 
        ' txtAnswer
        ' 
        txtAnswer.Location = New Point(143, 220)
        txtAnswer.Name = "txtAnswer"
        txtAnswer.Size = New Size(201, 23)
        txtAnswer.TabIndex = 0
        ' 
        ' btnNext
        ' 
        btnNext.Font = New Font("Perpetua", 15.75F, FontStyle.Italic, GraphicsUnit.Point)
        btnNext.Location = New Point(163, 274)
        btnNext.Name = "btnNext"
        btnNext.Size = New Size(163, 35)
        btnNext.TabIndex = 1
        btnNext.Text = "Next"
        btnNext.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Perpetua", 21.75F, FontStyle.Italic, GraphicsUnit.Point)
        Label1.Location = New Point(114, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(259, 33)
        Label1.TabIndex = 2
        Label1.Text = "Arithmetic Drills For Kids"
        ' 
        ' lblAnswer
        ' 
        lblAnswer.AutoSize = True
        lblAnswer.Font = New Font("Perpetua", 15.75F, FontStyle.Italic, GraphicsUnit.Point)
        lblAnswer.Location = New Point(64, 220)
        lblAnswer.Name = "lblAnswer"
        lblAnswer.Size = New Size(63, 24)
        lblAnswer.TabIndex = 3
        lblAnswer.Text = "Answer:"
        ' 
        ' lblproblem
        ' 
        lblproblem.BorderStyle = BorderStyle.FixedSingle
        lblproblem.Location = New Point(143, 64)
        lblproblem.Name = "lblproblem"
        lblproblem.Size = New Size(201, 127)
        lblproblem.TabIndex = 4
        ' 
        ' frmDrillsforKids
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GradientInactiveCaption
        ClientSize = New Size(493, 390)
        Controls.Add(lblproblem)
        Controls.Add(lblAnswer)
        Controls.Add(Label1)
        Controls.Add(btnNext)
        Controls.Add(txtAnswer)
        Name = "frmDrillsforKids"
        Text = "Arithmetic Drills for Kids"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtAnswer As TextBox
    Friend WithEvents btnNext As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAnswer As Label
    Friend WithEvents lblproblem As Label
End Class
