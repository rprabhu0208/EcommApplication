using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Reflection;

namespace ECommApplication.DataLayer.Common
{
    public static class SqlHelper
    {
        #region"Declare Variables"

        private static SqlConnection m_conn = null;
        public static SqlTransaction m_transaction;

        #endregion

        #region "Attach Parameters"

        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            command.Parameters.Clear();
            foreach (SqlParameter param in commandParameters)
            {
                if (param == null)
                {
                    param.Value = DBNull.Value;
                }
                else if (Convert.ToString(param.Value) == "1/1/1999 12:00:00 AM" || Convert.ToString(param.Value) == "01/01/1900 00:00:00" || Convert.ToString(param.Value) == "01/01/0001 00:00:00")
                {
                    param.Value = DBNull.Value;
                }
                command.Parameters.Add(param);
            }
        }
        private static void AssignParameterValues(SqlParameter[] commandParameters, object[] parameterValues)
        {
            try
            {
                if ((commandParameters == null) || (parameterValues == null))
                {
                    return;
                }
                for (int i = 0, j = commandParameters.Length; i < j; i++)
                {
                    try
                    {
                        if (parameterValues[i] == null)
                            commandParameters[i].Value = DBNull.Value;
                        else
                            commandParameters[i].Value = parameterValues[i];
                    }
                    catch { }

                }
            }
            catch
            {
            }
        }

        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            command.Connection = connection;
            command.CommandText = commandText;
            command.Transaction = transaction;
            command.CommandType = commandType;
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }
        #endregion

        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            Type elementType = typeof(T);
            using (DataTable t = new DataTable())
            {
                PropertyInfo[] _props = elementType.GetProperties();
                foreach (PropertyInfo propInfo in _props)
                {
                    Type _pi = propInfo.PropertyType;
                    Type ColType = Nullable.GetUnderlyingType(_pi) ?? _pi;
                    t.Columns.Add(propInfo.Name, ColType);
                }
                foreach (T item in list)
                {
                    DataRow row = t.NewRow();
                    foreach (PropertyInfo propInfo in _props)
                    {
                        row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                    }
                    t.Rows.Add(row);
                }
                return t;
            }
        }

        public static void writeLog(object objClass, Exception ex)
        {
            if ((ex is System.Threading.ThreadAbortException) == true)
                return;
            try
            {
                // Create a writer and open the file:
                string strLogText = "";
                strLogText += Environment.NewLine + "\nMessage ---\n{0}" + ex.Message;
                strLogText += Environment.NewLine + "\nSource ---\n{0}" + ex.Source;
                strLogText += Environment.NewLine + "\nStackTrace ---\n{0}" + ex.StackTrace;
                strLogText += Environment.NewLine + "\nTargetSite ---\n{0}" + ex.TargetSite;
                if (ex.InnerException != null)
                {
                    strLogText += Environment.NewLine + "Inner Exception is {0}" + ex.InnerException;//error prone
                }
                if (ex.HelpLink != null)
                {
                    strLogText += Environment.NewLine + "\nHelpLink ---\n{0}" + ex.HelpLink;//error prone
                }

                StreamWriter log;
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy");
                string error_folder = HttpContext.Current.Server.MapPath("../ErrorLog");

                if (!System.IO.Directory.Exists(error_folder))
                {
                    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("../ErrorLog"));
                }


                if (!File.Exists(String.Format(@"{0}\{1}.txt", error_folder, timestamp)))
                {
                    log = new StreamWriter(String.Format(@"{0}\{1}.txt", error_folder, timestamp));
                }
                else
                {
                    log = File.AppendText(String.Format(@"{0}\{1}.txt", error_folder, timestamp));
                }

                // Write to the file:
                log.WriteLine(DateTime.Now);
                log.WriteLine("IP:" + HttpContext.Current.Request.UserHostAddress);
                log.WriteLine(objClass);
                log.WriteLine(strLogText);
                log.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
                log.WriteLine();

                // Close the stream:
                log.Close();

                string errtext = System.IO.File.ReadAllText(String.Format(@"{0}\{1}.txt", error_folder, timestamp));
                string[] lines = System.IO.File.ReadAllLines(String.Format(@"{0}\{1}.txt", error_folder, timestamp));

                errtext = "";
                foreach (string line in lines)
                {
                    errtext += Environment.NewLine + line;
                }
                //    Utilities.SendEmailWithAttachment("\"PAP Live Error \" <support@mahaonline.gov.in>", "jaydeep.chavan@mahaonline.gov.in", "PAP Live Application Notification", errtext, String.Format(@"{0}\Log-{1}.txt", error_folder, timestamp));
                //    Utilities.SendEmail("jaydeep.chavan@mahaonline.gov.in", "PAP Live Application Error Notification", "Error Occured @:" + errtext);
                //    Utilities.SendEmail("amarnath.mishra@mahaonline.gov.in", "PAP Live Application Error Notification", "Error Occured @:" + errtext);
                //    Utilities.SendEmail("rahul.rokade@mahaonline.gov.in", "PAP Live Application Error Notification", "Error Occured @:" + errtext);

                #region open this comment when uploading on Live
                //Utilities.SendEmailWithAttachment("\"PAP Live Error \" <support@mahaonline.gov.in>", "venkiteswaran.puthucode@mahaonline.gov.in,sayli.shinde@mahaonline.gov.in,jaydeep.chavan@mahaonline.gov.in,amarnath.mishra@mahaonline.gov.in,rahul.rokade@mahaonline.gov.in", "PAP Live Application Notification", strLogText, String.Format(@"{0}\Log-{1}.txt", error_folder, timestamp));
                //Utilities.SendEmail("venkiteswaran.puthucode@mahaonline.gov.in,sayli.shinde@mahaonline.gov.in,jaydeep.chavan@mahaonline.gov.in,amarnath.mishra@mahaonline.gov.in,rahul.rokade@mahaonline.gov.in", "PAP Live Application Error Notification", "Error Occured @:" + strLogText);

                #endregion

            }
            catch (Exception e)
            { }
            finally
            { }
        }

        #region "Execute Non Query"
        public static int ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, string spName, params object[] parameterValues)
        {

            if ((parameterValues != null) && (parameterValues.Length > 0))
            {

                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, transaction, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteNonQuery(connection, transaction, CommandType.StoredProcedure, spName, commandParameters);
            }

            else
            {
                return ExecuteNonQuery(connection, transaction, CommandType.StoredProcedure, spName);
            }
        }

        public static int ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmdExecute = new SqlCommand();
            PrepareCommand(cmdExecute, connection, transaction, commandType, commandText, commandParameters);
            int returnVal = cmdExecute.ExecuteNonQuery();
            return returnVal;
        }

        #endregion

        #region "Connection String"

        public static SqlConnection OpenConnection(string DBName)
        {
            string connstr = ConfigurationManager.ConnectionStrings["SGNPEcommerce"].ToString();
            //string connstr =   ConfigurationSettings.AppSettings["Local"].ToString();
            m_conn = new SqlConnection(connstr);

            if ((m_conn.State == ConnectionState.Broken) || (m_conn.State == ConnectionState.Closed))
            {
                m_conn.Open();
            }
            return m_conn;
        }

        public static SqlConnection OpenConnection()
        {
            //string connstr = ConfigurationSettings.AppSettings["connString"].ToString();
            //string connstr = ConfigurationSettings.AppSettings["Local"].ToString();
            string connstr = ConfigurationManager.ConnectionStrings["SGNPEcommerce"].ToString();
            m_conn = new SqlConnection(connstr);

            if ((m_conn.State == ConnectionState.Broken) || (m_conn.State == ConnectionState.Closed))
            {
                m_conn.Open();
            }


            return m_conn;

        }

        public static void CloseConnection(Object obj)
        {
            m_conn = (SqlConnection)obj;
            if (m_conn.State == ConnectionState.Open)
            {
                m_conn.Close();
                m_conn.Dispose();
            }
        }
        #endregion

        #region "Transaction"
        public static void StartTransaction()
        {
            m_transaction = m_conn.BeginTransaction();

        }

        public static void CommitTransaction()
        {
            m_transaction.Commit();

        }

        public static void RollBackTransaction()
        {
            m_transaction.Rollback();
        }
        #endregion

        #region "Execute Dataset"
        public static DataSet ExecuteDataset(SqlConnection cn, SqlTransaction t, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(cn, t, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteDataset(cn, t, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return ExecuteDataset(cn, t, CommandType.StoredProcedure, spName);
            }
        }
        public static DataSet ExecuteDataset(SqlConnection connection, SqlTransaction t, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmdExecute = new SqlCommand();
            cmdExecute.CommandTimeout = 360;
            PrepareCommand(cmdExecute, connection, t, commandType, commandText, commandParameters);
            SqlDataAdapter daExecute = new SqlDataAdapter(cmdExecute);
            DataSet dstExecute = new DataSet();
            daExecute.Fill(dstExecute);
            cmdExecute.Parameters.Clear();
            return dstExecute;
        }
        #endregion

        #region "Execute Scalar"
        public static object ExecuteScalar(SqlConnection connection, SqlTransaction transaction, string spName, params object[] parameterValues)
        {
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, transaction, spName);
                AssignParameterValues(commandParameters, parameterValues);
                return ExecuteScalar(connection, transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                return ExecuteScalar(connection, transaction, CommandType.StoredProcedure, spName);
            }
        }
        public static object ExecuteScalar(SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmdExecute = new SqlCommand();
            cmdExecute.CommandTimeout = 360;
            PrepareCommand(cmdExecute, connection, transaction, commandType, commandText, commandParameters);
            object returnVal = cmdExecute.ExecuteScalar();
            cmdExecute.Parameters.Clear();
            return returnVal;

        }
        #endregion

        #region "Class SqlHelper"
        public sealed class SqlHelperParameterCache
        {
            private SqlHelperParameterCache() { }
            private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

            private static SqlParameter[] DiscoverSpParameterSet(SqlConnection connection, SqlTransaction transaction, string spName, bool includeReturnValueParameter)
            {
                try
                {
                    SqlCommand cmdExecute = new SqlCommand();
                    cmdExecute.CommandType = CommandType.StoredProcedure;
                    cmdExecute.CommandText = spName;
                    cmdExecute.Connection = connection;
                    // AlternativeDeriveParameters adParams = new AlternativeDeriveParameters();
                    cmdExecute.Transaction = transaction;
                    SqlCommandBuilder.DeriveParameters(cmdExecute);

                    if (!includeReturnValueParameter)
                    {
                        cmdExecute.Parameters.RemoveAt(0);
                    }
                    SqlParameter[] discoveredParameters = new SqlParameter[cmdExecute.Parameters.Count];
                    cmdExecute.Parameters.CopyTo(discoveredParameters, 0);
                    cmdExecute.Parameters.Clear();
                    return discoveredParameters;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
            {

                SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];
                for (int i = 0, j = originalParameters.Length; i < j; i++)
                {
                    clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
                }

                return clonedParameters;
            }

            public static void CacheParameterSet(string connectionString, string commandText, params SqlParameter[] commandParameters)
            {
                string hashKey = ConfigurationSettings.AppSettings["ConnString"].ToString() + ":" + commandText;
                paramCache[hashKey] = commandParameters;
            }

            public static SqlParameter[] GetCachedParameterSet(SqlConnection connection, string commandText)
            {
                string hashKey = ConfigurationSettings.AppSettings["ConnString"].ToString() + ":" + commandText;
                SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];
                if (cachedParameters == null)
                {
                    return null;
                }
                else
                {
                    return CloneParameters(cachedParameters);
                }
            }
            public static SqlParameter[] GetSpParameterSet(SqlConnection connection, SqlTransaction transaction, string spName)
            {
                return GetSpParameterSet(connection, transaction, spName, false);
            }
            public static SqlParameter[] GetSpParameterSet(SqlConnection connection, SqlTransaction transaction, string spName, bool includeReturnValueParameter)
            {
                //string connectionString = "";
                string hashKey = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
                SqlParameter[] cachedParameters;
                cachedParameters = (SqlParameter[])paramCache[hashKey];
                if (cachedParameters == null)
                {
                    cachedParameters = (SqlParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(connection, transaction, spName, includeReturnValueParameter));
                }
                return CloneParameters(cachedParameters);
            }
            public static void ClearCache()
            {
                paramCache = Hashtable.Synchronized(new Hashtable());
            }
        }
        #endregion


        public sealed class DateStartAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {

                DateTime dateStart = (DateTime)value;
                // Meeting must start in the future time.
                //return (dateStart.Date > DateTime.Now.Date);


                //DateTime dateStart = (DateTime)value;
                //Meeting must start in the future time.
                int i = (dateStart.CompareTo(DateTime.Now));
                if (i <= 0)
                {
                    return false;
                }

                else
                {
                    return true;
                }

            }
        }

        public sealed class DateEndAttribute : ValidationAttribute
        {
            public string DateStartProperty { get; set; }
            public override bool IsValid(object value)
            {
                // Get Value of the DateStart property
                string dateStartString = HttpContext.Current.Request[DateStartProperty];
                if (string.IsNullOrWhiteSpace(dateStartString) && string.IsNullOrEmpty(dateStartString))
                {
                    dateStartString = "01/01/1900";

                }
                DateTime dateEnd = (DateTime)value;
                DateTime dateStart = Convert.ToDateTime(dateStartString); //DateTime.ParseExact(dateStartString, "dd-MM-yyyy", null).Date;

                // Meeting start time must be before the end time
                return dateStart < dateEnd;
            }
        }

        public sealed class NumberAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                    return true;
                }
                int getal;
                if (int.TryParse(value.ToString(), out getal))
                {

                    if (getal >= 0)
                        return true;
                }
                return false;
            }
        }
        public static string iSendMail(string FromEmail, string ToEmail, string EmailSubject, string EmailBody,List<string> AttachFile, string FromName = "", string ToName = "", string ReplyEmail = "", string ReplyName = "")
        {
            try
            {
                MailMessage NewsMessage = new MailMessage();
                SmtpClient mailclient = new SmtpClient();
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential();
                basicAuthenticationInfo.UserName = "dmcland@mmrda.maharashtra.gov.in";
                basicAuthenticationInfo.Password = "p@ssw0rd";
                //If AttachFile <> Nothing Then
                //    NewsMessage.Attachments.Add(New Attachment(AttachFile))
                //End If
                //-------------------------------------------------------
                int i = 0;
                System.Net.Mail.Attachment Attachment = null;

                if (AttachFile != null)
                {
                    for (i = 0; i <= AttachFile.Count - 1; i++)
                    {
                        Attachment = new System.Net.Mail.Attachment(AttachFile[i].ToString());
                        NewsMessage.Attachments.Add(Attachment);

                    }
                }
                //---------------------------------------------------
                if (string.IsNullOrEmpty(ReplyEmail))
                    ReplyEmail = FromEmail;
                if (string.IsNullOrEmpty(ReplyName))
                    ReplyName = FromName;

                NewsMessage.From = new MailAddress(FromEmail, FromName);

                NewsMessage.Subject = EmailSubject;
                NewsMessage.Priority = MailPriority.Normal;
                NewsMessage.IsBodyHtml = true;

                NewsMessage.ReplyTo = new MailAddress(ReplyEmail, ReplyName);

                NewsMessage.Body = EmailBody;
                NewsMessage.To.Add(new MailAddress(ToEmail, ToName));


                mailclient.Host = "mail.mahaonline.gov.in";

                mailclient.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                
                mailclient.UseDefaultCredentials = true;
                mailclient.Credentials = basicAuthenticationInfo;
                mailclient.Timeout = 520000;
                mailclient.Send(NewsMessage);
                return "Success";
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }


        public static string iSendMailNew(string FromEmail, string ToEmail, string EmailSubject, string EmailBody, List<string> AttachFile, string FromName = "", string ToName = "", string ReplyEmail = "", string ReplyName = "")
        {
            try
            {
                MailMessage NewsMessage = new MailMessage();
                SmtpClient mailclient = new SmtpClient();
                System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential();
                basicAuthenticationInfo.UserName = "dmcland@mmrda.maharashtra.gov.in";
                basicAuthenticationInfo.Password = "p@ssw0rd";
                //If AttachFile <> Nothing Then
                //    NewsMessage.Attachments.Add(New Attachment(AttachFile))
                //End If
                //-------------------------------------------------------
                int i = 0;
                System.Net.Mail.Attachment Attachment = null;

                if (AttachFile != null)
                {
                    for (i = 0; i <= AttachFile.Count - 1; i++)
                    {
                        Attachment = new System.Net.Mail.Attachment(AttachFile[i].ToString());
                        NewsMessage.Attachments.Add(Attachment);

                    }
                }
                //---------------------------------------------------
                if (string.IsNullOrEmpty(ReplyEmail))
                    ReplyEmail = FromEmail;
                if (string.IsNullOrEmpty(ReplyName))
                    ReplyName = FromName;

                NewsMessage.From = new MailAddress(FromEmail, FromName);
                NewsMessage.Subject = EmailSubject;
                NewsMessage.Priority = MailPriority.Normal;
                NewsMessage.IsBodyHtml = true;

                NewsMessage.ReplyTo = new MailAddress(ReplyEmail, ReplyName);
              
                NewsMessage.Body =   EmailBody;
                NewsMessage.To.Add(new MailAddress(ToEmail, ToName));

                mailclient.Host = "mail.mahaonline.gov.in";
                mailclient.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                mailclient.UseDefaultCredentials = true;
                mailclient.Credentials = basicAuthenticationInfo;
                mailclient.Timeout = 520000;
                mailclient.Send(NewsMessage);
                return "Success";
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        internal static DataTable ToDataTable()
        {
            throw new NotImplementedException();
        }
    }
}