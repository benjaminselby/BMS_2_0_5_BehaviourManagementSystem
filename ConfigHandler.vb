Imports System.Data.SqlClient
Imports System.Configuration

Public Class ConfigHandler

    Private Function GetConfigValue(keyValue As String) As String

        ' Load configuration settings from the BMS config database table. 

        Using synergyConn As New SqlConnection(ConfigurationManager.ConnectionStrings("SynergyOneConnectionString").ToString())

            Using configCmd As New SqlCommand(ConfigurationManager.AppSettings("GetConfigValueProc"), synergyConn)

                ' The GetConfigValue procedure should be configured such that it only returns 1 record. 
                configCmd.CommandType = CommandType.StoredProcedure
                configCmd.Parameters.AddWithValue("Key", keyValue)

                synergyConn.Open()

                Using configDataReader As SqlDataReader = configCmd.ExecuteReader()

                    If configDataReader.HasRows Then
                        configDataReader.Read()
                        If configDataReader("Value").ToString.Trim = "" Then
                            Throw New System.Configuration.SettingsPropertyNotFoundException
                        End If
                        Return configDataReader("Value").ToString
                    Else
                        Throw New System.Configuration.SettingsPropertyNotFoundException
                    End If

                End Using
            End Using
        End Using

        ' Default return value. 
        Return Nothing

    End Function


    Public Sub SetConfigValue(Of T)(ByRef var As Object, configValueKey As String)

        Try

            ' Need to convert to Object via CObj to get this cast statement to work. 
            var = CType(CObj(GetConfigValue(configValueKey)), T)

        Catch ex As System.Configuration.SettingsPropertyNotFoundException

            ' Configuration value missing from database. Revert to default value from APP.CONFIG.
            var = ConfigurationManager.AppSettings(configValueKey)

            If var Is Nothing Then
                Dim errorMessage As String = String.Format(
                    "Could not find configuration setting '{0}' in database config table or APP.CONFIG file.",
                    configValueKey)
                Throw New System.Configuration.SettingsPropertyNotFoundException(errorMessage, ex)
            End If

        End Try

    End Sub


End Class
