[String]$dbname = "TietoFeedbackToolDB";
 
# Open ADO.NET Connection with Windows authentification to local SQLSERVER.
$con = New-Object Data.SqlClient.SqlConnection;
$con.ConnectionString = "Data Source=.;Initial Catalog=master;Integrated Security=True;";
$con.Open();
 
# Select-Statement for AD group logins
$sql = "SELECT name
        FROM sys.databases
        WHERE name = '$dbname';";
 
# New command and reader.
$cmd = New-Object Data.SqlClient.SqlCommand $sql, $con;
$rd = $cmd.ExecuteReader();
if ($rd.Read())
{   
    $rd.Close();
    $rd.Dispose();
    $sql = "alter database [$dbname] set single_user with rollback immediate"
    $cmd = New-Object Data.SqlClient.SqlCommand $sql, $con;
    $cmd.ExecuteNonQuery();
    $sql = "DROP DATABASE [$dbname]";
    $cmd = New-Object Data.SqlClient.SqlCommand $sql, $con;
    $cmd.ExecuteNonQuery();
}
$rd.Close();
$rd.Dispose();
 
# Create the database.
$sql = "CREATE DATABASE [$dbname];"
$cmd = New-Object Data.SqlClient.SqlCommand $sql, $con;
$cmd.ExecuteNonQuery()

$scriptName = "\scripts.sql";
$server = "(local)";
$ScriptDir = Split-Path $script:MyInvocation.MyCommand.Path;
$scriptFullPath = $ScriptDir + $scriptName;

Invoke-sqlcmd -ServerInstance $server -Database $dbname -InputFile $scriptFullPath
 
# Close & Clear all objects.
$cmd.Dispose();
$con.Close();
$con.Dispose();