Imports System.Data.SqlClient
Imports System.Configuration

NotInheritable Class ConfigHandler

    Public Shared Function GetConfigValues(
            keyValue1 As String,
            Optional keyValue2 As String = Nothing,
            Optional keyValue3 As String = Nothing,
            Optional keyValue4 As String = Nothing,
            Optional keyValue5 As String = Nothing) As List(Of String)

        Dim returnValue As New List(Of String)

        Using synergyConn As New SqlConnection(ConfigurationManager.ConnectionStrings("Synergy").ToString())
            Using configCmd As New SqlCommand(ConfigurationManager.AppSettings("GetConfigValuesProc"), synergyConn)

                configCmd.CommandType = CommandType.StoredProcedure
                configCmd.Parameters.AddWithValue("Key1", keyValue1)

                If keyValue2 IsNot Nothing Then
                    configCmd.Parameters.AddWithValue("Key2", keyValue2)
                End If
                If keyValue3 IsNot Nothing Then
                    configCmd.Parameters.AddWithValue("Key3", keyValue3)
                End If
                If keyValue4 IsNot Nothing Then
                    configCmd.Parameters.AddWithValue("Key4", keyValue4)
                End If
                If keyValue5 IsNot Nothing Then
                    configCmd.Parameters.AddWithValue("Key5", keyValue5)
                End If

                synergyConn.Open()

                Using configDataReader As SqlDataReader = configCmd.ExecuteReader()

                    If configDataReader.HasRows Then
                        While configDataReader.Read()
                            returnValue.Add(configDataReader("Value").ToString)
                        End While
                        Return returnValue
                    Else
                        Return Nothing
                    End If

                End Using
            End Using
        End Using

    End Function

End Class
