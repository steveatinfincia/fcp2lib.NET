﻿/*
 * Erstellt mit SharpDevelop.
 * Benutzer: apophis
 * Datum: 18.02.2009
 * Zeit: 22:38
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
using System;
using System.IO;
using System.Collections.Generic;

namespace Freenet.FCP2
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public class MessageParser
    {
        private Dictionary<string, string> parameters = new Dictionary<string, string>();
        
        public MessageParser(TextReader reader)
        {
            string line;
            int pos;
            while((line = reader.ReadLine()) != FCP2.endMessage) {
                if (line == "End") 
                    throw new NotImplementedException("NoEnd");
                if (line == "Data") 
                    throw new NotImplementedException("NoData");
                if((pos = line.IndexOf('=')) == -1) {
                    throw new NotImplementedException("EmptyValue:" + line);
                } else {
                    parameters.Add(line.Substring(0, pos), line.Substring(pos+1));
                }
            }
        }
        
        /// <summary>
        /// Intelligent Accessor, returns null if a value does not exists!
        /// </summary>
        public string this[string keyword] {
            get {
                if (parameters.ContainsKey(keyword)) {
                    return parameters[keyword];
                } else {
                    return null;
                }
            }
            
        }
    }
}