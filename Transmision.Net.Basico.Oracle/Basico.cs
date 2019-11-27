﻿using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using Transmision.Net.Basico.Oracle.BataTransaction;
using Transmision.Net.Basico.Oracle.CapaDato;
using Transmision.Net.Basico.Oracle.CapaEntidad;

namespace Transmision.Net.Basico.Oracle
{
    public class Basico
    {
        private string _tienda = "";

     
        public  string ejecuta_proceso_oracle()
        {
            string error = "";
            DateTime fecha = DateTime.Today;
            try
            {
                string nom_pc = Environment.MachineName;//"TIENDA-933-1"
                _tienda = nom_pc.Substring(nom_pc.IndexOf('-') + 1, nom_pc.Length - (nom_pc.IndexOf('-') + 1));
                _tienda = _tienda.Substring(0, _tienda.Length - 2);
                if (_tienda.Length == 3) _tienda = "50" + _tienda;

                Dat_Ora_Data data_ora = new Dat_Ora_Data();
                #region<CONEXIONES DE ORACLE>
                Ent_Conexion_Ora_Xstore con_ora = data_ora.ws_conexion_xstore();

                if (con_ora == null) return "";  

                Ent_Acceso_BD.server = con_ora.server;//  ConfigurationManager.AppSettings["server"].ToString();
                Ent_Acceso_BD.user = con_ora.usuario;// ConfigurationManager.AppSettings["usuario"].ToString();
                Ent_Acceso_BD.password = con_ora.password;//  ConfigurationManager.AppSettings["password"].ToString();
                Ent_Acceso_BD.port = con_ora.port;// Convert.ToInt32(ConfigurationManager.AppSettings["port"].ToString());
                Ent_Acceso_BD.sid = con_ora.sid;// ConfigurationManager.AppSettings["sid"].ToString();
                Ent_Acceso_BD.nom_tabla = ConfigurationManager.AppSettings["tempo"].ToString();
                #endregion               
                #region<ORACLE CREACION Y EXISTENCIA>
                Boolean existe = data_ora.existe_tabla();
                if (!existe)
                {
                    data_ora.crear_table();
                }
                #endregion
                #region<REGION DE TRANSACCIONES AL TEMPORAL>
                DataTable dtventa_ora = data_ora.get_documento_TRN_TRANS(fecha);

                if (dtventa_ora != null)
                {
                    if (dtventa_ora.Rows.Count > 0)
                    {
                        foreach (DataRow fila in dtventa_ora.Rows)
                        {
                            Ent_Bat_Tk_Return param = new Ent_Bat_Tk_Return();
                            param.RTL_LOC_ID = Convert.ToDecimal(fila["RTL_LOC_ID"]);
                            param.BUSINESS_DATE = Convert.ToDateTime(fila["BUSINESS_DATE"]);
                            param.WKSTN_ID = Convert.ToDecimal(fila["WKSTN_ID"]);
                            param.TRANS_SEQ = Convert.ToDecimal(fila["TRANS_SEQ"]);
                            param.TOTAL = Convert.ToDecimal(fila["TOTAL"]);
                            param.FISCAL_NUMBER = fila["FISCAL_NUMBER"].ToString();

                            /*VERIFICAR QUE NO EXISTA EL DOCUMENTO*/
                            Boolean existe_tmp = data_ora.existe_tabla_temp(param);
                            if (!existe_tmp)
                            {
                                Boolean insert = data_ora.inserta_tabla_temp(param);
                                /*si el insert es correcto entonces hacemos un update*/
                                if (insert)
                                {
                                    data_ora.update_documento_TRN_TRANS(param);
                                }
                            }
                            else
                            {
                                /*realizar el update en la tabla principal*/
                                data_ora.update_documento_TRN_TRANS(param);
                            }

                        }
                    }
                }
                #endregion
                #region<REGION DE ENVIO DE DATA AL SERVER WEB SERVICE>
                DataTable dt_envio = data_ora.select_tmp_ora();/*seleccionamos datos del oracle*/
                if (dt_envio != null)
                {
                    if (dt_envio.Rows.Count > 0)
                    {
                        foreach (DataRow fila in dt_envio.Rows)
                        {
                            String FC_SUNA = fila["FISCAL_NUMBER"].ToString().Substring(0, 1) == "B" ? "03" : "01";
                            String FC_SFAC = fila["FISCAL_NUMBER"].ToString().Substring(0, 4).ToString();
                            String FC_NFAC = fila["FISCAL_NUMBER"].ToString().Substring(5, fila["FISCAL_NUMBER"].ToString().Length - 5).ToString().PadLeft(8, '0');

                            Ent_Tk_Set_Parametro param = new Ent_Tk_Set_Parametro();
                            param.COD_TDA = fila["RTL_LOC_ID"].ToString();
                            param.FECHA = Convert.ToDateTime(fila["BUSINESS_DATE"]);
                            param.MONTO = Convert.ToDecimal(fila["TOTAL"]);
                            param.FC_SUNA = FC_SUNA;
                            param.SERIE = FC_SFAC;
                            param.NUMERO = FC_NFAC;

                            Ent_Tk_Return env = data_ora.ws_envio_param(param);
                            /*en este caso quiere decir que no hay errores en el envio*/
                            if (env.estado_error.Length == 0)
                            {
                                Int32 RTL_LOC_ID = Convert.ToInt32(fila["RTL_LOC_ID"]);
                                Int32 WKSTN_ID = Convert.ToInt32(fila["WKSTN_ID"]);
                                Int32 TRANS_SEQ = Convert.ToInt32(fila["TRANS_SEQ"]);
                                string FISCAL_NUMBER = fila["FISCAL_NUMBER"].ToString();

                                /*en este caso vemos que se genero el cupon*/
                               
                                data_ora.update_tmp_ora(env.cupon_imprimir, RTL_LOC_ID, WKSTN_ID, TRANS_SEQ, FISCAL_NUMBER);
                                imprimir(env);
                            }

                            // param.
                        }
                    }
                }

                #endregion
                #region<REGION PARA LA REIMPRESION DE TICKETS RETORNO>
                List<Ent_Tk_Return> lista_reimprime = data_ora.ws_get_reimprimir_tk_return(_tienda);

                if (lista_reimprime != null)
                {
                    if (lista_reimprime.Count>0)
                    {
                            foreach(Ent_Tk_Return fila in lista_reimprime)
                            {
                                imprimir(fila);
                                data_ora.ws_update_tk_return_reimprimir(_tienda, fila.cupon_imprimir);

                            }
                    }
                }

                #endregion

            }
            catch (Exception exc)
            {
                error = exc.Message;                
            }
            return error;
        }



        public void imprimir(Ent_Tk_Return env)
        {
            #region Imprimir
            Ticket _tk = new Ticket();
            _tk.leftMargin = 70f;//para el xstore
            Barcode barcode = new Barcode();
            //barcode.IncludeLabel = true;
            Image img = barcode.Encode(TYPE.CODE128A, env.cupon_imprimir.Trim(), Color.Black, Color.White, 250, 80);

            Bitmap bmp = new Bitmap(img);
            _tk.HeaderImage = bmp;
            _tk.AddHeaderLine(env.text1_cup);
            _tk.AddHeaderLine("");
            _tk.AddHeaderLine(env.text2_cup);
            _tk.AddHeaderLine("");
            _tk.AddFooterLine0(env.cupon_imprimir.Trim());
            _tk.AddFooterLine0("");
            _tk.AddFooterLine0(env.text3_cup);
            _tk.AddFooterLine0("");
            _tk.AddFooterLine0("");
            _tk.AddFooterLine0("");
            _tk.AddFooterLine(env.text4_cup);

            string printer = get_printer_disp();
            if (printer != "")_tk.PrintTicket(printer);

            
            #endregion
        }
        public string get_printer_disp()
        {
            string _printer = "";
            try
            {
                var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");
                foreach (var printer in printerQuery.Get())
                {
                    var name = printer.GetPropertyValue("Name");
                    var status = printer.GetPropertyValue("Status");
                    var isDefault = printer.GetPropertyValue("Default");
                    var isNetworkPrinter = printer.GetPropertyValue("Network");

                    if (name.ToString().IndexOf("LaserJet") > 0 && !Convert.ToBoolean(isNetworkPrinter))
                    {
                        _printer = name.ToString();
                        break;
                    }
                }
            }
            catch (Exception)
            {
                _printer = "";
            }
            return _printer;
        }
    }
}
