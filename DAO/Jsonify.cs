﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Net;
using System.Web.Script.Serialization;
//using ServiceStack.Text;
using Newtonsoft.Json;

using RDFRepresentation;
using Filtering;

namespace DAO
{
	/**
	 * This class deals with JSON output based on triple list.
	 */
	public class Jsonify //: IInput
    {
    
		public  static List<Triple> readTriples(string filePath){
			String data = File.ReadAllText(filePath);
    		
			List<Triple> dicto = JsonConvert.DeserializeObject<List<Triple>>(data);
			
    		
			
			JavaScriptSerializer jss = new JavaScriptSerializer();
    		
    		List<Triple> dict = jss.Deserialize<List<Triple>>(data);
    		
			return dicto;
			
			
			//return new List<Triple>();
		}
		public static  List<Triple> readPatternTriples(string filePath){
			return new List<Triple>();
		}
		public static List<LexCollection> readLexicalizations(string filePath){
			return new List<LexCollection>();
		}
			
    	/**
    	 * This method returns JSON string based on triple list.
    	 * 
		 * Example usage:
    	 * Console.WriteLine(Jsonify.me(myTripleList));
    	 * 
    	 * @param List<Triple>
	 	 * @return String
    	 */
    	public static String me(List<Triple> list) {
    		return "";//JsonSerializer.SerializeToString(list);	
    	}
    	
    	//TODO: fill me
    	public static void toFile(dynamic @object, String file){
    		return ;
    	}
    	
    	/**
    	 * This method may fetch JSON from remote URL and
    	 * return dictionary.
    	 * 
		 * dynamic used, because thanks to that you can use any
    	 * of the JSON structure.
    	 * 
    	 * @param String url
    	 * @return dynamic Dictionary
    	 */ 
    	public static dynamic fromURL(String url) {
    		WebClient webClient = new WebClient();
			String content = webClient.DownloadString(url);

			JavaScriptSerializer jss = new JavaScriptSerializer();
			dynamic dict = jss.Deserialize<dynamic>(content);
			
			return dict;
    	}
    	
    	/**
    	 * This method returns parsed data in JSON format
    	 * from some file.
    	 * 
    	 * @param String path to the file
    	 * @return String file content
    	 */ 
    	public static dynamic fromFile(String path) {
    		String data = File.ReadAllText(path);
    		
    		JavaScriptSerializer jss = new JavaScriptSerializer();
			dynamic dict = jss.Deserialize<dynamic>(data);
			return dict;
    	}
    	
    	public static void Main() {
    		
//    		String content = fromFile("../../../data.json");
//    		
//			JavaScriptSerializer jss = new JavaScriptSerializer();
//			dynamic dict = jss.Deserialize<dynamic>(content);
//			
//			foreach(dynamic row in dict["results"]["bindings"]){
//				Console.WriteLine(row["film"]["value"]);
//			}
			
			
			/*List<Triple> triples = readTriples("../../../triples.json");
			foreach(Triple t in triples){
				
				Console.WriteLine(t.ToString());
			}*/
			Entity obj = new Entity("Fort I", new EntityType("Zamek"));
//    		Entity property = new Entity("zostalZbudowany", new EntityType("zostalZbudowany"));
//    		Entity subject = new Entity("1922-1960", new EntityType("rok"));
//    		
//    		Triple t = new Triple(obj, property, subject);
			
			//File.WriteAllText("../../../triples.json", JsonConvert.SerializeObject(obj,Formatting.Indented,
  //new JsonSerializerSettings { }) );
    		
			
			String data = File.ReadAllText("../../../triples.json");
			
			
			Entity dicto = JsonConvert.DeserializeObject<Entity>(data);
			
			
			Console.WriteLine(dicto.ToString());
			
			
    		
    		/*List<Triple> list = new List<Triple>();
    		
    		Entity obj = new Entity("Fort I", new EntityType("Zamek"));
    		Entity property = new Entity("zostalZbudowany", new EntityType("zostalZbudowany"));
    		Entity subject = new Entity("1922-1960", new EntityType("rok"));
    		
    		Triple t = new Triple(obj, property, subject);
    		list.Add(t);
    		
    		File.WriteAllText("../../../triples.json",
    		                  JsonConvert.SerializeObject(list)
    		                 // JsonSerializer.SerializeToString(list)
    		                 );
    		//Console.WriteLine(JsonSerializer.SerializeToString(list));
    		*/
    		
    		Console.ReadKey();
    	}
    }
}
