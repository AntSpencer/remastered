Imports System.Linq.Expressions
Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting.Lifetime

Module Module1
    Dim round As Integer = 0
    Dim userchoice(4) As String
    Dim compchoice(4) As String
    Dim results(4) As String
    Dim titleG As String = (".-. .-. .-. . .     .-. .-. .-. .-. .-.     .-. .-. .-. .-. .-. .-. .-. .-.
|(  | | |   |<      |-' |-| |-' |-  |(      `-. |    |  `-. `-. | | |(  `-.
' ' `-' `-' ' ` ,   '   ` ' '   `-' ' ' ,   `-' `-' `-' `-' `-' `-' ' ' `-'
    _______           _______               _______
---'   ____)      ---'   ____)____     ---'    ____)____
      (_____)               ______)               ______)
      (_____)               _______)           __________)
      (____)               _______)           (____)
---.__(___)       ---.__________)      ---.__(___)

")
    Sub Main()
        ASCII()
        Dim cmpMove As String
        Dim yourMove As String
        Dim res As String
        Do

            Console.WriteLine(titleG)

            yourMove = Usermove()
            cmpMove = Compmove()
            res = Determine(yourMove, cmpMove)
            Type($"And the user put down {yourMove}" & vbNewLine)
            Type($"And the computer put down {cmpMove}" & vbNewLine)
            If res = "TIE" Then
                Type("And its a tie this round!!!")
            Else
                Type($"And the result of this match is: {res}" & vbNewLine)
            End If
            Threading.Thread.Sleep(3000)
            Console.Clear()
            results(round) = res
            round += 1
        Loop While round <= 4
        Table()
        Percent()
    End Sub
    ''' <summary>
    '''  prompts the user for a number that will then be converted to its respective string variant
    ''' </summary>
    ''' <returns></returns>
    ''' 
    Function Usermove() As String
        Dim input As String
        Dim pass As Boolean = False
        Dim prompt As String = "Please enter a 1 For ROCK, a 2 For PAPER, And a 3 For SCISSORS >> "
        Do
            Type(prompt)
            input = Console.ReadLine
            If input = 1 Then
                userchoice(round) = "ROCK    "
                Return "ROCK"
                pass = True
            ElseIf input = 2 Then
                userchoice(round) = "PAPER   "
                Return "PAPER"
                pass = True
            ElseIf input = 3 Then
                userchoice(round) = "SCISSORS"
                Return "SCISSORS"
                pass = True
            Else
                Console.WriteLine("Invalid input. please try again")
                Return "invalid"
            End If
        Loop While pass = False
    End Function 'DONE
    Function Compmove() As String
        Dim randomnum As New Random
        Dim choice As Integer = randomnum.Next(1, 4)
        If choice = 1 Then
            compchoice(round) = "ROCK    "
            Return "ROCK"
        ElseIf choice = 2 Then
            compchoice(round) = "PAPER   "
            Return "PAPER"
        ElseIf choice = 3 Then
            compchoice(round) = "SCISSORS"
            Return "SCISSORS"
        Else
            Return "INVALID"
        End If
        Console.Clear()
        Console.WriteLine(compchoice)
    End Function
    Function Determine(user As String, cmp As String) As String
        If user = cmp Then
            Return "TIE "
        ElseIf (user = "ROCK" AndAlso cmp = "PAPER") OrElse (user = "PAPER" AndAlso cmp = "SCISSORS") OrElse (user = "SCISSORS" AndAlso cmp = "ROCK") Then
            Return "LOSS"
        ElseIf (cmp = "ROCK" AndAlso user = "PAPER") OrElse (cmp = "PAPER" AndAlso user = "SCISSORS") OrElse (cmp = "SCISSORS" AndAlso user = "ROCK") Then
            Return "WIN "
        Else
            Return "INVALID"
        End If
    End Function
    Sub Table()
        Console.Clear()
        Console.WriteLine("#".PadLeft(100, "#"))
        Console.WriteLine("".PadLeft(47) & "RESULT")
        Console.WriteLine("-".PadLeft(100, "-"))
        For i As Integer = 0 To 4
            tableRow(i, userchoice(i), compchoice(i), results(i))
        Next
    End Sub
    Sub tableRow(i As Integer, user As String, cmp As String, results As String)
        Console.WriteLine("Round {0} | Users choice: {1}| Computers Choice {2}| Results: {3}|", i, user, cmp, results)
        Console.WriteLine("-".PadRight(100, "-"))
    End Sub
    Sub ASCII()
        Dim rand As New Random
        Dim random As Integer = rand.Next(0, 4)
        Dim title As String = (".-. .-. .-. . .     .-. .-. .-. .-. .-.     .-. .-. .-. .-. .-. .-. .-. .-.
|(  | | |   |<      |-' |-| |-' |-  |(      `-. |    |  `-. `-. | | |(  `-.
' ' `-' `-' ' ` ,   '   ` ' '   `-' ' ' ,   `-' `-' `-' `-' `-' `-' ' ' `-'
")

        Dim rock As String = ("
    _______                         _______
---'   ____)                       (____   '___
      (_____)                     (_____)
      (_____)                     (_____)
      (____)                       (____)
---.__(___)                         (___)__.---

")
        Dim resultthing As String = ("
    _______                         _______
---'   ____)                   ____(____   '___
      (_____)                 (_____) 
      (_____)                 (_____)
      (____)                     (____)
---.__(___)                         (___)__.---

")

        Dim paper As String = ("
     _______ 
---'    ____)____ 
           ______)
          _______)
          _______)
---.__________) 

")

        Dim scissors As String = ("
     _______
---'    ____)____
           ______)
         __________)
        (____)
---.__(___)

")

        Dim loope As Integer = 0
        Do
            For i As Integer = 0 To 13 ' ADJUST THIS NUMBER TO MAKE ANIMATION GO LONGER OR SHORTER
                Console.Clear()
                Console.WriteLine(title)
                For x As Integer = 0 To i
                    Console.WriteLine()
                Next
                Console.WriteLine(rock)
                Threading.Thread.Sleep(20)
            Next
            loope += 1
        Loop While loope <> 3
        Console.Clear()
        Console.WriteLine(title & vbNewLine & resultthing)
        Threading.Thread.Sleep(2000)
        Console.WriteLine(title & vbNewLine & rock)
        Console.ReadLine()
        Console.Clear()
        Console.WriteLine(titleG)
        Console.WriteLine("Press any key to continue")
        Console.ReadLine()
        Console.Clear()

    End Sub
    Sub Type(str As String)
        For i As Integer = 0 To str.Length - 1
            Console.Write(str(i))
            Threading.Thread.Sleep(5)
        Next
    End Sub
    Sub Percent()
        Dim totalW As Double
        Dim totalL As Double
        Dim totalT As Double
        For i As Integer = 0 To 4
            If results(i) = "WIN " Then
                totalW += 1
            ElseIf results(i) = "LOSS" Then
                totalL += 1
            ElseIf results(i) = "TIE " Then
                totalT += 1
            End If
        Next
        totalW /= 5
        totalW *= 100

        totalL /= 5
        totalL *= 100

        totalT /= 5
        totalT *= 100

        Console.WriteLine($"Win percent:  {totalW.ToString("N2")}%")
        Console.WriteLine($"Loss percent: {totalL.ToString("N2")}%")
        Console.WriteLine($"Tie percent:  {totalW.ToString("N2")}%")
        Console.WriteLine(DeterminWin(totalW, totalL, totalT))

    End Sub
    Function DeterminWin(W As Integer, L As Integer, T As Integer) As String
        If W > L AndAlso W > T Then
            Return "USER WINS!"
        ElseIf L > W AndAlso L > T Then
            Return "COMPUTER WINS!"
        ElseIf T > W AndAlso T > L Then
            Return "TIE"
        Else
            Return "INVALID"
        End If
    End Function
End Module
