using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace R_Rao_Asp_Proj1
{
    public class clsDatabase
    {
        //*******Procedure: AcquireConnection()*****************//

        private static SqlConnection AcquireConnection()
        {
            SqlConnection cnSQL = null;
            Boolean blnErrorOccurred = false;

            if (ConfigurationManager.ConnectionStrings["ServiceCenter"] != null)
            {
                cnSQL = new SqlConnection();
                cnSQL.ConnectionString = ConfigurationManager.ConnectionStrings["ServiceCenter"].ToString();

                try
                {
                    cnSQL.Open();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    cnSQL.Dispose();
                }

            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return cnSQL;
            }
        }

        //******** Procedure: GetTechnicianList() ***********//
        public static DataSet GetTechnicianList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetTechnicianList";
                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        //************* Procedure: GetTechnicianByID() *********//
        public static DataSet GetTechnicianByID(String strTechID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            if (strTechID.Trim().Length > 0)
            {
                cnSQL = AcquireConnection();
                if (cnSQL == null)
                {
                    return null;
                }
                else
                {
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "uspGetTechnicianByID";

                    cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.Int));
                    cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@TechnicianID"].Value = strTechID;

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    dsSQL = new DataSet();
                    try
                    {
                        daSQL = new SqlDataAdapter(cmdSQL);
                        intRetCode = daSQL.Fill(dsSQL);
                        daSQL.Dispose();
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                        dsSQL.Dispose();
                    }
                    finally
                    {
                        cmdSQL.Parameters.Clear();
                        cmdSQL.Dispose();
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }
                }
            }
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        //*************** Procedure: InsertTechnician() *************//

        public static Int32 InsertTechnician(string strLName, string strFName, string strMInit,
            string strEMail, string strDept, string strPhone, string strHRate)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;
            Int32 intNewTechID = 0;


            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar, 30));
                cmdSQL.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@LName"].Value = strLName;

                cmdSQL.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar, 30));
                cmdSQL.Parameters["@FName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@FName"].Value = strFName;

                cmdSQL.Parameters.Add(new SqlParameter("@MInit", SqlDbType.NVarChar, 1));
                cmdSQL.Parameters["@MInit"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strMInit))
                {
                    cmdSQL.Parameters["@MInit"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@MInit"].Value = strMInit;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar, 50));
                cmdSQL.Parameters["@EMail"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strEMail))
                {
                    cmdSQL.Parameters["@EMail"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@EMail"].Value = strEMail;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar, 25));
                cmdSQL.Parameters["@Dept"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strDept))
                {
                    cmdSQL.Parameters["@Dept"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Dept"].Value = strDept;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strPhone;

                cmdSQL.Parameters.Add(new SqlParameter("@HRate", SqlDbType.Money));
                cmdSQL.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@HRate"].Value = strHRate;

                cmdSQL.Parameters.Add(new SqlParameter("@NewTechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@NewTechnicianID"].Direction = ParameterDirection.Output;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {

                    cnSQL.Close();
                    cnSQL.Dispose();
                }
                if (!blnErrorOccurred)
                {
                    try
                    {
                        intNewTechID = Convert.ToInt32(cmdSQL.Parameters["@NewTechnicianID"].Value);
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                    }
                }
                cmdSQL.Parameters.Clear();
                cmdSQL.Dispose();
            }

            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return intNewTechID;
            }
        }

        //********** Procedure: Delete Technician ********************//
        public static Int32 DeleteTechnician(String strTechID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();

            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }

            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspDeleteTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechnicianID"].Value = strTechID;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;



                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }

                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return -1;
            }

            else
            {
                return 0;
            }
        }

        //*********************** Procedure: UpdateTechnician() ****************//
        public static Int32 UpdateTechnician(string strTechID, string strLName, string strFName, string strMInit,
            string strEMail, string strDept, string strPhone, string strHRate)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspUpdateTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechnicianID"].Value = strTechID;

                cmdSQL.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar, 30));
                cmdSQL.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@LName"].Value = strLName;

                cmdSQL.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar, 30));
                cmdSQL.Parameters["@FName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@FName"].Value = strFName;

                cmdSQL.Parameters.Add(new SqlParameter("@MInit", SqlDbType.NVarChar, 1));
                cmdSQL.Parameters["@MInit"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strMInit))
                {
                    cmdSQL.Parameters["@MInit"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@MInit"].Value = strMInit;
                }
                cmdSQL.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar, 50));
                cmdSQL.Parameters["@EMail"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strEMail))
                {
                    cmdSQL.Parameters["@EMail"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@EMail"].Value = strEMail;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar, 25));
                cmdSQL.Parameters["@Dept"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strDept))
                {
                    cmdSQL.Parameters["@Dept"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Dept"].Value = strDept;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strPhone;

                cmdSQL.Parameters.Add(new SqlParameter("@HRate", SqlDbType.Money));
                cmdSQL.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@HRate"].Value = strHRate;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /*********************************************************************/
        /***************Procedure:GetClientList*******************************/
        /*********************************************************************/
        public static DataSet GetClientList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetClientList";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        /*********************************************************************/
        /***************Procedure:GetProductList*******************************/
        /*********************************************************************/
        public static DataSet GetProductList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetProductList";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }

        //*******************************************************************//
        //***** InsertServiceEvent()*****************************************//
        //*******************************************************************//
        public static Int32 InsertServiceEvent(Int32 intClientID, DateTime dtEventDate, String strPhone, String strContact)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;
            Int32 intNewTicket = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertServiceEvent";

                cmdSQL.Parameters.Add(new SqlParameter("@ClientID", SqlDbType.Int));
                cmdSQL.Parameters["@ClientID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ClientID"].Value = intClientID;

                cmdSQL.Parameters.Add(new SqlParameter("@EventDate", SqlDbType.DateTime));
                cmdSQL.Parameters["@EventDate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@EventDate"].Value = dtEventDate;

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NChar, 10));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strPhone;

                cmdSQL.Parameters.Add(new SqlParameter("@Contact", SqlDbType.NVarChar, 30));
                cmdSQL.Parameters["@Contact"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Contact"].Value = strContact;

                cmdSQL.Parameters.Add(new SqlParameter("@NewTicketID", SqlDbType.Int));
                cmdSQL.Parameters["@NewTicketID"].Direction = ParameterDirection.Output;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cnSQL.Close();
                    cnSQL.Dispose();
                }

                if (!blnErrorOccurred)
                {
                    try
                    {
                        intNewTicket = Convert.ToInt32(cmdSQL.Parameters["@NewTicketID"].Value);
                    }
                    catch (Exception ex)
                    {
                        blnErrorOccurred = true;
                    }
                }
                //** Cleanup
                cmdSQL.Parameters.Clear();
                cmdSQL.Dispose();
            }

            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return intNewTicket;
            }
        }

        //*******************************************************************//
        //***** InsertProblem()*****************************************//
        //*******************************************************************//
        public static Int32 InsertProblem(Int32 intTicketID, Int32 intIncidentNo, String strProblemDesc, Int32 intTechID, String strProductID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertProblem";

                cmdSQL.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int));
                cmdSQL.Parameters["@TicketID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TicketID"].Value = intTicketID;

                cmdSQL.Parameters.Add(new SqlParameter("@IncidentNo", SqlDbType.Int));
                cmdSQL.Parameters["@IncidentNo"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@IncidentNo"].Value = intIncidentNo;

                cmdSQL.Parameters.Add(new SqlParameter("@ProbDesc", SqlDbType.NVarChar, 500));
                cmdSQL.Parameters["@ProbDesc"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ProbDesc"].Value = strProblemDesc;

                cmdSQL.Parameters.Add(new SqlParameter("@TechID", SqlDbType.Int));
                cmdSQL.Parameters["@TechID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechID"].Value = intTechID;

                cmdSQL.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@ProductID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ProductID"].Value = strProductID;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        //*******************************************************************//
        //***** GetOpenProblems()*****************************************//
        //*******************************************************************//
        public static DataSet GetOpenProblems()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetOpenProblems";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }


        //*******************************************************************//
        //***** InsertResolution()*****************************************//
        //*******************************************************************//
        public static Int32 InsertResolution(Int32 intTicketID, Int32 intIncidentNo, Int32 intResolNo, String strResDesc,
            String strDateFix, String strDateOnsite, Int32 intTechID, String strHours,
            String strMileage, String strCostMiles, String strSupplies, String strMisc, Int32 intNoCharge)
        {
            {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertResolution";

                cmdSQL.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int));
                cmdSQL.Parameters["@TicketID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TicketID"].Value = intTicketID;

                cmdSQL.Parameters.Add(new SqlParameter("@IncidentNo", SqlDbType.Int));
                cmdSQL.Parameters["@IncidentNo"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@IncidentNo"].Value = intIncidentNo;

                cmdSQL.Parameters.Add(new SqlParameter("@ResNo", SqlDbType.Int));
                cmdSQL.Parameters["@ResNo"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ResNo"].Value = intResolNo;

                cmdSQL.Parameters.Add(new SqlParameter("@ResDesc", SqlDbType.NVarChar,500));
                cmdSQL.Parameters["@ResDesc"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ResDesc"].Value = strResDesc;

                cmdSQL.Parameters.Add(new SqlParameter("@DateFix", SqlDbType.DateTime));
                cmdSQL.Parameters["@DateFix"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strDateFix))
                {
                    cmdSQL.Parameters["@DateFix"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@DateFix"].Value = Convert.ToDateTime(strDateFix);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@DateOnsite", SqlDbType.DateTime));
                cmdSQL.Parameters["@DateOnsite"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strDateOnsite))
                {
                    cmdSQL.Parameters["@DateOnsite"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@DateOnsite"].Value = Convert.ToDateTime(strDateOnsite);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@TechID", SqlDbType.Int));
                cmdSQL.Parameters["@TechID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechID"].Value = intTechID;

                cmdSQL.Parameters.Add(new SqlParameter("@Hours", SqlDbType.Decimal));
                cmdSQL.Parameters["@Hours"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strHours))
                {
                    cmdSQL.Parameters["@Hours"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Hours"].Value = Convert.ToDecimal(strHours);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Mileage", SqlDbType.Decimal));
                cmdSQL.Parameters["@Mileage"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strMileage))
                {
                    cmdSQL.Parameters["@Mileage"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Mileage"].Value = Convert.ToDecimal(strMileage);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@CostMiles", SqlDbType.Decimal));
                cmdSQL.Parameters["@CostMiles"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strCostMiles))
                {
                    cmdSQL.Parameters["@CostMiles"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@CostMiles"].Value = Convert.ToDecimal(strCostMiles);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Supplies", SqlDbType.Decimal));
                cmdSQL.Parameters["@Supplies"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strSupplies))
                {
                    cmdSQL.Parameters["@Supplies"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Supplies"].Value = Convert.ToDecimal(strSupplies);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Misc", SqlDbType.Decimal));
                cmdSQL.Parameters["@Misc"].Direction = ParameterDirection.Input;
                if (String.IsNullOrEmpty(strMisc))
                {
                    cmdSQL.Parameters["@Misc"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Misc"].Value = Convert.ToDecimal(strMisc);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@NoCharge", SqlDbType.Int));
                cmdSQL.Parameters["@NoCharge"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@NoCharge"].Value = intNoCharge;

                
                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        }



        //*******************************************************************//
        //***** GetReport()*****************************************//
        //*******************************************************************//
        public static DataSet GetReport(String strReportSP)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = strReportSP;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }
    }
}