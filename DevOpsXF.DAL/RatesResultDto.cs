using System;
using System.Collections.Generic;

namespace DevOpsXF.DAL
{
	public class RatesResultDto {
		public bool Success { get; set; }
		public long Timestamp { get; set; }
		public string Source { get; set; }
		public string Terms { get; set; }
		public string Privacy { get; set; }
		public Dictionary<string,double> Quotes { get; set; }
	}
}