

Imports System.Windows.Forms
Imports System.Threading
Public Class frmDrillsforKids

    'Declare your Variables
    Private score As Integer
    Private problemIndex As Integer
    Private problems As List(Of String)


    Private Sub frmDrillsforkids_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            BeginDrill()
        Catch ex As Exception
            MessageBox.Show("An error occurred. The program will now exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
    Private Sub BeginDrill()
        score = 0
        problemIndex = 0
        problems = Nothing
        'generate problems in the background while allowing the main thread to continue excuting other tasks.
        'e.g displaying the first problem and interacting with the user.
        'In this way the interface will not freeze or become unresponsive.

        Dim problemGenerationThread As New Thread(AddressOf GenerateProblems)
        problemGenerationThread.Start()

        'program will wait for problemGenerationThread to finish executing the GenerateProblems method
        'before calling ShowProblem

        problemGenerationThread.Join()

        ShowProblem()
    End Sub
    Private Sub GenerateProblems()
        Try
            Dim random1 As New Random()
            Dim problemsList As New List(Of String)()

            For i As Integer = 1 To 10
                Dim num1 As Integer
                Dim num2 As Integer
                Dim operSymbol As Char

                'generate random value between 1(inclusive) and 5(exclusive) then excutes the select case based
                'on the random value e.g random value 1 = case 1 etc.
                'Case 4 makes sure the problem given is divisible and it does not have a reminder.

                Select Case random1.Next(1, 5)
                    Case 1
                        num1 = random1.Next(0, 50)
                        num2 = random1.Next(0, 50)
                        operSymbol = "+"
                    Case 2
                        num1 = random1.Next(0, 50)
                        num2 = random1.Next(0, 50)
                        operSymbol = "-"
                    Case 3
                        num1 = random1.Next(0, 12)
                        num2 = random1.Next(0, 12)
                        operSymbol = "×"
                    Case 4
                        num2 = random1.Next(1, 12)
                        num1 = num2 * random1.Next(1, 12)
                        operSymbol = "÷"
                End Select

                Dim problem As String = $"{num1} {operSymbol} {num2}"
                problemsList.Add(problem)
            Next

            problems = problemsList
        Catch ex As Exception
            MessageBox.Show("An error occurred while generating problems.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    Private Sub ShowProblem()
        If problems IsNot Nothing AndAlso problemIndex < problems.Count Then
            lblproblem.Text = $"Problem #{problemIndex + 1}: {problems(problemIndex)}"
            txtAnswer.Text = ""
        Else
            ' If the problems is Nothing or problemIndex is out of range.
            ' Display an error message
            MessageBox.Show("An error occurred while displaying the problem.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            Dim userAnswer As Decimal

            'LINE 104 and LINE 105: checks if the user's input is a valid Decimal using Decimal.TryParse. 
            'If the user answer is correct ,passes it to the CheckAnswer function along with the corresponding problem.
            'If the answer is correct, it increments the score variable by 1.

            'If the answer is correct or incorrect, a messagebox will pop up and say correct or incorrect.
            'The problemIndex will increment, as long the problemIndex is less than the problem.count which Is <= 10, the next problem will be presented to the user. 
            'When the problemIndex is equals 10 then the showScore() method will be called.
            'When the user enters a wrong input,messagebox will display Invalid Input.


            If Decimal.TryParse(txtAnswer.Text, userAnswer) Then
                If CheckAnswer(problems(problemIndex), userAnswer) Then
                    score += 1
                    MessageBox.Show("Correct!", "Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Incorrect!", "Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                problemIndex += 1

                If problemIndex < problems.Count Then
                    ShowProblem()
                Else
                    ShowScore()
                End If
            Else
                MessageBox.Show(" Please enter a valid input.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error occurred,The program will now exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub
    Private Sub ShowScore()
        MessageBox.Show($"Drill done! Your score: {score} out of 10", "Drill done", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim result As DialogResult = MessageBox.Show("Do you want to restart the drill?", "Restart Drill", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            BeginDrill()
        Else
            Close()
        End If
    End Sub
    Private Function CheckAnswer(problem As String, userAnswer As Integer) As Boolean
        Try
            'line 146 :splits the problem string into an array of strings.
            'The array "parts",will have three elements:the string representation of num1, operSymbol, and num2.

            'line 147:parses the first element of the parts array (parts(0)) into an integer and assigns to num1 variable.
            'line 148:takes the first character of the second element of the parts array (parts(1)) and assigns to operSymbol variable.
            'line 149:parses the third element of the parts array (parts(2)) into an integer and assigns to num2 variable.

            Dim parts As String() = problem.Split(" ")
            Dim num1 As Integer = Integer.Parse(parts(0))
            Dim operSymbol As Char = parts(1)(0)
            Dim num2 As Integer = Integer.Parse(parts(2))

            Select Case operSymbol
                Case "+"
                    Return userAnswer = num1 + num2
                Case "-"
                    Return userAnswer = num1 - num2
                Case "×"
                    Return userAnswer = num1 * num2
                Case "÷"
                    Return userAnswer = num1 / num2
                Case Else
                    Return False
            End Select
        Catch ex As Exception
            Throw New Exception("An error occurred while checking the answer.")
        End Try
    End Function

End Class
