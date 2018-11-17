using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using BusinessEntities;

namespace ConsoleApp1
{
   public class Nota_Debito
    {
        //_________________________________datos de funciones_____________________________
        public string rutaRAIZ = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "");
        public string TOKEN;
        public string TIKET;
        public string HASH;
        public string XML;
        public string RUC_EMISOR;
        public string SERIE;
        //________________________________URL___________________________________
        public string Documento_URL = "https://ose.efact.pe/api-efact-ose/v1/document";
        public string Token_URL = "https://ose.efact.pe/api-efact-ose/oauth/token";
        public string Cdr_URL = "https://ose.efact.pe/api-efact-ose/v1/cdr/";
        public string xml_URL = "https://ose.efact.pe/api-efact-ose/v1/xml/";
        //_________________________________datos de usuario____________________________
        const string userName = "20505161051";
        const string password = "c4792ca2681ca4bb762400ff12892f78199a382c10b7249e2af6936aa6c234dd";
        const string authorization = "Y2xpZW50OnNlY3JldA==";
        XmlDocument xml = new XmlDocument();

        public Dictionary<string, string> NOTA_DEBITO(CPE da, string RUTA, string NOMBRE)
        {
            var diccionario = new Dictionary<string, string>();
            string json = @"{
        '_D' : 'urn:oasis:names:specification:ubl:schema:xsd:DebitNote-2',
        '_S' : 'urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2',
        '_B' : 'urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2',
        '_E' : 'urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2',
        'DebitNote' : [ 
            {
                'UBLVersionID' : [ 
                    {
                        'IdentifierContent' : '2.1'
                    }
                ],
                'CustomizationID' : [ 
                    {
                        'IdentifierContent' : '2.0'
                    }
                ],
                'ID' : [ 
                    {
                        'IdentifierContent' : 'FF01-00000015'
                    }
                ],
                'IssueDate' : [ 
                    {
                        'DateContent' : '2018-06-25'
                    }
                ],
                'IssueTime' : [ 
                    {
                        'DateTimeContent' : '14:46:42'
                    }
                ],
                'Note' : [ 
                    {
                        'TextContent' : 'VEINTE Y TRES Y 60/100 SOLES',
                        'LanguageLocaleIdentifier' : '1000'
                    }
                ],
                'DocumentCurrencyCode' : [ 
                    {
                        'CodeContent' : 'PEN'
                    }
                ],
                'DiscrepancyResponse' : [ 
                    {
                        'ReferenceID' : [ 
                            {
                                'IdentifierContent' : 'FF01-00012'
                            }
                        ],
                        'ResponseCode' : [ 
                            {
                                'CodeContent' : '02'
                            }
                        ],
                        'Description' : [ 
                            {
                                'TextContent' : 'Aumento en el valor'
                            }
                        ]
                    }
                ],
                'BillingReference' : [ 
                    {
                        'InvoiceDocumentReference' : [ 
                            {
                                'ID' : [ 
                                    {
                                        'IdentifierContent' : 'FF01-00012'
                                    }
                                ],
                                'DocumentTypeCode' : [ 
                                    {
                                        'CodeContent' : '01'
                                    }
                                ]
                            }
                        ]
                    }
                ],
                'Signature' : [ 
                    {
                        'ID' : [ 
                            {
                                'IdentifierContent' : 'IDSignatureContratistas'
                            }
                        ],
                        'SignatoryParty' : [ 
                            {
                                'PartyIdentification' : [ 
                                    {
                                        'ID' : [ 
                                            {
                                                'IdentifierContent' : '20101049711'
                                            }
                                        ]
                                    }
                                ],
                                'PartyName' : [ 
                                    {
                                        'Name' : [ 
                                            {
                                                'TextContent' : 'CONTRATISTAS S.A.C.'
                                            }
                                        ]
                                    }
                                ]
                            }
                        ],
                        'DigitalSignatureAttachment' : [ 
                            {
                                'ExternalReference' : [ 
                                    {
                                        'URI' : [ 
                                            {
                                                'TextContent' : 'IDSignatureContratistas'
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    }
                ],
                'AccountingSupplierParty' : [ 
                    {
                        'Party' : [ 
                            {
                                'PartyName' : [ 
                                    {
                                        'Name' : [ 
                                            {
                                                'TextContent' : 'CONTRATISTAS S.A.C.'
                                            }
                                        ]
                                    }
                                ],
                                'PostalAddress' : [ 
                                    {
                                        'ID' : [ 
                                            {
                                                'IdentifierContent' : '150122'
                                            }
                                        ],
                                        'StreetName' : [ 
                                            {
                                                'TextContent' : 'Av. Los Dominicos 155'
                                            }
                                        ],
                                        'CityName' : [ 
                                            {
                                                'TextContent' : 'LIMA'
                                            }
                                        ],
                                        'CountrySubentity' : [ 
                                            {
                                                'TextContent' : 'LIMA'
                                            }
                                        ],
                                        'District' : [ 
                                            {
                                                'TextContent' : 'MIRAFLORES'
                                            }
                                        ],
                                        'Country' : [ 
                                            {
                                                'IdentificationCode' : [ 
                                                    {
                                                        'IdentifierContent' : 'PE'
                                                    }
                                                ]
                                            }
                                        ]
                                    }
                                ],
                                'PartyTaxScheme' : [ 
                                    {
                                        'RegistrationName' : [ 
                                            {
                                                'TextContent' : 'CONTRATISTAS S.A.C.'
                                            }
                                        ],
                                        'CompanyID' : [ 
                                            {
                                                'IdentifierContent' : '20101049711',
                                                'IdentificationSchemeIdentifier' : '6',
                                                'IdentificationSchemeNameText' : 'SUNAT:Identificador de Documento de Identidad',
                                                'IdentificationSchemeAgencyNameText' : 'PE:SUNAT',
                                                'IdentificationSchemeUniformResourceIdentifier' : 'urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06'
                                            }
                                        ],
                                        'RegistrationAddress' : [ 
                                            {
                                                'AddressTypeCode' : [ 
                                                    {
                                                        'CodeContent' : '0001'
                                                    }
                                                ]
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    }
                ],
                'AccountingCustomerParty' : [ 
                    {
                        'Party' : [ 
                            {
                                'PostalAddress' : [ 
                                    {
                                        'ID' : [ 
                                            {
                                                'IdentifierContent' : '150122'
                                            }
                                        ],
                                        'StreetName' : [ 
                                            {
                                                'TextContent' : 'AV. LARCO 1301 1602 '
                                            }
                                        ],
                                        'CityName' : [ 
                                            {
                                                'TextContent' : 'LIMA'
                                            }
                                        ],
                                        'CountrySubentity' : [ 
                                            {
                                                'TextContent' : 'LIMA'
                                            }
                                        ],
                                        'District' : [ 
                                            {
                                                'TextContent' : 'MIRAFLORES'
                                            }
                                        ],
                                        'Country' : [ 
                                            {
                                                'IdentificationCode' : [ 
                                                    {
                                                        'IdentifierContent' : 'PE'
                                                    }
                                                ]
                                            }
                                        ]
                                    }
                                ],
                                'PartyTaxScheme' : [ 
                                    {
                                        'RegistrationName' : [ 
                                            {
                                                'TextContent' : 'EFACT S.A.C.'
                                            }
                                        ],
                                        'CompanyID' : [ 
                                            {
                                                'IdentifierContent' : '20551093035',
                                                'IdentificationSchemeIdentifier' : '6',
                                                'IdentificationSchemeNameText' : 'SUNAT:Identificador de Documento de Identidad',
                                                'IdentificationSchemeAgencyNameText' : 'PE:SUNAT',
                                                'IdentificationSchemeUniformResourceIdentifier' : 'urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo06'
                                            }
                                        ],
                                        'RegistrationAddress' : [ 
                                            {
                                                'AddressTypeCode' : [ 
                                                    {
                                                        'CodeContent' : '0001'
                                                    }
                                                ]
                                            }
                                        ]
                                    }
                                ],
                                'Contact' : [ 
                                    {
                                        'ElectronicMail' : [ 
                                            {
                                                'TextContent' : 'fmontes@efact.pe'
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    }
                ],
                'TaxTotal' : [ 
                    {
                        'TaxAmount' : [ 
                            {
                                'AmountContent' : '3.60',
                                'AmountCurrencyIdentifier' : 'PEN'
                            }
                        ],
                        'TaxSubtotal' : [ 
                            {
                                'TaxableAmount' : [ 
                                    {
                                        'AmountContent' : '20.00',
                                        'AmountCurrencyIdentifier' : 'PEN'
                                    }
                                ],
                                'TaxAmount' : [ 
                                    {
                                        'AmountContent' : '3.60',
                                        'AmountCurrencyIdentifier' : 'PEN'
                                    }
                                ],
                                'TaxCategory' : [ 
                                    {
                                        'ID' : [ 
                                            {
                                                'IdentifierContent' : 'S',
                                                'IdentificationSchemeIdentifier' : 'UN/ECE 5305',
                                                'IdentificationSchemeNameText' : 'Tax Category Identifier',
                                                'IdentificationSchemeAgencyNameText' : 'United Nations Economic Commission for Europe'
                                            }
                                        ],
                                        'Percent' : [ 
                                            {
                                                'NumericContent' : 18.00
                                            }
                                        ],
                                        'TaxScheme' : [ 
                                            {
                                                'ID' : [ 
                                                    {
                                                        'IdentifierContent' : '1000',
                                                        'IdentificationSchemeIdentifier' : 'UN/ECE 5153',
                                                        'IdentificationSchemeAgencyIdentifier' : '6'
                                                    }
                                                ],
                                                'Name' : [ 
                                                    {
                                                        'TextContent' : 'IGV'
                                                    }
                                                ],
                                                'TaxTypeCode' : [ 
                                                    {
                                                        'CodeContent' : 'VAT'
                                                    }
                                                ]
                                            }
                                        ]
                                    }
                                ]
                            }
                        ]
                    }
                ],
                'RequestedMonetaryTotal' : [ 
                    {
                        'LineExtensionAmount' : [ 
                            {
                                'AmountContent' : '20.00',
                                'AmountCurrencyIdentifier' : 'PEN'
                            }
                        ],
                        'TaxInclusiveAmount' : [ 
                            {
                                'AmountContent' : '23.60',
                                'AmountCurrencyIdentifier' : 'PEN'
                            }
                        ],
                        'PayableAmount' : [ 
                            {
                                'AmountContent' : '23.60',
                                'AmountCurrencyIdentifier' : 'PEN'
                            }
                        ]
                    }
                ],
                'DebitNoteLine' : [ 
                    {
                        'ID' : [ 
                            {
                                'IdentifierContent' : 1
                            }
                        ],
                        'Note' : [ 
                            {
                                'TextContent' : 'unidad'
                            }
                        ],
                        'DebitedQuantity' : [ 
                            {
                                'QuantityContent' : '2',
                                'QuantityUnitCode' : 'ZZ',
                                'QuantityUnitCodeListIdentifier' : 'UN/ECE rec 20',
                                'QuantityUnitCodeListAgencyNameText' : 'United Nations Economic Commission for Europe'
                            }
                        ],
                        'LineExtensionAmount' : [ 
                            {
                                'AmountContent' : '20.00',
                                'AmountCurrencyIdentifier' : 'PEN'
                            }
                        ],
                        'PricingReference' : [ 
                            {
                                'AlternativeConditionPrice' : [ 
                                    {
                                        'PriceAmount' : [ 
                                            {
                                                'AmountContent' : '11.8000',
                                                'AmountCurrencyIdentifier' : 'PEN'
                                            }
                                        ],
                                        'PriceTypeCode' : [ 
                                            {
                                                'CodeContent' : '01'
                                            }
                                        ]
                                    }
                                ]
                            }
                        ],
                        'TaxTotal' : [ 
                            {
                                'TaxAmount' : [ 
                                    {
                                        'AmountContent' : '3.60',
                                        'AmountCurrencyIdentifier' : 'PEN'
                                    }
                                ],
                                'TaxSubtotal' : [ 
                                    {
                                        'TaxableAmount' : [ 
                                            {
                                                'AmountContent' : '23.60',
                                                'AmountCurrencyIdentifier' : 'PEN'
                                            }
                                        ],
                                        'TaxAmount' : [ 
                                            {
                                                'AmountContent' : '3.60',
                                                'AmountCurrencyIdentifier' : 'PEN'
                                            }
                                        ],
                                        'TaxCategory' : [ 
                                            {
                                                'ID' : [ 
                                                    {
                                                        'IdentifierContent' : 'S',
                                                        'IdentificationSchemeIdentifier' : 'UN/ECE 5305',
                                                        'IdentificationSchemeNameText' : 'Tax Category Identifier',
                                                        'IdentificationSchemeAgencyNameText' : 'United Nations Economic Commission for Europe'
                                                    }
                                                ],
                                                'TaxExemptionReasonCode' : [ 
                                                    {
                                                        'CodeContent' : '10',
                                                        'CodeListAgencyNameText' : 'PE:SUNAT',
                                                        'CodeListNameText' : 'SUNAT:Codigo de Tipo de Afectación del IGV',
                                                        'CodeListUniformResourceIdentifier' : 'urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo07'
                                                    }
                                                ],
                                                'TaxScheme' : [ 
                                                    {
                                                        'ID' : [ 
                                                            {
                                                                'IdentifierContent' : '1000',
                                                                'IdentificationSchemeIdentifier' : 'UN/ECE 5153',
                                                                'IdentificationSchemeAgencyIdentifier' : '6'
                                                            }
                                                        ],
                                                        'Name' : [ 
                                                            {
                                                                'TextContent' : 'IGV'
                                                            }
                                                        ],
                                                        'TaxTypeCode' : [ 
                                                            {
                                                                'CodeContent' : 'VAT'
                                                            }
                                                        ]
                                                    }
                                                ]
                                            }
                                        ]
                                    }
                                ]
                            }
                        ],
                        'Item' : [ 
                            {
                                'Description' : [ 
                                    {
                                        'TextContent' : 'descripcion'
                                    }
                                ],
                                'SellersItemIdentification' : [ 
                                    {
                                        'ID' : [ 
                                            {
                                                'IdentifierContent' : 'codigo'
                                            }
                                        ]
                                    }
                                ]
                            }
                        ],
                        'Price' : [ 
                            {
                                'PriceAmount' : [ 
                                    {
                                        'AmountCurrencyIdentifier' : 'PEN',
                                        'AmountContent' : '10.0000'
                                    }
                                ]
                            }
                        ]
                    }
                ]
            }
        ]
    }";

            JObject rss = JObject.Parse(json);
            Console.WriteLine(rss.ToString());
            JavaScriptSerializer js = new JavaScriptSerializer(); //system.web.extension assembly....
            string outputJson = js.Serialize(rss.ToString());
            string outputJson2 = js.Serialize(outputJson);
            File.WriteAllText(RUTA + NOMBRE, rss.ToString());

            //try
            //{
            //    Task<string> calltask = Task.Run(() => GetAPIToken(userName, password, Token_URL));

            //    calltask.Wait();
            //    TOKEN = calltask.Result;

            //    Task<string> calltask2 = Task.Run(() => postDoucumento(TOKEN, RUTA + NOMBRE, Documento_URL, NOMBRE));
            //    calltask2.Wait();
            //    TIKET = calltask.Result;

            //    Task<string> calltask3 = Task.Run(() => GetCDR_ANULA(TIKET,TOKEN,Cdr_URL));
            //    calltask3.Wait();
            //    HASH = calltask3.Result;

            //    Task<string> calltaks4 = Task.Run(()=> GetXML(TIKET, TOKEN, xml_URL));
            //    calltaks4.Wait();
            //    XML = calltaks4.Result;

            //    diccionario.Add("TIKET", TIKET);
            //    diccionario.Add("HASH", HASH);

            //}
            //catch (Exception EX)
            //{

            //    diccionario.Add("TIKET", "ERROR DE CONEXION");
            //    diccionario.Add("HASH", "ERROR DE CONEXION");
            //}
            return diccionario;
        }

        public async Task<string> GetXML(string TIKET, string TOKEN, string xml_URL)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    //SETUP CLIENTE
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TOKEN);

                    HttpResponseMessage response = await client.GetAsync(xml_URL + TIKET);
                    string responseString = await response.Content.ReadAsStringAsync();

                    // Create the XmlDocument.
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(responseString);

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    // Save the document to a file and auto-indent the output.
                    XmlWriter writer = XmlWriter.Create(rutaRAIZ + "CPE\\CDR\\" + RUC_EMISOR + "-" + SERIE + ".XML", settings);
                    doc.Save(writer);
                    return responseString.ToString();

                }
                catch (Exception e)
                {
                    return e.Message;
                }


            }
        }


        public async Task<string> GetCDR_ANULA(string TIKET, string TOKEN, string crd_URL)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    //SETUP CLIENTE
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + TOKEN);

                    HttpResponseMessage response = await client.GetAsync(Cdr_URL + TIKET);
                    string responseString = await response.Content.ReadAsStringAsync();
                    string DESCRIPCION = "", TIPO = "", HASH = "";
                    // Create the XmlDocument.
                    if (responseString == "{\"code\":\"2323\",\"description\":\"Existe documento ya informado anteriormente en una comunicación de baja.\"}")
                    {
                        DESCRIPCION = "eldocumento ya informado anteriormente en una comunicación de baja.";
                    }
                    else
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(responseString);

                        //Se obtiene el nodo del XML

                        XmlNodeList elemList = doc.GetElementsByTagName("Description");
                        for (int i = 0; i < elemList.Count; i++)
                        {
                            DESCRIPCION = (elemList[i].InnerXml);
                        }
                        XmlNodeList elemList3 = doc.GetElementsByTagName("ReferenceID");
                        for (int i = 0; i < elemList3.Count; i++)
                        {
                            TIPO = (elemList3[i].InnerXml);
                        }

                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.Indent = true;
                        // Save the document to a file and auto-indent the output.
                        XmlWriter writer = XmlWriter.Create(rutaRAIZ + "CPE\\ANULACION\\" + "R-" + TIPO + ".XML", settings);
                        doc.Save(writer);
                    }

                    return DESCRIPCION.ToString();

                }
                catch (Exception e)
                {
                    return e.Message;
                }


            }
        }

        public async Task<string> postDoucumento(string token, string DocRuta, string Documento_URL, string NameDoc)
        {
            using (var client = new HttpClient())
            {
                //SETUP CLIENTE
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var method = new MultipartFormDataContent();
                try
                {
                    var streamContent = new StreamContent(File.Open(DocRuta, FileMode.Open));
                    method.Add(streamContent, "file", NameDoc);
                    HttpResponseMessage response = await client.PostAsync(Documento_URL, method);
                    var responseString = await response.Content.ReadAsStringAsync();
                    //return responseString;

                    Tiket to = new Tiket();
                    //var numero = jObject[0]["access_token"].ToString();
                    //Console.WriteLine(numero);
                    //string TOKEN = await response.Content.ReadAsStringAsync();
                    to = JsonConvert.DeserializeObject<Tiket>(responseString);
                    TIKET = to.description;
                    return TIKET.ToString();
                }
                catch (Exception e)
                {

                    return e.Message;
                }


            }
        }


        static public async Task<string> GetAPIToken(string userName, string password, string token_URL)
        {
            using (var client = new HttpClient())
            {
                //SETUP CLIENTE

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorization);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //SETUP LOGIN DATA
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", userName),
                    new KeyValuePair<string, string>("password", password),
                });
                //ENVIAR REQUEST
                HttpResponseMessage response = await client.PostAsync(token_URL, formContent);

                //OBTENER EL ACCESO TOKEN DEL RESPONSE BODY
                //var responseJson = await response.Content.ReadAsStringAsync();
                //var jObject = JObject.Parse(responseJson);
                Token token = new Token();
                //var numero = jObject[0]["access_token"].ToString();
                //Console.WriteLine(numero);
                string TOKEN = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<Token>(TOKEN);
                TOKEN = token.access_token;
                return TOKEN.ToString();
            }
        }

        public class Token { public string access_token { get; set; } }
        public class Tiket { public string description { get; set; } }

    }
}
