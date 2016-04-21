using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleElasticSearch
{
   
    public class Format
    {
        public string aggregate { get; set; }
    }

    public class Column
    {
        public int id { get; set; }
        public string name { get; set; }
        public string dataTypeName { get; set; }
        public string fieldName { get; set; }
        public int position { get; set; }
        public string renderTypeName { get; set; }
        public Format format { get; set; }
        public int? tableColumnId { get; set; }
        public int? width { get; set; }
    }

    public class Grant
    {
        public bool inherited { get; set; }
        public string type { get; set; }
        public List<string> flags { get; set; }
    }

    public class Visible
    {
        public bool page { get; set; }
        public bool table { get; set; }
    }

    public class RenderTypeConfig
    {
        public Visible visible { get; set; }
    }

    public class Metadata
    {
        public RenderTypeConfig renderTypeConfig { get; set; }
        public List<string> availableDisplayTypes { get; set; }
    }

    public class Query
    {
    }

    public class TableAuthor
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string profileImageUrlLarge { get; set; }
        public string profileImageUrlMedium { get; set; }
        public string profileImageUrlSmall { get; set; }
        public string screenName { get; set; }
    }

    public class View
    {
        public string id { get; set; }
        public string name { get; set; }
        public int averageRating { get; set; }
        public string displayType { get; set; }
        public int downloadCount { get; set; }
        public int indexUpdatedAt { get; set; }
        public bool newBackend { get; set; }
        public int numberOfComments { get; set; }
        public int oid { get; set; }
        public bool publicationAppendEnabled { get; set; }
        public string publicationStage { get; set; }
        public int rowsUpdatedAt { get; set; }
        public string rowsUpdatedBy { get; set; }
        public int tableId { get; set; }
        public int totalTimesRated { get; set; }
        public int viewCount { get; set; }
        public string viewType { get; set; }
        public List<Column> columns { get; set; }
        public List<Grant> grants { get; set; }
        public Metadata metadata { get; set; }
        public Query query { get; set; }
        public List<string> rights { get; set; }
        public TableAuthor tableAuthor { get; set; }
        public List<string> flags { get; set; }
    }

    public class Meta
    {
        public View view { get; set; }
    }

    public class RootObject
    {
        public Meta meta { get; set; }
        public List<List<object>> data { get; set; }
    }


}
