
using System;
using Monday.DataAccess.Common;

namespace ErpApi.Entities 
{        
		             						
			/// <summary>			
			/// 。
			/// mapping table name: catsub。
			/// </summary>
			public class catsub                            
			{
				/// <summary>
				/// 商品線序號。
                /// </summary>
				[DBColumnMapping("catsub_id")]                        
				public Int32 catsub_id  { get; set; }
				                            	
				/// <summary>
				/// 隸屬區序號。
                /// </summary>
				[DBColumnMapping("catsub_catzoneid")]                        
				public Int16 catsub_catzoneid  { get; set; }
				                            	
				/// <summary>
				/// 分類序號。
                /// </summary>
				[DBColumnMapping("catsub_catlinid")]                        
				public Int16 catsub_catlinid  { get; set; }
				                            	
				/// <summary>
				/// 商品線。
                /// </summary>
				[DBColumnMapping("catsub_name")]                        
				public string catsub_name  { get; set; }
				                            	
				/// <summary>
				/// 興奇採購人員。
                /// </summary>
				[DBColumnMapping("catsub_mdypurher")]                        
				public string catsub_mdypurher  { get; set; }
				                            	
				/// <summary>
				/// 興奇採購主任。
                /// </summary>
				[DBColumnMapping("catsub_mdystaff")]                        
				public string catsub_mdystaff  { get; set; }
				                            	
				/// <summary>
				/// 特別推薦段數。
                /// </summary>
				[DBColumnMapping("catsub_casrcdqty")]                        
				public Int16 catsub_casrcdqty  { get; set; }
				                            	
				/// <summary>
				/// 庫存修正檔案數。
                /// </summary>
				[DBColumnMapping("catsub_stkfileqty")]                        
				public Int16 catsub_stkfileqty  { get; set; }
				                            	
				/// <summary>
				/// 實際建檔日期。
                /// </summary>
				[DBColumnMapping("catsub_sysdate")]                        
				public DateTime catsub_sysdate  { get; set; }
				                            	
				/// <summary>
				/// 更改次數。
                /// </summary>
				[DBColumnMapping("catsub_updated")]                        
				public Byte catsub_updated  { get; set; }
				                            	
				/// <summary>
				/// 最後更改日期。
                /// </summary>
				[DBColumnMapping("catsub_updateddate")]                        
				public DateTime catsub_updateddate  { get; set; }
				                            	
				/// <summary>
				/// 最後更改人。
                /// </summary>
				[DBColumnMapping("catsub_updateduser")]                        
				public string catsub_updateduser  { get; set; }
				                            	
				/// <summary>
				/// 大PM。
                /// </summary>
				[DBColumnMapping("catsub_mdypm")]                        
				public string catsub_mdypm  { get; set; }
				                            	
				/// <summary>
				/// 市場參考毛利率。
                /// </summary>
				[DBColumnMapping("catsub_grossmargin")]                        
				public Decimal catsub_grossmargin  { get; set; }
				                            	
				/// <summary>
				/// 長尾商品毛利率調整值。
                /// </summary>
				[DBColumnMapping("catsub_ltgrossmargin")]                        
				public Decimal catsub_ltgrossmargin  { get; set; }
				                            	
				/// <summary>
				/// 商品線-可以使用的功能。
                /// </summary>
				[DBColumnMapping("catsub_funcs")]                        
				public string catsub_funcs  { get; set; }
				                            	
				/// <summary>
				/// 賣場毛利率限制百分比。
                /// </summary>
				[DBColumnMapping("catsub_gdlmtrate")]                        
				public Decimal catsub_gdlmtrate  { get; set; }
				                            	
				/// <summary>
				/// 興奇採購人員全名。
                /// </summary>
				[DBColumnMapping("catsub_purhfullname")]                        
				public string catsub_purhfullname  { get; set; }
				                            	
				/// <summary>
				/// 興奇採購主任全名。
                /// </summary>
				[DBColumnMapping("catsub_stafffullname")]                        
				public string catsub_stafffullname  { get; set; }
				                            	
				/// <summary>
				/// 大PM全名。
                /// </summary>
				[DBColumnMapping("catsub_pmfullname")]                        
				public string catsub_pmfullname  { get; set; }
				                            	
				/// <summary>
				/// 業績歸屬(群)。
                /// </summary>
				[DBColumnMapping("catsub_blnggroup")]                        
				public string catsub_blnggroup  { get; set; }
				                            	
				/// <summary>
				/// 業績歸屬team 。
                /// </summary>
				[DBColumnMapping("catsub_blngteam")]                        
				public Int32 catsub_blngteam  { get; set; }
				                            	
				/// <summary>
				/// 業績歸屬線。
                /// </summary>
				[DBColumnMapping("catsub_blngline")]                        
				public Int32 catsub_blngline  { get; set; }
				                            	
				/// <summary>
				/// 電子禮券折扣率。
                /// </summary>
				[DBColumnMapping("catsub_ecupnrate")]                        
				public Decimal catsub_ecupnrate  { get; set; }
				                            	
				/// <summary>
				/// 業績歸屬(群)ID。
                /// </summary>
				[DBColumnMapping("catsub_blnggrpid")]                        
				public Byte catsub_blnggrpid  { get; set; }
				                            	
				/// <summary>
				/// 子站類別(0: 一般子站, 1: 品牌子站)。
                /// </summary>
				[DBColumnMapping("catsub_type")]                        
				public Byte catsub_type  { get; set; }
				                            	
				/// <summary>
				/// 供應商提案毛利率。
                /// </summary>
				[DBColumnMapping("catsub_spsgstgrossmargin")]                        
				public Decimal catsub_spsgstgrossmargin  { get; set; }
				                            	
				                                
			}                            
}
